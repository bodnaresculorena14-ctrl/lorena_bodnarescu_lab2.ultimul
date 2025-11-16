using lorena_bodnarescu_lab2.ultimul.Models;
namespace lorena_bodnarescu_lab2.ultimul.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
