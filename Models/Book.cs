using lorena_bodnarescu_lab2.ultimul.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace lorena_bodnarescu_lab2.ultimul.Models
{



    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        public DateTime PublishingDate { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; } = default!;

        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; } = default!;

        public ICollection<Borrowing>? Borrowings { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

    }

}



