using System.ComponentModel.DataAnnotations;

namespace Assignment03.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public string? Products { get; set; }
        public int Quantities { get; set; }
        public int User { get; set; }
    }
}
