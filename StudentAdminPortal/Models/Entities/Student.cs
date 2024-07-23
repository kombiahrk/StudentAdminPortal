namespace StudentAdminPortal.Models.Entities
{
    public class Student
    {
        // Unique identifier for the student
        public Guid Id { get; set; }

        // The name of the student, required field
        public required string Name { get; set; }

        // The email address of the student, required field
        public required string Email { get; set; }

        // The phone number of the student, optional field
        public string? Phone { get; set; }

        // Indicates if the student is subscribed to notifications
        public bool Subscribed { get; set; }
    }
}
