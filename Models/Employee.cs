using System.ComponentModel.DataAnnotations;

namespace DotNetCRUD.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty;

        [Required]
        public decimal Salary { get; set; }
    }
}
