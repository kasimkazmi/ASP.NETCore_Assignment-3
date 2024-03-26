namespace ASP.NETCore_Assignment_3.Models
{
    // Represents a user account
    public class User
    {
        // Unique identifier for the user
        public long Id { get; set; }

        // The user's email address
        public string Email { get; set; }

        // The user's password
        public string Password { get; set; }

        // The user's username
        public string Username { get; set; }

        // The user's purchase history
        public ICollection<Order> PurchaseHistory { get; set; }

        // The user's shipping address
        public Address ShippingAddress { get; set; }

        // Foreign key to the user's shipping address
        public int? ShippingAddressId { get; set; }

        // The user's billing address
        public Address BillingAddress { get; set; }

        // Foreign key to the user's billing address
        public int? BillingAddressId { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
