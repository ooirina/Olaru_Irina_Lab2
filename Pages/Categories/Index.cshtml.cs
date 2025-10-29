using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Olaru_Irina_Lab2.Data;
using Olaru_Irina_Lab2.Models;
using Olaru_Irina_Lab2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olaru_Irina_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Olaru_Irina_Lab2.Data.Olaru_Irina_Lab2Context _context;

        public IndexModel(Olaru_Irina_Lab2.Data.Olaru_Irina_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;
        public CategoryIndexData CategoryData { get; set; } = new CategoryIndexData();

        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .AsNoTracking()
                .ToListAsync();



            if (id != null)
            {
                CategoryID = id.Value;
                var selectedCategory = CategoryData.Categories
                    .Where(c => c.ID == id.Value)
                    .Single();

                CategoryData.Books = selectedCategory.BookCategories
                    .Select(bc => bc.Book);
            }
        }
    }
}
