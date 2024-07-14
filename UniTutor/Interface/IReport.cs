using UniTutor.Model;

namespace UniTutor.Interface
{
    public interface IReport
    {
        Task<Report> Create(Report report);
        Task<Report> GetById(int id);
        Task<List<Report>> GetAll();
        Task SendWarningEmail(int reportId, string adminMessage);
        Task SuspendUser(int reportId);
        Task BanUser(int reportId);
        Task RestoreUser(int reportId);

    }
}
