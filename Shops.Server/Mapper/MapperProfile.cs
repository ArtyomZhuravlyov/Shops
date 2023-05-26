using AutoMapper;
using Shops.Contracts.Dto.Category;
using Shops.Contracts.Dto.Country;
using Shops.Contracts.Dto.Manager;
using Shops.Contracts.Dto.Shop;
using Shops.Contracts.Dto.Stock;
using Shops.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shops.Server.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Shop, ShopDto>();
            CreateMap<Stock, StockDto>().ReverseMap();
            CreateMap<Manager, ManagerDto>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<ShopDto, Shop>()
                .ForMember(x => x.Country, opt => opt.Ignore())
                .ForMember(x => x.Category, opt => opt.Ignore());


            CreateMap<CreateRequestShopDto, Shop>()
                .ForMember(x => x.Country, opt => opt.Ignore())
                .ForMember(x => x.Category, opt => opt.Ignore());
            CreateMap<CreateRequestStockDto, Stock>();
            CreateMap<CreateRequestManagerDto, Manager>();
            CreateMap<CreateRequestCountryDto, Country>();

        }
    }
}
