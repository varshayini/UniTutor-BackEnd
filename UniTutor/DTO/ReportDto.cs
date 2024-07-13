using System.ComponentModel.DataAnnotations;

namespace UniTutor.DTO
{
    public class ReportDto
    {

        public string senderMail { get; set; } // Email of the reporter
        public string receiverMail { get; set; } // Email of the reported user
        public string description { get; set; }
        public DateTime? date { get; set; }
    }
}
