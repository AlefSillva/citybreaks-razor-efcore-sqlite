using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Services
{
    public class CityService : ICityService
    {
        private readonly CityBreaksContext _context;

        public CityService(CityBreaksContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _context.Cities
                .Include(c => c.Country)
                .Include(c => c.Properties
                    .Where(p => p.DeletedAt == null)) 
                .ToListAsync();
        }

        public async Task<City?> GetByNameAsync(string name)
        {
            return await _context.Cities
                .Include(c => c.Country)
                .Include(c => c.Properties
                    .Where(p => p.DeletedAt == null))
                .FirstOrDefaultAsync(c =>
                    EF.Functions.Collate(c.Name, "NOCASE") == name
                );
        }

        public async Task<bool> DeletePropertyAsync(int propertyId)
        {
            var property = await _context.Properties.FindAsync(propertyId);
            if (property == null)
                return false;

            property.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
