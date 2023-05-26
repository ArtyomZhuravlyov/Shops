using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Contracts.Dto.Country
{
    public class CreateRequestCountryDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
