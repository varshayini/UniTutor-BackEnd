using Microsoft.EntityFrameworkCore;
using UniTutor.DataBase;
using UniTutor.Interface;
using UniTutor.Model;

public class CommentRepository : IComment
{
    private readonly ApplicationDBContext _DBcontext;

    public CommentRepository(ApplicationDBContext DBcontext)
    {
        _DBcontext = DBcontext;
    }

    public async Task AddCommentAsync(Comment comment)
    {
        _DBcontext.Comments.Add(comment);
        await _DBcontext.SaveChangesAsync();
    }

    public async Task CreateTutorCommentAsync(string commentText, DateTime time, int tutorId)
    {
        var comment = new Comment
        {
            commentText = commentText,
            time = time,
            userType = "Tutor",
            tutId = tutorId
            
        };

        await AddCommentAsync(comment);
    }

    public async Task CreateStudentCommentAsync(string commentText, DateTime time, int studentId)
    {
        var comment = new Comment
        {
            commentText = commentText,
            time = time,
            userType = "Student",
            stuId = studentId
        };

        await AddCommentAsync(comment);
    }

    
    public IEnumerable<Comment> GetAllComments()
    {
        return _DBcontext.Comments.ToList();
    }
}

