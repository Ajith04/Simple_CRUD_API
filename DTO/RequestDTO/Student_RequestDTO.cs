namespace DotNetCRUD.DTO.RequestDTO
{
    public class Student_RequestDTO
    {
        public required string StudentFirstName { get; set; }

        public required string StudentLastName { get; set; }

        public DateTime StudentDOB { get; set; }

        public required string StudentPhone { get; set; }

        public required string StudentAddress { get; set; }

        public required string StudentGender { get; set; }

        public required string StudentEmail { get; set; }
    }
}
