using Microsoft.EntityFrameworkCore;
using Shops.Contracts.Dto.Category;
using Shops.Contracts.Dto.Country;
using Shops.Contracts.Dto.Metrics;
using Shops.Contracts.Dto.Shop;

namespace Shops.Server.Interfaces
{
    public interface IShopService
    {
        public Task<List<ShopDto>> GetAll();
        public Task<ShopDto> GetById(int id);
        public Task<ShopDto> Create(CreateRequestShopDto shop);
        public Task<ShopDto> Update(ShopDto shop);
        public Task<bool> Delete(int id);

        public Task<MetricDto> GetMetric();

    }
}
