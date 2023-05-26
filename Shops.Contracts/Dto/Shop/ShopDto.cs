using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shops.Contracts.Dto.Category;
using Shops.Contracts.Dto.Country;
using Shops.Contracts.Dto.Manager;
using Shops.Contracts.Dto.Stock;

namespace Shops.Contracts.Dto.Shop
{
    public class ShopDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [ValidateComplexType]
        public StockDto Stock { get; set; }
        [ValidateComplexType]
        public ManagerDto Manager { get; set; }
        //public int CategoryId { get; set; }
        [ValidateComplexType]
        public CategoryDto Category { get; set; }
        //public int CountryId { get; set; }
        [ValidateComplexType]
        public CountryDto Country { get; set; }
    }
}
