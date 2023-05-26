using Microsoft.EntityFrameworkCore;
using System;

namespace Shops.DataAccess.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Stock Stock { get; set; }
        public Manager Manager { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}