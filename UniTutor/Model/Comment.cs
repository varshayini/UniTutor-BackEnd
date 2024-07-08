using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniTutor.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string userType { get; set; }
        public string commentText { get; set; }
        public DateTime time { get; set; }

        // Foreign key to Student or Tutor
        public int? stuId { get; set; }
        public int? tutId { get; set; }

        public Student Student { get; set; }
        public Tutor Tutor { get; set; }

        [NotMapped]
        public string? fullName
        {
            get
            {
                return userType == "Student" ? $"{Student.firstName} {Student.lastName}" : $"{Tutor.firstName} {Tutor.lastName}";
            }
            set { } // Adding a setter allows assigning a value to fullName

        }
    }
}
