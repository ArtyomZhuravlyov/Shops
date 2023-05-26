using Shops.Contracts.Dto.Metrics.AccuracyStock;
using Shops.Contracts.Dto.Metrics.MeanAgeStock;
using Shops.Contracts.Dto.Metrics.OnFloorAvailStock;
using Shops.Contracts.Dto.Metrics.TotalStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Contracts.Dto.Metrics
{
    public class MetricDto
    {
        public MetricTotalStockDto MetricTotalStock { get; set; }
        public MetricAccuracyStockDto MetricAccuracy { get; set; }
        public MetricOnFloorStockDto MetricOnFloorStock { get; set; }
        public MetricMeanAgeStockDto MetricMeanAgeStock { get; set; }
    }
}
