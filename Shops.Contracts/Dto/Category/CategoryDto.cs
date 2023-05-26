using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shops.Contracts.Dto.Shop;

namespace Shops.Contracts.Dto.Category
{
    public class CategoryDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        //public List<ShopDto> Shops { get; set; } = new List<ShopDto>();
    }
}
