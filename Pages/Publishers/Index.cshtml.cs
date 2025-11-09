using lorena_bodnarescu_lab2.ultimul.Data;
using lorena_bodnarescu_lab2.ultimul.Models;
using lorena_bodnarescu_lab2.ultimul.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lorena_bodnarescu_lab2.ultimul.Pages.Publisher
{
    public class IndexModel : PageModel
    {
        private readonly lorena_bodnarescu_lab2.ultimul.Data.lorena_bodnarescu_lab2Context _context;

        public IndexModel(lorena_bodnarescu_lab2.ultimul.Data.lorena_bodnarescu_lab2Context context)
        {
            _context = context;
        }

        public IList<lorena_bodnarescu_lab2.ultimul.Models.Publisher> Publishers { get; set; } = default!;

        public IList<lorena_bodnarescu_lab2.ultimul.Models.Publisher> Publisher { get; set; } = default!;

        public PublisherIndexData PublisherData { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            PublisherData = new PublisherIndexData();
            PublisherData.Publishers = await _context.Publisher
            .Include(i => i.Books)
            .ThenInclude(c => c.Author)
            .OrderBy(i => i.PublisherName)
            .ToListAsync();
            if (id != null)
            {
                PublisherID = id.Value;
                lorena_bodnarescu_lab2.ultimul.Models.Publisher publisher = PublisherData.Publishers
                .Where(i => i.ID == id.Value).Single();
                PublisherData.Books = publisher.Books;
            }
        }
    }
}
