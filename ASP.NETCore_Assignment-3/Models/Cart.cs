namespace ASP.NETCore_Assignment_3.Models
{
    // Represents a shopping cart
    public class Cart
    {
        // Unique identifier for the shopping cart
        public long Id { get; set; }

        // Foreign key to the User entity
        public long UserId { get; set; }

        // Navigation property to the associated User
        public User User { get; set; }

        // Navigation property for the one-to-many relationship with the CartItem class
        public ICollection<CartItem> CartItems { get; set; }
    }
}
