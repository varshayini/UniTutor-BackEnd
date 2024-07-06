//using Microsoft.EntityFrameworkCore;
//using UniTutor.DataBase;
//using UniTutor.Interface;
//using UniTutor.Model;

//public class CommentRepository : IComment
//{
//    private readonly IComment _comment;
//    private ApplicationDBContext _DBcontext;

//    public CommentRepository(IComment comment, ApplicationDBContext DBcontext)
//    {
//        _comment = comment;
//        _DBcontext = DBcontext;
//    }

//    public async Task AddCommentAsync(Comment comment)
//    {
//        _DBcontext.Comments.Add(comment);
//        await _DBcontext.SaveChangesAsync();
//    }
//    public async Task CreateTutorCommentAsync(string commentText, DateTime time, int tutorId)
//    {
//        var comment = new Comment
//        {
//            commentText = commentText,
//            time = time,
//            userType = "Tutor",
//            tutId = tutorId
//        };

//        await _comment.AddCommentAsync(comment);
//    }

//    public async Task CreateStudentCommentAsync(string commentText, DateTime time, int studentId)
//    {
//        var comment = new Comment
//        {
//            commentText = commentText,
//            time = time,
//            userType = "Student",
//            stuId = studentId
//        };

//        await _comment.AddCommentAsync(comment);
//    }
//    //get all the comments
//    public async Task<List<Comment>> GetAllComments()
//    {
//        return await _DBcontext.Comments.ToListAsync();
//    }
//}