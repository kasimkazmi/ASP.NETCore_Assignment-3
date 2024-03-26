namespace ASP.NETCore_Assignment_3.Models
{
    // Represents an Order made by User for a Product
    public class Order
    {
        // The unique Id for an order
        public long Id { get; set; }

        // Foreign key for the Product
        public long ProductId { get; set; }

        // Navigation property for the Product
        public Product Product { get; set; }

        // Foreign key for the User
        public long UserId { get; set; }

        // Navigation property for the User
        public User User { get; set; }

        // The quantity of the Product being ordered
        public int Quantity { get; set; }

        // The time the order was made
        public DateTimeOffset? OrderDateTime { get; set; }
    }
}



