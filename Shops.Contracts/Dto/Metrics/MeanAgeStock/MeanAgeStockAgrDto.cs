using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Contracts.Dto.Metrics.MeanAgeStock
{
    public class MeanAgeStockAgrDto
    {
        public int Min { get; set; }

        public double Avg { get; set; }

        public int Max { get; set; }
    }
}
