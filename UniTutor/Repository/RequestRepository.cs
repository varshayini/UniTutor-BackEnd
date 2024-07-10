//using Microsoft.EntityFrameworkCore;
//using UniTutor.DataBase;
//using UniTutor.Interface;
//using UniTutor.Model;

//namespace UniTutor.Repository
//{
//    public class RequestRepository : IRequest
//    {
//        private ApplicationDBContext _DBcontext;
//        private readonly IConfiguration _config;



//        public RequestRepository(ApplicationDBContext DBcontext, IConfiguration config)
//        {
//            _DBcontext = DBcontext;
//            _config = config;


//        }
//        //create request
//        public async Task<bool> CreateRequest(Request request)
//        {
//            try
//            {
//                _DBcontext.Requests.Add(request);
//                await _DBcontext.SaveChangesAsync();
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.ToString());
//                return false;
//            }
//        }
//        //get all requests
//        public async Task<List<Request>> GetAllRequests()
//        {
//            return await _DBcontext.Requests.ToListAsync();
//        }
//        //get all requests by tutor id
//        public async Task<List<Request>> GetAllRequestsByTutorId(int tutorId)
//        {
//            return await _DBcontext.Requests.Where(b => b.tutorId == tutorId && b.status == false).ToListAsync();
//        }
//        //get all requests by tutor id and status==true
//        public async Task<List<Request>> GetAllAcceptedRequestsByTutorId(int tutorId)
//        {
//            return await _DBcontext.Requests.Where(a => a.tutorId == tutorId && a.status == true).ToListAsync();
//        }
//        //get all requests by student id
//        public async Task<List<Request>> GetAllRequestsByStudentId(int studentId)
//        {
//            return await _DBcontext.Requests.Where(a => a.studentId == studentId && a.status == false).ToListAsync();
//        }
//        //get all requests by student id and status==true
//        public async Task<List<Request>> GetAllAcceptedRequestsByStudentId(int studentId)
//        {
//            return await _DBcontext.Requests.Where(a => a.studentId == studentId && a.status == true).ToListAsync();
//        }

//        //getrequestbyid
//        public async Task<Request> GetRequestById(int id)
//        {
//            return await _DBcontext.Requests.FindAsync(id);
//        }

//        //accept reject for the students request
//        public async Task AcceptRequest(int id)
//        {
//            // Implement logic to accept a request
//            var request = await _DBcontext.Requests.FindAsync(id);
//            if (request != null)
//            {
//                request.status = true; // Example: Update request status
//                await _DBcontext.SaveChangesAsync();
//            }
//        }

//        public async Task RejectRequest(int id)
//        {
//            // Implement logic to reject a tutor
//            var request = await _DBcontext.Requests.FindAsync(id);
//            if (request != null)
//            {
//                request.status = false; // Example: Update request status
//                await _DBcontext.SaveChangesAsync();
//            }
//        }


//    }
//}
