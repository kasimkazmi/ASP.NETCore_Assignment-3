namespace ASP.NETCore_Assignment_3.Models
{
    public class Product
    {
        // Unique identifier for the product
        public long Id { get; set; }

        // Description of the product
        public string Description { get; set; }

        // Image of the product
        public string Image { get; set; }

        // Price of the product
        public decimal Price { get; set; }

        // Shipping cost of the product
        public decimal ShippingCost { get; set; }

        // A Product can be associated with multiple CartItems
        // Navigation property for the many-to-many relationship with the CartItem class
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}