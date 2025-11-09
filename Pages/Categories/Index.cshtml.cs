using lorena_bodnarescu_lab2.ultimul.Data;
using lorena_bodnarescu_lab2.ultimul.Models;
using lorena_bodnarescu_lab2.ultimul.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lorena_bodnarescu_lab2.ultimul.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly lorena_bodnarescu_lab2.ultimul.Data.lorena_bodnarescu_lab2Context _context;

        public IndexModel(lorena_bodnarescu_lab2.ultimul.Data.lorena_bodnarescu_lab2Context context)
        {
            _context = context;
        }

        public CategoryIndexData CategoryData { get; set; } = new CategoryIndexData();
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                var category = CategoryData.Categories
                    .Where(c => c.ID == id.Value)
                    .Single();
                CategoryData.Books = category.BookCategories.Select(bc => bc.Book);
            }
        }
    }
}
