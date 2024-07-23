namespace StudentAdminPortal.Models
{
    // DTO for creating a student
    public class CreateStudentDto
    {
        // Required property for the student's name
        public required string Name { get; set; }

        // Required property for the student's email
        public required string Email { get; set; }

        // Optional property for the student's phone number
        public string? Phone { get; set; }

        // Property to indicate if the student is subscribed
        public bool Subscribed { get; set; }
    }
}
