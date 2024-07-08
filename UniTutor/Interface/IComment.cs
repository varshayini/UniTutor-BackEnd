using UniTutor.Model;

namespace UniTutor.Interface
{
    public interface IComment
    {
        Task CreateTutorCommentAsync(string commentText, DateTime createdAt, int tutorId);
        Task CreateStudentCommentAsync(string commentText, DateTime createdAt, int studentId);
        Task AddCommentAsync(Comment comment);
        public IEnumerable<Comment> GetAllComments();
        
    }
}
