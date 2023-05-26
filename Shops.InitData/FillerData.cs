using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using Shops.InitData.Configs;
using System.IO;
using System.Reflection.Emit;

namespace Shops.InitData
{
    public class FillerData
    {
        private readonly IOptions<InitDataConfig> _config;
        public FillerData(IOptions<InitDataConfig> config)
        {
            _config = config;
        }

        public void FillModelBuilder(ModelBuilder modelBuilder)
        {
            string fullPath = $"{Environment.CurrentDirectory}{_config.Value.Path}";
            using (ExcelPackage pck = new ExcelPackage(new FileInfo(fullPath)))
            {
                ExcelWorksheet listSheet1 = pck.Workbook.Worksheets[1];
                int numRows = listSheet1.Dimension.End.Row;//Dimension..Rows;
                int numCol = listSheet1.Dimension.End.Column;
            }
        }
    }
}