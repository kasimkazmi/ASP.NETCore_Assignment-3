using System.ComponentModel.DataAnnotations;

namespace Assignment03.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public string? Product { get; set; }
        public string? User { get; set; }
        public string? Rating { get; set; }
        public string? Image { get; set; }
        public string? Text { get; set; }
    }
}
