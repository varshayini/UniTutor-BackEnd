using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniTutor.Model
{
    public class TodoItem
    {
        [Key]
        public int _id { get; set; }
        public string text { get; set; }
        public bool isCompleted { get; set; } = false;

        [ForeignKey("Student")]
 
        public int? studentId { get; set; }

        [ForeignKey("Tutor")]
        
        public int? tutorId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Tutor Tutor { get; set; }

    }
}
