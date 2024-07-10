using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using UniTutor.DTO;
using UniTutor.Interface;
using UniTutor.Model;
using UniTutor.Repository;

namespace UniTutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequest _request;
        private readonly ITutor _tutor;
        private readonly IConfiguration _config;
        public RequestController(IConfiguration config, IRequest request, ITutor tutor)
        {
            _request = request;
            _tutor = tutor;
            _config = config;
        }

       
       // POST: api/SubjectRequests/request
        [HttpPost("request")]
        public async Task<ActionResult<RequestDto>> CreateSubjectRequest([FromBody] RequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newRequest = await _request.Create(request);
                return CreatedAtAction(nameof(GetSubjectRequestById), new { id = newRequest.subjectId }, newRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, stackTrace = ex.StackTrace });
            }
        }

       // GET: api/SubjectRequests/student/{id}
        [HttpGet("student/{id}")]
        public async Task<ActionResult<IEnumerable<Request>>> GetSubjectRequestsByStudentId(int id)
        {
            try
            {
                var requests = await _request.GetByStudentId(id);
                return Ok(requests);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        //get the detils by id
        [HttpGet("tutor/{id}")]
        public async Task<ActionResult<IEnumerable<Request>>> GetSubjectRequestsByTutorId(int id)
        {
            var requests = await _request.GetByTutorId(id);

            var result = requests.Select(r => new 
            {
                r.subjectRequestId,
                r.studentId,
                r.tutorId,
                r.subjectId,
                r.studentEmail,
                r.status,
                r.timestamp,
                subject = new
                {
                    r.Subject._id,
                    r.Subject.title,
                    r.Subject.coverImage
                },
                student = new
                {
                    r.Student.Id,
                    r.Student.firstName,
                    r.Student.email,
                    r.Student.phoneNumber, 
                    r.Student.district,
                    r.Student.schoolName,
                    r.Student.grade
                }
            }).ToList();

            return Ok(result);
        }
          


        // DELETE: api/SubjectRequests/request/{id}
        [HttpDelete("request/{id}")]
        public async Task<ActionResult<Request>> DeleteSubjectRequest(int id)
        {
            try
            {
                var request = await _request.Delete(id);
                if (request == null)
                {
                    return NotFound();
                }

                return Ok(request);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // PUT: api/SubjectRequests/request/{id}
        [HttpPut("request/{id}")]
        public async Task<IActionResult> UpdateRequestStatus(int id, [FromBody] RequestStatues StatusDto)
        {
            if (string.IsNullOrEmpty(StatusDto.status))
            {
                return BadRequest("Status is required");
            }

            try
            {
                var updatedRequest = await _request.UpdateRequestStatus(id, StatusDto.status);
                if (updatedRequest == null)
                {
                    return NotFound();
                }
                return Ok(updatedRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // GET: api/SubjectRequests/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetSubjectRequestById(int id)
        {
            var request = await _request.GetById(id);

            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);


        }

        [HttpGet("{studentId}/mysubjectscount")]
        public async Task<IActionResult> GetMySubjectsCount(int studentId)
        {
            var count = await _request.GetMySubjectsCount(studentId);
            return Ok(count);
        }

        [HttpGet("{studentId}/acceptedrequestscount")]
        public async Task<IActionResult> GetAcceptedRequestsCount(int studentId)
        {
            var count = await _request.GetAcceptedRequestsCount(studentId);
            return Ok(count);
        }

        [HttpGet("{studentId}/rejectedrequestscount")]
        public async Task<IActionResult> GetRejectedRequestsCount(int studentId)
        {
            var count = await _request.GetRejectedRequestsCount(studentId);
            return Ok(count);

        }
        //get accepted request list bystudentid and statues Accepted
        [HttpGet("{studentId}/acceptedrequests")]
        public async Task<IActionResult> GetAcceptedRequests(int studentId)
        {
            var requests = await _request.GetByStudentId(studentId);
            var result = requests.Where(r => r.status == "ACCEPTED").ToList();
            return Ok(result);
        }
        //get request list bystudentid and statues pending
        [HttpGet("{studentId}/pendingrequests")]
        public async Task<IActionResult> GetPendingRequests(int studentId)
        {
            var requests = await _request.GetByStudentId(studentId);
            var result = requests.Where(r => r.status == "PENDING").ToList();
            return Ok(result);
        }
    }
}
