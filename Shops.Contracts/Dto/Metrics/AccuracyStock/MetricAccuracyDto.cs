using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Contracts.Dto.Metrics.AccuracyStock
{
    public class MetricAccuracyStockDto
    {
        public AccuracyStockAgrDto AccuracyStockAgr { get; set; }

        public List<AccuracyStockDto> AccuracyStocks { get; set; }
    }
}
