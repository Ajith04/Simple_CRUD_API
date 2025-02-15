namespace DotNetCRUD.DTO.ResponseDTO
{
    public class EmployeeResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
