using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniTutor.Model
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public string location { get; set; }
        public string[] medium { get; set; }
        public string[] availability { get; set; }
        public string[] mode { get; set; }
        public bool status { get; set; } = false;
        public int studentId { get; set; }
        public int tutorId { get; set; }
        public string subjectId { get; set; }
        public Tutor Tutor { get; set; }
        public Student Student { get; set; }
        public ICollection<Subject> Subjects { get; set; }



    }
}
