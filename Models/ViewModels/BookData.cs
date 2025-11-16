using System.Collections.Generic;
using lorena_bodnarescu_lab2.ultimul.Models;

namespace lorena_bodnarescu_lab2.ultimul.ViewModels
{
    public class BookData
    {
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
