using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniTutor.Interface;
using UniTutor.Model;

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
        public async Task<ActionResult<Request>> CreateSubjectRequest([FromBody] Request request)
        {
            try
            {
                var newrequest = await _request.Create(request);
                return CreatedAtAction(nameof(GetSubjectRequestById), new { id = newrequest.subjectId }, newrequest);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
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

        // GET: api/SubjectRequests/tutor/{id}
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
    }
}
