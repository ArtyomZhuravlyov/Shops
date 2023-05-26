using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Contracts.Dto.Metrics.TotalStock
{
    public class MetricTotalStockDto
    {
        public TotalStockAgrDto TotalStockAgr { get; set; }
        public List<TotalStockDto> TotalStocks { get; set; }
    }
}
