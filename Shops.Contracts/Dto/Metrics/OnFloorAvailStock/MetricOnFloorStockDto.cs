using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Contracts.Dto.Metrics.OnFloorAvailStock
{
    public class MetricOnFloorStockDto
    {
        public OnFloorStockAgrDto OnFloorStockAgr { get;set; }

        public List<OnFloorStockDto> OnFloorStocks { get; set; }
    }
}
