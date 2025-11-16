using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using lorena_bodnarescu_lab2.ultimul.Models;

namespace lorena_bodnarescu_lab2.ultimul.Models
{
    public class Author
    {
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<Book>? Books { get; set; }


    }
}
