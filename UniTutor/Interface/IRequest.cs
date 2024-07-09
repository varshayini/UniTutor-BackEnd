using UniTutor.DTO;
using UniTutor.Model;

namespace UniTutor.Interface
{
    public interface IRequest
    {
        Task<IEnumerable<Request>> GetAll();
        Task<Request> GetById(int id);
        Task<IEnumerable<Request>> GetByStudentId(int studentId);
        Task<IEnumerable<Request>> GetByTutorId(int tutorId);
        Task<Request> Create(RequestDto request);
        Task<Request> UpdateStatus(int id, string status);
        Task<Request> Delete(int id);

        Task<int> GetMySubjectsCount(int studentId);
        Task<int> GetAcceptedRequestsCount(int studentId);
        Task<int> GetRejectedRequestsCount(int studentId);
    }
}

