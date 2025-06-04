using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityBreaks.Web.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly CityBreaksContext _context;

        public PropertyService(CityBreaksContext context)
        {
            _context = context;
        }

        public async Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string cityName, string propertyName)
        {
            IQueryable<Property> query = _context.Properties
                .Include(p => p.City)
                .Where(p => p.DeletedAt == null);

            if (minPrice.HasValue)
                query = query.Where(p => p.PricePerNight >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.PricePerNight <= maxPrice.Value);

            if (!string.IsNullOrWhiteSpace(cityName))
            {
                var cityNameLower = cityName.Trim().ToLower();
                query = query.Where(p => p.City.Name.ToLower().Contains(cityNameLower));
            }

            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                var propertyNameLower = propertyName.Trim().ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(propertyNameLower));
            }

            return await query.ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null)
                return false;

            property.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
