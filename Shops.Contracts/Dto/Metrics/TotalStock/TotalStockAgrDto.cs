using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Contracts.Dto.Metrics.TotalStock
{
    public class TotalStockAgrDto
    {
        public long Min { get; set; }

        public double Avg { get; set; }

        public long Max { get; set; }
    }
}
