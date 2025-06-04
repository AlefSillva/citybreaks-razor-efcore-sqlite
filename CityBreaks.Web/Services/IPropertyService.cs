using CityBreaks.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityBreaks.Web.Services
{
    public interface IPropertyService
    {
        Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string cityName, string propertyName);
        Task<bool> DeleteAsync(int id);
    }
}
