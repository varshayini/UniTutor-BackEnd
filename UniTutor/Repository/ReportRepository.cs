////using AutoMapper;
////using Microsoft.EntityFrameworkCore;
////using UniTutor.DataBase;
////using UniTutor.Interface;
////using UniTutor.Model;

////namespace UniTutor.Repository
////{
////    public class ReportRepository : IReport
////    {
////        private ApplicationDBContext _DBcontext;
////        private readonly IConfiguration _config;
////        private readonly IMapper _mapper;

////        public ReportRepository(ApplicationDBContext DBcontext, IConfiguration config, IMapper mapper)
////        {
////            _DBcontext = DBcontext;
////            _config = config;
////            _mapper = mapper;

////        }
////        //get report by id
////        public async Task<Report> GetById(int id)
////        {
////            var report = await _DBcontext.Reports.FindAsync(id);
////            return report;
////        }
////        //create report
////        public async Task<Report> Create(Report report)
////        {
////            _DBcontext.Reports.Add(report);
////            await _DBcontext.SaveChangesAsync();
////            return report;
////        }







////        public async Task<List<Report>> GetAll()
////        {
////            var reports = await _DBcontext.Reports.ToListAsync();
////            return reports;
////        }
////        public async Task SendWarning(int id)
////        {
////            var report = await _DBcontext.Reports.FindAsync(id);
////            if (report != null)
////            {
////                report.IsWarningSent = true;
////                report.WarningSentDate = DateTime.UtcNow;
////                report.ResponseDeadline = DateTime.UtcNow.AddDays(2);
////                await _DBcontext.SaveChangesAsync();
////            }
////        }

////        public async Task SuspendUser(int id)
////        {
////            var report = await _DBcontext.Reports.FindAsync(id);
////            if (report != null)
////            {
////                report.IsSuspended = true;
////                await _DBcontext.SaveChangesAsync();
////            }
////        }

////        public async Task BanUser(int id)
////        {
////            var report = await _DBcontext.Reports.FindAsync(id);
////            if (report != null)
////            {
////                report.IsBanned = true;
////                await _DBcontext.SaveChangesAsync();
////            }
////        }

////        public async Task ResolveReport(int id)
////        {
////            var report = await _DBcontext.Reports.FindAsync(id);
////            if (report != null)
////            {
////                report.IsResolved = true;
////                await _DBcontext.SaveChangesAsync();
////            }
////        }

////        public async Task<bool> SaveChangesAsync()
////        {
////            return (await _DBcontext.SaveChangesAsync() > 0);
////        }
////    }

////}

//using AutoMapper;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using UniTutor.DataBase;
//using UniTutor.Interface;
//using UniTutor.Model;

//namespace UniTutor.Repository
//{
//    public class ReportRepository : IReport
//    {
//        private readonly ApplicationDBContext _DBcontext;
//        private readonly IConfiguration _config;
//        private readonly IMapper _mapper;

//        public ReportRepository(ApplicationDBContext DBcontext, IConfiguration config, IMapper mapper)
//        {
//            _DBcontext = DBcontext;
//            _config = config;
//            _mapper = mapper;
//        }

//        public async Task<Report> GetById(int id)
//        {
//            var report = await _DBcontext.Reports
//                .Include(r => r.Tutor)
//                .Include(r => r.Student)
//                .FirstOrDefaultAsync(r => r._id == id);

//            return report;
//        }

//        public async Task<Report> Create(Report report)
//        {
//            _DBcontext.Reports.Add(report);
//            await _DBcontext.SaveChangesAsync();
//            return report;
//        }

//        public async Task<List<Report>> GetAll()
//        {
//            var reports = await _DBcontext.Reports
//                .Include(r => r.Tutor)
//                .Include(r => r.Student)
//                .ToListAsync();

//            return reports;
//        }

//        public async Task SendWarning(int id)
//        {
//            var report = await GetById(id);
//            if (report != null)
//            {
//                report.IsWarningSent = true;
//                report.WarningSentDate = DateTime.UtcNow;
//                report.ResponseDeadline = DateTime.UtcNow.AddDays(2);
//                await _DBcontext.SaveChangesAsync();
//            }
//        }

//        public async Task SuspendUser(int id)
//        {
//            var report = await GetById(id);
//            if (report != null)
//            {
//                report.IsSuspended = true;
//                await _DBcontext.SaveChangesAsync();
//            }
//        }

//        public async Task BanUser(int id)
//        {
//            var report = await GetById(id);
//            if (report != null)
//            {
//                report.IsBanned = true;
//                await _DBcontext.SaveChangesAsync();
//            }
//        }

//        public async Task ResolveReport(int id)
//        {
//            var report = await GetById(id);
//            if (report != null)
//            {
//                report.IsResolved = true;
//                await _DBcontext.SaveChangesAsync();
//            }
//        }

//        public async Task<bool> SaveChangesAsync()
//        {
//            return (await _DBcontext.SaveChangesAsync() > 0);
//        }
//    }
//}

// ReportRepository.cs
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Mail;
using UniTutor.DataBase;
using UniTutor.Interface;
using UniTutor.Model;
using static UniTutor.Repositories.ReportRepository;


namespace UniTutor.Repositories
{
   
        public class ReportRepository : IReport
        {
            private ApplicationDBContext _DBcontext;
            private readonly IConfiguration _config;
            private readonly IMapper _mapper;

            public ReportRepository(ApplicationDBContext DBcontext, IConfiguration config, IMapper mapper)
            {
                _DBcontext = DBcontext;
                _config = config;
                _mapper = mapper;
            }

            public async Task<Report> Create(Report report)
            {
                _DBcontext.Reports.Add(report);
                await _DBcontext.SaveChangesAsync();
                return report;
            }

            public async Task<Report> GetById(int id)
            {
                return await _DBcontext.Reports.FindAsync(id);
            }

            public async Task<List<Report>> GetAll()
            {
                return await _DBcontext.Reports.ToListAsync();
            }

            public async Task SendWarningEmail(int reportId, string adminMessage)
            {
                var report = await GetById(reportId);
                if (report == null) return;

                report.adminMessage = adminMessage;
                report.isWarningSent = true;
                report.warningDate = DateTime.UtcNow;
                await _DBcontext.SaveChangesAsync();

                // Send email logic
                var client = new SmtpClient("smtp.example.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("admin@example.com", "password"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("admin@example.com"),
                    Subject = "Warning",
                    Body = adminMessage,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(report.receiverMail);

                await client.SendMailAsync(mailMessage);
            }

            public async Task SuspendUser(int reportId)
            {
                var report = await GetById(reportId);
                if (report == null) return;

                report.isSuspended = true;
                report.suspensionDate = DateTime.UtcNow;
                await _DBcontext.SaveChangesAsync();

                // Additional logic to suspend user in your system
            }

            public async Task BanUser(int reportId)
            {
                var report = await GetById(reportId);
                if (report == null) return;

                report.isBanned = true;
                report.banDate = DateTime.UtcNow;
                await _DBcontext.SaveChangesAsync();

                // Additional logic to ban user in your system
            }

            public async Task RestoreUser(int reportId)
            {
                var report = await GetById(reportId);
                if (report == null) return;

                report.isSuspended = false;
                report.isBanned = false;
                report.suspensionDate = null;
                report.banDate = null;
                await _DBcontext.SaveChangesAsync();

                // Additional logic to restore user in your system
            }
        }
    }

