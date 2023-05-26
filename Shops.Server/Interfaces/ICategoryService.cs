using Microsoft.EntityFrameworkCore;
using Shops.Contracts.Dto.Category;

namespace Shops.Server.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> GetAll();
        public Task<CategoryDto> GetById(int id);

    }
}
