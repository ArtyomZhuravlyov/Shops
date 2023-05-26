
using AutoMapper;
using Shops.Contracts.Dto.Country;
using Shops.Contracts.Dto.Manager;
using Shops.Contracts.Dto.Shop;
using Shops.Contracts.Dto.Stock;

namespace Shops.Client.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<CreateRequestShopDto, ShopDto>().ReverseMap();
            CreateMap<CreateRequestStockDto, StockDto>().ReverseMap();
            CreateMap<CreateRequestManagerDto, ManagerDto>().ReverseMap();
            CreateMap<CreateRequestCountryDto, CountryDto>().ReverseMap();

        }
    }
}
