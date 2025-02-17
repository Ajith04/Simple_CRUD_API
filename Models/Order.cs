using System.ComponentModel.DataAnnotations;

namespace DotNetCRUD.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        
    }
}
