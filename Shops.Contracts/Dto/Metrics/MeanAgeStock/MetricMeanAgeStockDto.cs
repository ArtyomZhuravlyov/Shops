using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Contracts.Dto.Metrics.MeanAgeStock
{
    public class MetricMeanAgeStockDto
    {
        public MeanAgeStockAgrDto MeanAgeStockAgr { get; set; }
        public List<MeanAgeStockDto> MeanAgeStock { get; set; }
    }
}
