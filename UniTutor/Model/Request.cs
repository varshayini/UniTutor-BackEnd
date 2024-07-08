using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniTutor.Model
{
    public class Request
    {
        [Key]
        public int subjectRequestId { get; set; }

        [Required]
        public int subjectId { get; set; }

        [ForeignKey("Student")]
        [Required]
        public int studentId { get; set; }

        [ForeignKey("Tutor")]
        [Required]
        public int tutorId { get; set; }

        [Required]
        [EmailAddress]
        public string studentEmail { get; set; }

        [Required]
        [StringLength(20)]
        public string status { get; set; } = "PENDING";

        [Required]
        public DateTime timestamp { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Tutor Tutor { get; set; }
    }
}