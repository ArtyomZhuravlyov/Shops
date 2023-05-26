using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shops.InitData;
using Microsoft.EntityFrameworkCore.Storage;
using Shops.InitData.Configs;
using static System.Formats.Asn1.AsnWriter;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using static OfficeOpenXml.ExcelErrorValue;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using System.Reflection.Emit;
using System.Xml.Linq;
using Shops.DataAccess.Entities;

namespace Shops.DataAccess
{
    public class DataContext : DbContext
    {
        private readonly FillerData _fdata;
        public DataContext(DbContextOptions<DataContext> options, FillerData fdata) : base(options)
        {
            _fdata = fdata;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasAlternateKey(c => c.Code); 

            _fdata.FillInitialDate(modelBuilder);
        }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Stock> Stocks { get; set; }


    }
}
