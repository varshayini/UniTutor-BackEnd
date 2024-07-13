//using Microsoft.AspNetCore.Mvc;
//using UniTutor.Interface;
//using UniTutor.Model;
//using System;
//using System.Threading.Tasks;
//using UniTutor.DTO;
//using Microsoft.EntityFrameworkCore;
//using UniTutor.Repository;

//namespace UniTutor.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ReportController : ControllerBase
//    {
//        private readonly IReport _report;
//        private readonly ITutor _tutor;
//        private readonly IStudent _student;

//        public ReportController(IReport report, ITutor tutor, IStudent student)
//        {
//            _report = report;
//            _tutor = tutor;
//            _student = student;
//        }

//        // POST api/report/create/{sendermail}/{receivermail}
//        [HttpPost("create/{sendermail}/{receivermail}")]
//        public async Task<ActionResult<Report>> CreateReport(string sendermail, string receivermail, [FromBody] ReportDto reportDto)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            try
//            {
//                // Determine sender
//                var sender = _tutor.GetTutorByEmail(sendermail) ?? (object)_student.GetByMail(sendermail);

//                // Determine receiver
//                var receiver = _tutor.GetTutorByEmail(receivermail) ?? (object)_student.GetByMail(receivermail);

//                // Validate sender and receiver
//                if (sender == null || receiver == null)
//                {
//                    return NotFound("Sender or receiver not found.");
//                }

//                var report = new Report
//                {
//                    senderMail = sendermail,
//                    receiverMail = receivermail,
//                    description = reportDto.description,
//                    date = DateTime.UtcNow
//                };

//                // Assign Tutor or Student to the report
//                if (sender is Tutor senderTutor)
//                {
//                    report.tutorId = senderTutor._id;
//                    report.Tutor = senderTutor;
//                }
//                else if (sender is Student senderStudent)
//                {
//                    report.tutorId = senderStudent._id;
//                    report.Student = senderStudent;
//                }

//                var newReport = await _report.Create(report);
//                return CreatedAtAction(nameof(GetReportById), new { id = newReport._id }, newReport);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new { message = ex.Message, stackTrace = ex.StackTrace });
//            }
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Report>> GetReportById(int id)
//        {
//            var report = await _report.GetById(id);
//            if (report == null)
//            {
//                return NotFound();
//            }
//            return report;
//        }
//        [HttpGet("allreport")]
//        public async Task<ActionResult<Report>> GetAllReport()
//        {
//            var report = await _report.GetAll();
//            if (report == null)
//            {
//                return NotFound();
//            }
//            return Ok(report);
//        }

//        [HttpPost("sendwarning/{id}")]
//        public async Task<IActionResult> SendWarning(int id)
//        {
//            await _report.SendWarning(id);
//            return NoContent();
//        }

//        [HttpPost("suspend/{id}")]
//        public async Task<IActionResult> SuspendUser(int id)
//        {
//            await _report.SuspendUser(id);
//            return NoContent();
//        }

//        [HttpPost("ban/{id}")]
//        public async Task<IActionResult> BanUser(int id)
//        {
//            await _report.BanUser(id);
//            return NoContent();
//        }

//        [HttpPost("resolve/{id}")]
//        public async Task<IActionResult> ResolveReport(int id)
//        {
//            await _report.ResolveReport(id);
//            return NoContent();
//        }
//    }

//}

// ReportController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniTutor.DTO;
using UniTutor.Interface;
using UniTutor.Model;
using UniTutor.Repositories;
using UniTutor.Repository;
using UniTutor.Services;
using static UniTutor.Repositories.ReportRepository;

namespace UniTutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReport _reportRepository;
        private readonly ITutor _tutorRepository;
        private readonly IStudent _studentRepository;
        public ReportController(IReport reportRepository, ITutor tutorRepository, IStudent studentRepository)
        {
            _reportRepository = reportRepository;
            _tutorRepository = tutorRepository;
            _studentRepository = studentRepository;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Report>> CreateReport([FromBody] ReportDto reportDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var report = new Report
            {
                senderMail = reportDto.senderMail,
                receiverMail = reportDto.receiverMail,
                description = reportDto.description,
                date = DateTime.UtcNow
            };

            var newReport = await _reportRepository.Create(report);
            return CreatedAtAction(nameof(GetReportById), new { id = newReport._id }, newReport);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetReportById(int id)
        {
            var report = await _reportRepository.GetById(id);
            if (report == null)
            {
                return NotFound();
            }
            return report;
        }

        [HttpGet("all")]
        public async Task<ActionResult<Report>> GetAllReports()
        {
            var reports = await _reportRepository.GetAll();
            return Ok(reports);
        }

        [HttpPost("send-warning/{id}")]
        public async Task<IActionResult> SendWarningEmail(int id, [FromBody] string adminMessage)
        {
            await _reportRepository.SendWarningEmail(id, adminMessage);
            return NoContent();
        }

        [HttpPost("suspend/{id}")]
        public async Task<IActionResult> SuspendUser(int id)
        {
            await _reportRepository.SuspendUser(id);
            return NoContent();
        }

        [HttpPost("ban/{id}")]
        public async Task<IActionResult> BanUser(int id)
        {
            await _reportRepository.BanUser(id);
            return NoContent();
        }

        [HttpPost("restore/{id}")]
        public async Task<IActionResult> RestoreUser(int id)
        {
            await _reportRepository.RestoreUser(id);
            return NoContent();
        }
    }
}
