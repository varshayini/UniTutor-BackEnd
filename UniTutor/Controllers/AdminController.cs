 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UniTutor.DTO;
using UniTutor.Interface;
using UniTutor.Model;
using UniTutor.Repository;

namespace UniTutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;
        private IConfiguration _config;
        private readonly IStudent _student;
        private readonly ITutor _tutor;
        private readonly IEmailService _emailService;


        public AdminController(IAdmin adminRepository, IConfiguration config, IStudent student, ITutor tutor, IEmailService emailService)
        {
            _admin = adminRepository;
            _config = config;
            _student = student;
            _tutor = tutor;
            _emailService = emailService;
        }


        [HttpPost("create")]
        public IActionResult CreateAdmin([FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var isAdmin = _admin.IsAdmin(admin);
                if (!isAdmin)
                {
                    var result = _admin.CreateAdmin(admin);
                    if (result)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost("adminLogin")]
        public IActionResult AdminLogin([FromBody] LoginRequest adminLogin)
        {
            var result = _admin.Login(adminLogin.Email, adminLogin.Password);
            if (result)
            {
                // Retrieve admin details from the database
                var loggedInAdmin = _admin.GetAdminByEmail(adminLogin.Email);

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Name, adminLogin.Email),  // Email claim
                new Claim(ClaimTypes.NameIdentifier, loggedInAdmin._id.ToString()),  // Admin ID claim
                new Claim(ClaimTypes.GivenName, loggedInAdmin.Name),  // Admin name claim
                new Claim(ClaimTypes.Role, "Student")

                    }),
                    Expires = DateTime.UtcNow.AddDays(30),
                    SigningCredentials = credentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { token = tokenHandler.WriteToken(token), Id = loggedInAdmin._id });
            }
            else
            {
                return Unauthorized("Invalid email or password");
            }
        }


        [HttpGet("isAuthenticated")]
        public IActionResult isAthenticated([FromQuery(Name = "token")] string token)
        {
            var validatedToken = _admin.validateToken(token);
            if (validatedToken != null)
            {
                return Ok(new { authenticated = true });
            }
            else
            {
                return Unauthorized(new { authenticated = false });
            }
        }
       
        
        [HttpDelete("delete-student/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var result = _student.Delete(id);
            if (result)
            {
                return Ok(new { message = "Student deleted successfully." });
            }
            return NotFound(new { message = "Student not found." });
        }

        [HttpDelete("delete-tutor/{id}")]
        public IActionResult DeleteTutor(int id)
        {
            var result = _tutor.Delete(id);
            if (result)
            {
                return Ok(new { message = "Tutor deleted successfully." });
            }
            return NotFound(new { message = "Tutor not found." });
        }

        [HttpGet("AllStudents")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = _admin.GetAllStudent();
            if (students != null)
            {
                return Ok(students);
            }
            else
            {
                return BadRequest("There is no student");
            }
        }
        [HttpGet("AllTutors")]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutors()
        {
            var tutors = _admin.GetAllTutor();
            if (tutors != null)
            {
                return Ok(tutors);
            }
            else
            {
                return BadRequest("There is no student");
            }
        }
        //get verified = false tutor list
        [HttpGet("TutorVerification")]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutorVerification()
        {
            var tutors = _admin.GetTutorVerification();
            if (tutors != null)
            {
                return Ok(tutors);
            }
            else
            {
                return BadRequest("There is no student");
            }
        }
       




        [HttpPost("accepttutor/{id}")]
        public async Task<IActionResult> AcceptTutor(int id)
        {
            var tutor = _admin.GetTutorById(id);
            if (tutor == null)
            {
                return NotFound();
            }

            // Perform acceptance logic
            await _admin.AcceptTutor(id);

            // Send verification email
            var emailSubject = "Your tutor account has been accepted";
            var emailMessage = $"Dear {tutor.firstName}, your tutor account has been accepted.";
            await _emailService.SendEmailAsync(tutor.universityMail, emailSubject, emailMessage);

            return Ok();
        }
        [HttpDelete("rejecttutor/{id}")]
        public async Task<IActionResult> RejectTutor(int id)
        {
            var tutor = _admin.GetTutorById(id);
            if (tutor == null)
            {
                return NotFound();
            }

            // Perform rejection logic
            await _admin.RejectTutor(id);

            // Send rejection email
            var emailSubject = "Your tutor account has been rejected";
            var emailMessage = $"Dear {tutor.firstName}, unfortunately, your tutor account has been rejected.";
            await _emailService.SendEmailAsync(tutor.universityMail, emailSubject, emailMessage);

            return Ok();
        }

        [HttpGet("Studentdetails/{id}")]
        public async Task<ActionResult<StudentViewMoreDto>> GetStudentDetails(int id)
        {
            var student = _admin.GetStudentById(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            var studentViewMoreDto = new StudentViewMoreDto
            {
                _id = student._id,
                firstName = student.firstName,
                lastName = student.lastName,
                email = student.email,
                grade = student.grade,
                schoolName = student.schoolName,
                address = student.address,
                district = student.district,
                phoneNumber = student.phoneNumber,
                numberofcomplain = student.numberofcomplain,
                ProfileUrl = student.ProfileUrl,
                CreatedAt = student.CreatedAt

              
            };

            return Ok(studentViewMoreDto);
        }
        [HttpGet("Tutordetails/{id}")]
        public async Task<ActionResult<TutorViewMoreDto>> GetTutorDetails(int id)
        {
            var tutor = _admin.GetTutorById(id);

            if (tutor == null)
            {
                return NotFound("tutor not found");
            }

            var tutorViewMoreDto = new TutorViewMoreDto
            {
                _id = tutor._id,
                firstName = tutor.firstName,
                lastName = tutor.lastName,
                occupation = tutor.occupation,
                address = tutor.address,
                district = tutor.district,
                phoneNumber = tutor.phoneNumber,
                universityMail = tutor.universityMail,
                qualifications = tutor.qualifications,
                cv = tutor.cv,
                universityID = tutor.universityID,
                ProfileUrl = tutor.ProfileUrl,
                CreatedAt = tutor.CreatedAt,
                Verified = tutor.Verified

            };

            return Ok(tutorViewMoreDto);
        }
    }
    

}
