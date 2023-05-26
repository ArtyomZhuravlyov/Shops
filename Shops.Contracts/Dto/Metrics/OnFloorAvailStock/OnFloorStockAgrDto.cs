using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Contracts.Dto.Metrics.OnFloorAvailStock
{
    public class OnFloorStockAgrDto
    {
        public float Min { get; set; }

        public float Avg { get; set; }

        public float Max { get; set; }
    }
}
