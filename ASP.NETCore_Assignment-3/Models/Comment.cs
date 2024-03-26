namespace ASP.NETCore_Assignment_3.Models
{
    // Represents a comment made by a user on a product.
    public class Comment
    {
        // The unique identifier for the comment
        public long Id { get; set; }

        // The product that the comment is associated with
        public Product Product { get; set; }

        // The foreign key for the product
        public long ProductId { get; set; }

        // The user who made the comment
        public User User { get; set; }

        // The foreign key for the user
        public long UserId { get; set; }

        // The rating given by the user
        public int Rating { get; set; }

        // The images associated with the comment
        public string Images { get; set; }

        // The text of the comment
        public string Text { get; set; }
    }
}