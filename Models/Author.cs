using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lorena_bodnarescu_lab2.ultimul.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Display(Name = "Prenume")]
        public string? FirstName { get; set; }

        [Display(Name = "Nume de familie")]
        public string? LastName { get; set; }

        [Display(Name = "Nume complet")]
        public string FullName
        {
            get { return $"{LastName} {FirstName}"; }
        }

        public ICollection<Book>? Books { get; set; }
    }
}
