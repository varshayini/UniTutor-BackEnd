﻿using AutoMapper;
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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniTutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        ITutor _tutor;
        private IConfiguration _config;
        private readonly IMapper _mapper;
        //private readonly ISmsService _smsService;

        public TutorController(ITutor tutor, IConfiguration config,IMapper mapper)
        {
            _tutor = tutor;
            _config = config;
            _mapper = mapper;
            //_smsService = smsService;
        }
        //public async Task<IActionResult> CreateRequest([FromBody] Tutor tutor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    await _tutor.CreateTutorRequestAsync(tutor);

        //    // Send SMS notification
        //    string message = $"New tutor request from {tutor.firstName}. Request ID: {tutor.Id}";
        //    await _smsService.SendSmsAsync(tutor.phoneNumber, message);

        //    return Ok(tutor);
        //}

        [HttpPost("create")]
        public IActionResult CreateAccount([FromBody] TutorRegistration tutorDto)
        {
            if (ModelState.IsValid)
            {
                // Set CreatedAt to local time
                TimeZoneInfo localZone = TimeZoneInfo.FindSystemTimeZoneById("Sri Lanka Standard Time"); // Change to your local time zone
                DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, localZone);
               
                var tutor = _mapper.Map<Tutor>(tutorDto);
                PasswordHash ph = new PasswordHash();
               
                tutor.password = ph.HashPassword(tutorDto.password); // Hash the password
                tutor.CreatedAt = localDateTime;

                var result = _tutor.SignUp(tutor);
                if (result)
                {
                    Console.WriteLine("registration success");
                    return CreatedAtAction(nameof(GetAccountById), new { id = tutor.Id }, tutor);
                }
                else
                {
                    Console.WriteLine("registration failed");
                    return BadRequest(result);
                }
            }
            else
            {
                return BadRequest("ModelError");
            }
        }

        [HttpGet("details/{id}")]
        public IActionResult GetAccountById(int id)
        {
            var tutor = _tutor.GetById(id);
            if (tutor == null)
            {
                return NotFound();
            }
            return Ok(tutor);
        }


        [HttpPost("login")]
        public IActionResult login([FromBody] LoginRequest tutor)
        {
            var email = tutor.Email;
            var password = tutor.Password;

            var result = _tutor.login(email, password);

            if (!result)
            {
                return Unauthorized("Username or password incorrect.");
            }

            var loggedInTutor = _tutor.GetTutorByEmail(email);

            // Check if tutor is verified
            if (!loggedInTutor.Verified)
            {
                return Unauthorized("Account not verified. Please contact the administrator.");
            }

            // Authentication successful, generate JWT token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, loggedInTutor.universityMail),  // Email claim
            new Claim(ClaimTypes.NameIdentifier, loggedInTutor.Id.ToString()),  // ID claim
            new Claim(ClaimTypes.GivenName, loggedInTutor.firstName),  // Name claim
            new Claim(ClaimTypes.Role, "Tutor")
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token), Id = loggedInTutor.Id });
        }


        [HttpPut("ProfileUpdate/{id}")]
        public async Task<IActionResult> UpdateTutor(int id, [FromBody] UpdateTutorDto updateTutorDto)
        {
            if (id != updateTutorDto.Id)
            {
                return BadRequest();
            }

            var tutor = await _tutor.GetByIdAsync(id);

            if (tutor == null)
            {
                return NotFound();
            }

            tutor.firstName = updateTutorDto.firstName;
            tutor.lastName = updateTutorDto.lastName;
            tutor.occupation = updateTutorDto.occupation;
            tutor.phoneNumber = updateTutorDto.phoneNumber;
            tutor.district = updateTutorDto.district;
            tutor.address = updateTutorDto.address;
            tutor.qualifications = updateTutorDto.qualifications;
            tutor.cv = updateTutorDto.cv;
            tutor.ProfileUrl = updateTutorDto.ProfileUrl;

            if (!string.IsNullOrEmpty(updateTutorDto.ProfileUrl))
            {
                tutor.ProfileUrl = updateTutorDto.ProfileUrl;
            }

            await _tutor.UpdateAsync(tutor);

            return NoContent();
        }

        [HttpGet("dashborddetails/{tutorId}")]
        public async Task<IActionResult> GetTutorDashboardDetails(int tutorId)
        {
            var tutorDetails = await _tutor.GetTutorDashboardDetails(tutorId);
            if (tutorDetails == null)
            {
                return NotFound();
            }
            return Ok(tutorDetails);
        }
        



    }
}

