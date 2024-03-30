using System.ComponentModel.DataAnnotations;

namespace Assignment03.Models
{
    public class Product
    {
        [Key]
        public int ProductId { set; get; }
        public string? Description { set; get; }
        public string? Image { set; get; }
        public double Pricing { set; get; }
        public double ShippingCost { set; get; }
    }
}
