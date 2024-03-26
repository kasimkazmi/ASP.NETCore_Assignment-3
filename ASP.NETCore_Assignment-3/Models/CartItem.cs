namespace ASP.NETCore_Assignment_3.Models
{
   
    public class CartItem
    {
        // Identifier for the cart item
        public int Id { get; set; }

        // Navigation property to the Product entity
        public Product Product { get; set; }

        // The quantity of the product in the cart
        public int Quantity { get; set; }

        // Navigation property to the Cart entity
        public Cart Cart { get; set; }

        // Foreign key to the Cart entity
        public int CartId { get; set; }

        // Foreign key to the Product entity
        public int ProductId { get; set; }
        // Navigation property for the many-to-many relationship with the Product entity

        public ICollection<Product> Products { get; set; }

    }
}

// Comments:

// A CartItem represents a single item in a user's shopping cart.
// It has a foreign key relationship to both the Cart and Product entities.
// Each CartItem has a Product property, which is the product being added
// to the cart, and a Quant