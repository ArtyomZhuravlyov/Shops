using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shops.Contracts.Dto.Country;
using Shops.Contracts.Dto.Shop;
using Shops.DataAccess;
using Shops.DataAccess.Entities;
using Shops.Server.Interfaces;

namespace Shops.Server.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CountryService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CountryDto>> GetAll()
        {
            var countries = await _context.Countries
                .AsNoTracking()
                .Select(x => _mapper.Map<CountryDto>(x))
                .ToListAsync();

            return countries;
        }

        public async Task<CountryDto> GetById(int id)
        {
            var country = await _context.Countries
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<CountryDto>(x))
                .FirstOrDefaultAsync();

            return country;
        }

    }
}
