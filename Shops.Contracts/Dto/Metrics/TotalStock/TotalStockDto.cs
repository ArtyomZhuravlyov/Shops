using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Contracts.Dto.Metrics.TotalStock
{
    public class TotalStockDto
    {
        public long TotalStock { get; set; }

        public string NameShop { get; set; }
    }
}
