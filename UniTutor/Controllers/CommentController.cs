//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using UniTutor.DTO;
//using UniTutor.Interface;

//[ApiController]
//[Route("[controller]")]
//public class CommentController : ControllerBase
//{
//    private readonly IComment _comment;

//    public CommentController(IComment comment)
//    {
//        _comment = comment;
//    }

//    [HttpPost("create/tutor/{tutorId}")]
//    public async Task<IActionResult> CreateTutorComment(int tutorId, [FromBody] CreateComment createCommentDto)
//    {
//        await _comment.CreateTutorCommentAsync(createCommentDto.commentText, createCommentDto.time, tutorId);
//        return Ok();
//    }

//    [HttpPost("create/student/{studentId}")]
//    public async Task<IActionResult> CreateStudentComment(int studentId, [FromBody] CreateComment createComment)
//    {
//        await _comment.CreateStudentCommentAsync(createComment.commentText, createComment.time, studentId);
//        return Ok();
//    }
//    //get all the comments
//    [HttpGet("getallcomments")]
//    public async Task<IActionResult> GetAllComments()
//    {
//        var comments = await _comment.GetAllComments();
//        return Ok(comments);
//    }


//}
