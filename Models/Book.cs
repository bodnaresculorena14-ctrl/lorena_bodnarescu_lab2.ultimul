using lorena_bodnarescu_lab2.ultimul.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lorena_bodnarescu_lab2.ultimul.Models

{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Book Title")]
        public string Title { get; set; }


        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        // relația către Publisher 
        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }

        // relația către Author
        public int? AuthorID { get; set; }
        public Author? Author { get; set; }
    }
}
