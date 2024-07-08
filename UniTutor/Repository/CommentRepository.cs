
﻿using Microsoft.EntityFrameworkCore;
using UniTutor.DataBase;
using UniTutor.Interface;
using UniTutor.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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

        // Set CreatedAt to local time
        TimeZoneInfo localZone = TimeZoneInfo.FindSystemTimeZoneById("Sri Lanka Standard Time"); // Change to your local time zone
        DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, localZone);

        var comment = new Comment
        {
            commentText = commentText,
            Date = localDateTime,
            userType = "Tutor",
            tutId = tutorId

        };

        await AddCommentAsync(comment);
    }

    public async Task CreateStudentCommentAsync(string commentText, DateTime time, int studentId)
    {

        // Set CreatedAt to local time
        TimeZoneInfo localZone = TimeZoneInfo.FindSystemTimeZoneById("Sri Lanka Standard Time"); // Change to your local time zone
        DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, localZone);

        var comment = new Comment
        {
            commentText = commentText,
            Date = localDateTime,

            userType = "Student",
            stuId = studentId
        };

        await AddCommentAsync(comment);
    }


    public IEnumerable<Comment> GetAllComments()
    {
        return _DBcontext.Comments
            .Include(c => c.Student)
            .Include(c => c.Tutor)
            .ToList();
    }
}

