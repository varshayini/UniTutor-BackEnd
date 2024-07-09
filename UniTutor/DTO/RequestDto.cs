using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniTutor.DTO
{
    public class RequestDto
    {
       
        public int subjectRequestId { get; set; }

        public int subjectId { get; set; }

        public int studentId { get; set; }
        public int tutorId { get; set; }
        public string studentEmail { get; set; }

        [Required]
        public DateTime timestamp { get; set; }

    }
}
