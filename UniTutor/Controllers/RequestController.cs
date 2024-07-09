using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        // GET: api/SubjectRequests
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "SubjectRequest Route";
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
            try
            {
                var requests = await _request.GetByTutorId(id);
                return Ok(requests);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
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
        public async Task<ActionResult<Request>> UpdateSubjectRequestStatus(int id, [FromBody] Request request)
        {
            if (request.status == null)
            {
                return BadRequest("Status is required");
            }

            try
            {
                var updatedRequest = await _request.UpdateStatus(id, request.status);
                if (updatedRequest == null)
                {
                    return NotFound();
                }

                return Ok(updatedRequest);
            }
            catch (System.Exception ex)
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

        [HttpGet("{studentId}/mysubjects")]
        public async Task<IActionResult> GetMySubjectsCount(int studentId)
        {
            var count = await _request.GetMySubjectsCount(studentId);
            return Ok(count);
        }

        [HttpGet("{studentId}/acceptedrequests")]
        public async Task<IActionResult> GetAcceptedRequestsCount(int studentId)
        {
            var count = await _request.GetAcceptedRequestsCount(studentId);
            return Ok(count);
        }

        [HttpGet("{studentId}/rejectedrequests")]
        public async Task<IActionResult> GetRejectedRequestsCount(int studentId)
        {
            var count = await _request.GetRejectedRequestsCount(studentId);
            return Ok(count);

        }
    }
}
