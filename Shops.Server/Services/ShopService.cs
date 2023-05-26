using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shops.Contracts.Dto.Metrics;
using Shops.Contracts.Dto.Metrics.AccuracyStock;
using Shops.Contracts.Dto.Metrics.MeanAgeStock;
using Shops.Contracts.Dto.Metrics.OnFloorAvailStock;
using Shops.Contracts.Dto.Metrics.TotalStock;
using Shops.Contracts.Dto.Shop;
using Shops.DataAccess;
using Shops.DataAccess.Entities;
using Shops.Server.Interfaces;

namespace Shops.Server.Services
{
    public class ShopService : IShopService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ShopService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ShopDto>> GetAll()
        {
            var shops = await _context.Shops
                .Include(x => x.Manager)
                .Include(x => x.Category)
                .Include(x => x.Country)
                .Include(x => x.Stock)
                .AsNoTracking()
                .Select(x => _mapper.Map<ShopDto>(x))
                .ToListAsync();

            return shops;
        }

        public async Task<ShopDto> GetById(int id)
        {
            var shop = await _context.Shops
                .Include(x => x.Manager)
                .Include(x => x.Category)
                .Include(x => x.Country)
                .Include(x => x.Stock)
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<ShopDto>(x))
                .FirstOrDefaultAsync();

            return shop;
        }

        public async Task<ShopDto> Create(CreateRequestShopDto shop)
        {
            var addShop = _mapper.Map<Shop>(shop);
            addShop.Country = await _context.Countries
                .FirstOrDefaultAsync(x => x.Id == shop.Country.Id);

            addShop.Category = await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == shop.Category.Id);

            await _context.Shops.AddAsync(addShop);
            await _context.SaveChangesAsync();

            return _mapper.Map<ShopDto>(addShop);
        }

        public async Task<ShopDto> Update(ShopDto shop)
        {
            var rshop = await _context.Shops
                .Include(x => x.Manager)
                .Include(x => x.Category)
                .Include(x => x.Country)
                .Include(x => x.Stock)
                .FirstOrDefaultAsync(x => x.Id == shop.Id);

            if (rshop == null)
                return null;

            _mapper.Map(shop, rshop);
            rshop.CountryId = shop.Country.Id;
            rshop.CategoryId = shop.Category.Id;


            await _context.SaveChangesAsync();

            return _mapper.Map<ShopDto>(rshop);
        }

        public async Task<bool> Delete(int id)
        {
            var rshop = await _context.Shops
                .FirstOrDefaultAsync(x => x.Id == id);

            if (rshop == null)
                return false;

            _context.Remove(rshop);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<MetricDto> GetMetric()
        {
            MetricDto metric = new MetricDto()
            {
                MetricTotalStock = await GetMetricTotalStock(),
                MetricAccuracy = await GetAccuracyStock(),
                MetricOnFloorStock = await GetOnFloorStock(),
                MetricMeanAgeStock = await GetMeanAgeStock()
            };

            return metric;
        }

        private async Task<MetricTotalStockDto> GetMetricTotalStock()
        {
            var totalStocks = await _context.Shops
              .Include(x => x.Stock)
              .Select(x => new TotalStockDto()
              {
                  NameShop = x.Name,
                  TotalStock = x.Stock.Backstore + x.Stock.Frontstore + x.Stock.ShoppingWindow
              })
              .AsNoTracking()
              .ToListAsync();

            var metricTotalStock = new MetricTotalStockDto()
            {
                TotalStockAgr = new TotalStockAgrDto()
                {
                    Min = totalStocks.Min(x => x.TotalStock),
                    Avg = totalStocks.Average(x => x.TotalStock),
                    Max = totalStocks.Max(x => x.TotalStock)
                },
                TotalStocks = totalStocks,
            };
            return metricTotalStock;
        }

        private async Task<MetricAccuracyStockDto> GetAccuracyStock()
        {
            var accuracy = await _context.Shops
                .Include(x => x.Stock)
                .Select(x => new AccuracyStockDto()
                {
                    NameShop = x.Name,
                    AccuracyStock = x.Stock.Accuracy
                })
                .AsNoTracking()
                .ToListAsync();

            var metricAccuracy = new MetricAccuracyStockDto()
            {
                AccuracyStockAgr = new AccuracyStockAgrDto()
                {
                    Min = accuracy.Min(x => x.AccuracyStock),
                    Avg = accuracy.Average(x => x.AccuracyStock),
                    Max = accuracy.Max(x => x.AccuracyStock)
                },
                AccuracyStocks = accuracy
            };
            return metricAccuracy;
        }

        private async Task<MetricOnFloorStockDto> GetOnFloorStock()
        {
            var onFloorAvail = await _context.Shops
               .Include(x => x.Stock)
               .Select(x => new OnFloorStockDto()
               {
                   NameShop = x.Name,
                   OnFloorStock = x.Stock.OnFloorAvailability
               })
               .AsNoTracking()
               .ToListAsync();

            var metricOnFloor = new MetricOnFloorStockDto()
            {
                OnFloorStockAgr = new OnFloorStockAgrDto()
                {
                    Min = onFloorAvail.Min(x => x.OnFloorStock),
                    Avg = onFloorAvail.Average(x => x.OnFloorStock),
                    Max = onFloorAvail.Max(x => x.OnFloorStock)
                },
                OnFloorStocks = onFloorAvail
            };
            return metricOnFloor;
        }

        private async Task<MetricMeanAgeStockDto> GetMeanAgeStock()
        {
            var meanAge = await _context.Shops
               .Include(x => x.Stock)
               .Select(x => new MeanAgeStockDto()
               {
                   NameShop = x.Name,
                   MeanAgeStock = x.Stock.MeanAge
               })
               .AsNoTracking()
               .ToListAsync();

            var metricMeanAge = new MetricMeanAgeStockDto()
            {
                MeanAgeStockAgr = new MeanAgeStockAgrDto()
                {
                    Min = meanAge.Min(x => x.MeanAgeStock),
                    Avg = meanAge.Average(x => x.MeanAgeStock),
                    Max = meanAge.Max(x => x.MeanAgeStock)
                },
                MeanAgeStock = meanAge
            };
            return metricMeanAge;
        }
    }
}
