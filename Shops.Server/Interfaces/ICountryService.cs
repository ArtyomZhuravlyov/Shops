using Microsoft.EntityFrameworkCore;
using Shops.Contracts.Dto.Category;
using Shops.Contracts.Dto.Country;

namespace Shops.Server.Interfaces
{
    public interface ICountryService
    {
        public Task<List<CountryDto>> GetAll();
        public Task<CountryDto> GetById(int id);

    }
}
