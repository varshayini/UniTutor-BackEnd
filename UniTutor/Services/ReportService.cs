//// ReportService.cs
//using System;
//using System.Threading.Tasks;

//using UniTutor.Interface;
//using UniTutor.Repositories;

//namespace UniTutor.Services
//{
//    public class ReportService
//    {
//        private readonly IReport _reportRepository;

//        public ReportService(IReport reportRepository)
//        {
//            _reportRepository = reportRepository;
//        }

//        public async Task SendWarning(int reportId)
//        {
//            var report = await _reportRepository.GetById(reportId);
//            if (report == null)
//                throw new ArgumentException("Report not found");

//            // Send warning logic here (e.g., send email or notification to the reported user)
//            report.isWarningSent = true;
//            await _reportRepository.Update(report);
//        }

//        public async Task SuspendAccount(int reportId)
//        {
//            var report = await _reportRepository.GetById(reportId);
//            if (report == null)
//                throw new ArgumentException("Report not found");

//            // Suspend account logic here
//            report.isSuspended = true;
//            await _reportRepository.Update(report);
//        }

//        public async Task BanAccount(int reportId)
//        {
//            var report = await _reportRepository.GetById(reportId);
//            if (report == null)
//                throw new ArgumentException("Report not found");

//            // Ban account logic here
//            report.isBanned = true;
//            await _reportRepository.Update(report);
//        }
//    }
//}
