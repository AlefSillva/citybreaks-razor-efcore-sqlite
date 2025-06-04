using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace CityBreaks.Web.Pages
{
    public class EditPropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;

        public EditPropertyModel(CityBreaksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property PropertyToEdit { get; set; }

        public SelectList CitiesSelectList { get; set; }

        private async Task LoadCitiesSelectListAsync(int selectedCityId = 0)
        {
            var cities = await _context.Cities
                .OrderBy(c => c.Name)
                .ToListAsync();
            CitiesSelectList = new SelectList(cities, "Id", "Name", selectedCityId);
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            PropertyToEdit = await _context.Properties
                .Where(p => p.DeletedAt == null)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (PropertyToEdit == null)
                return NotFound();

            await LoadCitiesSelectListAsync(PropertyToEdit.CityId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadCitiesSelectListAsync(PropertyToEdit.CityId);
                return Page();
            }

            var propertyToUpdate = await _context.Properties
                .Where(p => p.DeletedAt == null)
                .FirstOrDefaultAsync(p => p.Id == PropertyToEdit.Id);

            if (propertyToUpdate == null)
                return NotFound();

            if (await TryUpdateModelAsync<Property>(
                propertyToUpdate,
                "PropertyToEdit",
                p => p.Name, p => p.PricePerNight, p => p.CityId))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            await LoadCitiesSelectListAsync(propertyToUpdate.CityId);
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);

            if (property == null)
                return NotFound();

            property.DeletedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return RedirectToPage("Index"); 
        }
    }
}
