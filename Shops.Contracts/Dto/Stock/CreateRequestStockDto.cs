using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shops.Contracts.Dto.Category;
using Shops.Contracts.Dto.Country;
using Shops.Contracts.Dto.Manager;
using Shops.Contracts.Dto.Shop;
using Shops.Contracts.Dto.Stock;

namespace Shops.Contracts.Dto.Stock
{
    public class CreateRequestStockDto
    {
        [Required]
        public long Backstore { get; set; }
        [Required]
        public long Frontstore { get; set; }
        [Required]
        public int ShoppingWindow { get; set; }
        [Required]
        public float Accuracy { get; set; }
        [Required]
        public float OnFloorAvailability { get; set; }
        [Required]
        public int MeanAge { get; set; }

    }
}
