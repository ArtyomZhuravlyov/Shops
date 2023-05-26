using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using Shops.DataAccess.Entities;
using Shops.InitData.Configs;
using System.IO;
using System.Reflection.Emit;

namespace Shops.DataAccess
{
    public class FillerData
    {
        private readonly IOptions<InitDataConfig> _config;
        public FillerData(IOptions<InitDataConfig> config)
        {
            _config = config;
        }

        public void FillInitialDate(ModelBuilder modelBuilder)
        {
            string fullPath = $"{Environment.CurrentDirectory}{_config.Value.Path}";
            if (File.Exists(fullPath))
            {
                using (ExcelPackage pck = new ExcelPackage(new FileInfo(fullPath)))
                {
                    ExcelWorksheet listSheet1 = pck.Workbook.Worksheets[0];

                    int fromRow = 2;
                    int toRow = listSheet1.Dimension.End.Row;

                    var countries = FillCountries(modelBuilder, listSheet1, fromRow, toRow);
                    var shops = FillShops(modelBuilder, listSheet1, fromRow, toRow, countries);
                    FillManagers(modelBuilder, listSheet1, fromRow, toRow, shops);
                    FillStocks(modelBuilder, listSheet1, fromRow, toRow, shops);
                    FillCategories(modelBuilder, listSheet1, fromRow, toRow);
                }
            }
        }

        private Dictionary<string, Country> FillCountries(ModelBuilder mb, ExcelWorksheet wsheet, int fromRow, int toRow)
        {
            Dictionary<string, Country> countries = new(toRow);

            for (int i = fromRow; i <= toRow; i++)
            {
                var value = wsheet.Cells[i, 2].Value.ToString();
                int id = 0;

                if (countries.ContainsKey(value))
                    continue;
                else
                {
                    if (countries.Count == 0)
                        id = 1;
                    else
                        id = countries.Last().Value.Id + 1;

                    Country country = new()
                    {
                        Id = id,
                        Code = value
                    };
                    countries.Add(value, country);
                }
            }
            mb.Entity<Country>().HasData(countries.Values);
            return countries;
        }

        private void FillCategories(ModelBuilder mb, ExcelWorksheet wsheet, int fromRow, int toRow)
        {
            Dictionary<int, Category> categories = new(toRow);
            for (int i = fromRow; i <= toRow; i++)
            {
                var value = Convert.ToInt32(wsheet.Cells[i, 7].Value);
                if (categories.ContainsKey(value))
                    continue;
                Category ct = new()
                {
                    Id = value
                };
                categories.Add(value, ct);
            }
            mb.Entity<Category>().HasData(categories.Values);
        }

        private Dictionary<int, Shop> FillShops(ModelBuilder mb, ExcelWorksheet wsheet, int fromRow, int toRow,
            Dictionary<string, Country> countries)
        {
            Dictionary<int, Shop> shops = new(toRow);
            for (int i = fromRow; i <= toRow; i++)
            {
                Shop shop = new()
                {
                    Id = i - 1,
                    Name = wsheet.Cells[i, 1].Value.ToString(),
                    Email = wsheet.Cells[i, 3].Value.ToString(),
                    CountryId = countries[wsheet.Cells[i, 2].Value.ToString()].Id,
                    CategoryId = Convert.ToInt32(wsheet.Cells[i, 7].Value),
                };
                shops.Add(i - 1, shop);
            }
            mb.Entity<Shop>().HasData(shops.Values);
            return shops;
        }

        private void FillManagers(ModelBuilder mb, ExcelWorksheet wsheet, int fromRow, int toRow, Dictionary<int, Shop> shops)
        {
            Dictionary<int, Manager> managers = new(toRow);
            for (int i = fromRow; i <= toRow; i++)
            {
                Manager mn = new()
                {
                    Id = i - 1,
                    FirstName = wsheet.Cells[i, 4].Value.ToString(),
                    LastName = wsheet.Cells[i, 5].Value.ToString(),
                    Email = wsheet.Cells[i, 6].Value.ToString(),
                    ShopId = shops[i - 1].Id
                };
                managers.Add(i - 1, mn);
            }
            mb.Entity<Manager>().HasData(managers.Values);
        }

        private void FillStocks(ModelBuilder mb, ExcelWorksheet wsheet, int fromRow, int toRow, Dictionary<int, Shop> shops)
        {
            Dictionary<int, Stock> stocks = new(toRow);
            for (int i = fromRow; i <= toRow; i++)
            {
                Stock st = new()
                {
                    Id = i - 1,
                    ShopId = shops[i - 1].Id,
                    Backstore = Convert.ToInt64(wsheet.Cells[i, 8].Value),
                    Frontstore = Convert.ToInt64(wsheet.Cells[i, 9].Value),
                    ShoppingWindow = Convert.ToInt32(wsheet.Cells[i, 10].Value),
                    Accuracy = Convert.ToSingle(wsheet.Cells[i, 11].Value),
                    OnFloorAvailability = Convert.ToSingle(wsheet.Cells[i, 12].Value),
                    MeanAge = Convert.ToInt32(wsheet.Cells[i, 13].Value)
                };
                stocks.Add(i - 1, st);
            }
            mb.Entity<Stock>().HasData(stocks.Values);
        }
    }
}