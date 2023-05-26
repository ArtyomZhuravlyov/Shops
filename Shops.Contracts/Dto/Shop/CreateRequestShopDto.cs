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
    public class CreateRequestShopDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [ValidateComplexType]
        public CreateRequestStockDto Stock { get; set; } = new();
        [ValidateComplexType]
        public CreateRequestManagerDto Manager { get; set; } = new();
        [ValidateComplexType]
        public CategoryDto Category { get; set; } = new();
        [ValidateComplexType]
        public CreateRequestCountryDto Country { get; set; } = new();
    }
}
