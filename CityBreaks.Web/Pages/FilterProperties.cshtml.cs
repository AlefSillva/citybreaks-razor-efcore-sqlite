using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityBreaks.Web.Pages
{
    public class FilterPropertiesModel : PageModel
    {
        private readonly IPropertyService _propertyService;

        public FilterPropertiesModel(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [BindProperty(SupportsGet = true)]
        public decimal? MinPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? MaxPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CityName { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string PropertyName { get; set; } = string.Empty;

        public List<Property> FilteredProperties { get; set; } = new();

        public async Task OnGetAsync()
        {
            if (MinPrice.HasValue || MaxPrice.HasValue ||
                !string.IsNullOrWhiteSpace(CityName) ||
                !string.IsNullOrWhiteSpace(PropertyName))
            {
                FilteredProperties = await _propertyService.GetFilteredAsync(MinPrice, MaxPrice, CityName, PropertyName);
            }
            else
            {
                FilteredProperties = new List<Property>();
            }
        }
    }
}
