using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shops.Contracts.Dto.Shop;

namespace Shops.Contracts.Dto.Stock
{
    public class StockDto
    {
        public int Id { get; set; }

        public long Backstore { get; set; }

        public long Frontstore { get; set; }

        public int ShoppingWindow { get; set; }

        public float Accuracy { get; set; }

        public float OnFloorAvailability { get; set; }

        public int MeanAge { get; set; }

        //public int ShopId { get; set; }
        //public ShopDto Shop { get; set; }
    }
}
