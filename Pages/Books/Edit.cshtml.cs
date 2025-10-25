using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lorena_bodnarescu_lab2.ultimul.Data;
using lorena_bodnarescu_lab2.ultimul.Models;

namespace lorena_bodnarescu_lab2.ultimul.Pages.Books
{
    public class EditModel : BookCategoriesPageModel
    {
        private readonly lorena_bodnarescu_lab2.ultimul.Data.lorena_bodnarescu_lab2ultimulContext _context;

        public EditModel(lorena_bodnarescu_lab2.ultimul.Data.lorena_bodnarescu_lab2ultimulContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Se include Author conform cerinței din laborator
            Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories).ThenInclude(b => b.Category)
                .Include(b => b.Author)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }

            // PopulateAssignedCategoryData pentru checkbox-urile de categorii
            PopulateAssignedCategoryData(_context, Book);


            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });

            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, string[] selectedCategories)
        {
            var bookToUpdate = await _context.Book
                .Include(b => b.BookCategories)
                .FirstOrDefaultAsync(b => b.ID == id);

            if (bookToUpdate == null) return NotFound();

            // Actualizează titlu, preț, etc.
            if (await TryUpdateModelAsync<Book>(
                bookToUpdate,
                "Book",
                b => b.Title, b => b.Price, b => b.PublishingDate, b => b.PublisherID, b => b.AuthorID))
            {
                // Șterge vechile categorii
                bookToUpdate.BookCategories.Clear();

                // Adaugă categoriile selectate
                if (selectedCategories != null)
                {
                    foreach (var catId in selectedCategories)
                    {
                        bookToUpdate.BookCategories.Add(new BookCategory
                        {
                            BookID = bookToUpdate.ID,
                            CategoryID = int.Parse(catId)
                        });
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Dacă apare eroare, re-populează lista pentru view
            var allCategories = await _context.Category.ToListAsync();
            AssignedCategoryDataList = allCategories.Select(c => new AssignedCategoryData
            {
                CategoryID = c.ID,
                CategoryName = c.CategoryName,
                Assigned = selectedCategories != null && selectedCategories.Contains(c.ID.ToString())
            }).ToList();

            return Page();
        }


    }
}