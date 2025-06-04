using CityBreaks.Web.Models;

public interface ICityService
{
    Task<List<City>> GetAllAsync();
    Task<City?> GetByNameAsync(string name);

    Task<bool> DeletePropertyAsync(int propertyId);
}
