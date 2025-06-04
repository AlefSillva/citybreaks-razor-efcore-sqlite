using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace CityBreaks.Web.Pages
{
    public class CreatePropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;

        public CreatePropertyModel(CityBreaksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property NewProperty { get; set; }

        public SelectList CitiesSelectList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            CitiesSelectList = new SelectList(
                await _context.Cities.OrderBy(c => c.Name).ToListAsync(),
                "Id",
                "Name"
            );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                CitiesSelectList = new SelectList(
                    await _context.Cities.OrderBy(c => c.Name).ToListAsync(),
                    "Id",
                    "Name"
                );
                return Page();
            }

            await _context.Properties.AddAsync(NewProperty);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
