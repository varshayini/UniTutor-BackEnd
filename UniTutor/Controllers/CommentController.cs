using Microsoft.AspNetCore.Mvc;
using UniTutor.DTO;
using UniTutor.Interface;
using UniTutor.Model;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly IComment _comment;

    public CommentController(IComment comment)
    {
        _comment = comment;
    }

    [HttpPost("create/tutor/{tutorId}")]
    public async Task<IActionResult> CreateTutorComment(int tutorId, [FromBody] CreateComment createCommentDto)
    {
        await _comment.CreateTutorCommentAsync(createCommentDto.commentText, createCommentDto.time, tutorId);
        return Ok();
    }

    [HttpPost("create/student/{studentId}")]
    public async Task<IActionResult> CreateStudentComment(int studentId, [FromBody] CreateComment createComment)
    {
        await _comment.CreateStudentCommentAsync(createComment.commentText, createComment.time, studentId);
        return Ok();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Comment>> GetAllComments()
    {
        var comments = _comment.GetAllComments()
            .Select(c => new Comment
            {
                Id = c.Id,
                commentText = c.commentText,
                time = c.time,
                fullName = c.userType == "Student" ?
                           $"{c.Student.firstName} {c.Student.lastName}" :
                           $"{c.Tutor.firstName} {c.Tutor.lastName}"
            })
            .ToList();

        return Ok(comments);
    }
}
