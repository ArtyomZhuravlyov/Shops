using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shops.Contracts.Dto.Category;
using Shops.Contracts.Dto.Shop;
using Shops.DataAccess;
using Shops.DataAccess.Entities;
using Shops.Server.Interfaces;

namespace Shops.Server.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CategoryService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var categories = await _context.Categories
                .AsNoTracking()
                .Select(x => _mapper.Map<CategoryDto>(x))
                .ToListAsync();

            return categories;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _context.Categories
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<CategoryDto>(x))
                .FirstOrDefaultAsync();

            return category;
        }

    }
}
