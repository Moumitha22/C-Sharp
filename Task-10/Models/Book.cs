using System.ComponentModel.DataAnnotations;

namespace Task_10.Models
{
    public class Book
    {
        public int Id { get; set; } // Primary Key
        [Required]
        [StringLength(100, ErrorMessage = "Title length can't be more than 100 characters.")]
        public string Title { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Author name can't be more than 100 characters.")]
        public string Author { get; set; }
        public int PublishedYear { get; set; }
    }
}
