using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using lorena_bodnarescu_lab2.ultimul.Models;

namespace lorena_bodnarescu_lab2.ultimul.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}
