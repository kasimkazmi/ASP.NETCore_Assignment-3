using System.ComponentModel.DataAnnotations;

namespace Assignment03.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? PurchaseHistory { get; set; }
        public string? ShippingAddress { get; set; }

      
    }
}
