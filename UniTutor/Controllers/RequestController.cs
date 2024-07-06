//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using UniTutor.Interface;
//using UniTutor.Model;

//namespace UniTutor.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RequestController : ControllerBase
//    {
//        private readonly IRequest _request;
//        private readonly ITutor _tutor;
//        private readonly IConfiguration _config;
//        public RequestController(IConfiguration config,IRequest request,ITutor tutor )
//        {
//            _request = request;
//            _tutor = tutor;
//            _config = config;
//        }

//        //create request by studnet id and tutor id and a request object
//        [HttpPost("createrequest/{studentId}/{tutorId}")]
//        public async Task<IActionResult> CreateRequest(int studentId, int tutorId, [FromBody] Request request)
//        {
//            request.studentId = studentId;
//            request.tutorId = tutorId;
//            var result = await _request.CreateRequest(request);
//            if (result)
//            { 
//                return Ok();
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }

//        [HttpGet("getallrequests")]
//        public async Task<IActionResult> GetAllRequests()
//        {
//            var requests = await _request.GetAllRequests();
//            return Ok(requests);
//        }
//        [HttpGet("getallrequestsbytutorid/{tutorId}")]
//        public async Task<IActionResult> GetAllRequestsByTutorId(int tutorId)
//        {
//            var requests = await _request.GetAllRequestsByTutorId(tutorId); ;
//            return Ok(requests);
//        }

//        [HttpGet("getallacceptedrequestsbytutorid/{tutorId}")]
//        public async Task<IActionResult> GetAllAcceptedRequestsByTutorId(int tutorId)
//        {
//            var requests = await _request.GetAllAcceptedRequestsByTutorId(tutorId);
//            return Ok(requests);
//        }
//        [HttpGet("getallrequestsbystudentid/{studentId}")]
//        public async Task<IActionResult> GetAllRequestsByStudentId(int studentId)
//        {
//            var requests = await _request.GetAllRequestsByStudentId(studentId);
//            return Ok(requests);
//        }

//        [HttpGet("getallacceptedrequestsbystudentid/{studentId}")]
//        public async Task<IActionResult> GetAllAcceptedRequestsByStudentId(int studentId)
//        {
//            var requests = await _request.GetAllAcceptedRequestsByStudentId(studentId);
//            return Ok(requests);
//        }
        
       

//        [HttpPost("acceptrequest/{id}")]
//        public async Task<IActionResult> Acceptequest(int id)
//        {
//            var request = _request.GetRequestById(id);
//            if (request == null)
//            {
//                return NotFound();
//            }

//            // Perform acceptance logic
//            await _request.AcceptRequest(id);

//            return Ok();
//        }

//        [HttpDelete("rejectrequest/{id}")]
//        public async Task<IActionResult> RejectTutor(int id)
//        {
//            var request = _request.GetRequestById(id);
//            if (request == null)
//            {
//                return NotFound();
//            }

//            // Perform rejection logic
//            await _request.RejectRequest(id);



//            return Ok();
//        }
        
       
        

//    }
//}
