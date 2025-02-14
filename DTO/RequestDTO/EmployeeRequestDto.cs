using System.ComponentModel.DataAnnotations;

namespace DotNetCRUD.DTO.RequestDTO
{
    public class EmployeeRequestDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Position { get; set; } = string.Empty;

        [Required]
        [Range(1000, 1000000)]
        public decimal Salary { get; set; }
    }
}
