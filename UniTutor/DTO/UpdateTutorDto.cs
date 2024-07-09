namespace UniTutor.DTO
{
    public class UpdateTutorDto
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string occupation { get; set; }
        public string address { get; set; }
        public string district { get; set; }
        public string phoneNumber { get; set; }
        public string qualifications { get; set; }
        public string cv { get; set; }
        public string? ProfileUrl { get; set; }
    }
}
