using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shops.Contracts.Dto.Shop;

namespace Shops.Contracts.Dto.Country
{
    public class CountryDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
       
        public string Code { get; set; }
    }
}
