using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using lorena_bodnarescu_lab2.ultimul.Models;

namespace lorena_bodnarescu_lab2.ultimul.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public required ICollection<lorena_bodnarescu_lab2.ultimul.Models.Book> Books { get; set; }

    }
}
