using Microsoft.EntityFrameworkCore;
using UniTutor.DataBase;
using UniTutor.Interface;
using UniTutor.Model;

namespace UniTutor.Repository
{
    public class RequestRepository : IRequest
    {
        private ApplicationDBContext _DBcontext;
        private readonly IConfiguration _config;



        public RequestRepository(ApplicationDBContext DBcontext, IConfiguration config)
        {
            _DBcontext = DBcontext;
            _config = config;


        }
        public async Task<IEnumerable<Request>> GetAll()
        {
            return await _DBcontext.Requests.ToListAsync();
        }

        public async Task<Request> GetById(int id)
        {
            return await _DBcontext.Requests.FindAsync(id);
        }

        public async Task<IEnumerable<Request>> GetByStudentId(int studentId)
        {
            return await _DBcontext.Requests
                .Where(sr => sr.studentId == studentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Request>> GetByTutorId(int tutorId)
        {
            return await _DBcontext.Requests
                .Where(sr => sr.tutorId == tutorId)
                .Include(sr => sr.Subject)
                .Include(sr => sr.Student)
                .ToListAsync();
        }

        public async Task<Request> Create(Request request)
        {
            _DBcontext.Requests.Add(request);
            await _DBcontext.SaveChangesAsync();
            return request;
        }

        public async Task<Request> UpdateStatus(int id, string status)
        {
            var request = await _DBcontext.Requests.FindAsync(id);
            if (request == null)
            {
                return null;
            }

            request.status = status;
            _DBcontext.Entry(request).State = EntityState.Modified;
            await _DBcontext.SaveChangesAsync();
            return request;
        }

        public async Task<Request> Delete(int id)
        {
            var request = await _DBcontext.Requests.FindAsync(id);
            if (request == null)
            {
                return null;
            }

            _DBcontext.Requests.Remove(request);
            await _DBcontext.SaveChangesAsync();
            return request;
        }




    }

}

