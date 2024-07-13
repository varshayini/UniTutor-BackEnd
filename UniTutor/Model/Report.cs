using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniTutor.Interface;

namespace UniTutor.Model
{
    
        //Report model with senderId, receiverId, discription, and date properties here sender and resever can be tutor or student
        public class Report
        {
            [Key]
            public int _id { get; set; }
            [Required]
            public string senderMail { get; set; } // Reporter
            [Required]
            public string receiverMail { get; set; } // ReportedUser
            [Required]
            public string description { get; set; }
            [Required]
            public DateTime date { get; set; }

            public string adminMessage { get; set; }
            public bool isWarningSent { get; set; }
            public bool isSuspended { get; set; }
            public bool isBanned { get; set; }
            public DateTime? warningDate { get; set; }
            public DateTime? suspensionDate { get; set; }
            public DateTime? banDate { get; set; }

            [ForeignKey("Tutor")]
            public int? tutorId { get; set; }
            public virtual Tutor Tutor { get; set; }

            [ForeignKey("Student")]
            public int? studentId { get; set; }
            public virtual Student Student { get; set; }
        }


    }

