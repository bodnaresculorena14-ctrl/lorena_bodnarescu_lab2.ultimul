using lorena_bodnarescu_lab2.ultimul.Models;

namespace lorena_bodnarescu_lab2.ultimul.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Book>? Books { get; set; } = new List<Book>();
    }
}
