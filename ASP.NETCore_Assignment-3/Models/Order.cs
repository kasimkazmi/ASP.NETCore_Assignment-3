using System.ComponentModel.DataAnnotations;

namespace Assignment03.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string? RecordingOfSale { get; set; }
    }
}
