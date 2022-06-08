using CascadingDropDownList.Models;

namespace CascadingDropDownList.Services;

public interface ILocationService
{
    Task<List<Country>> GetCountries();
    Task<List<Region>> GetRegions(int countryId);
    Task<List<City>> GetCities(int regionId);
}