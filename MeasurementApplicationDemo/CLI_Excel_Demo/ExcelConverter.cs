using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace CLI_Excel_Demo
{
    public static class ExcelConverter
    {

        public static async Task ExportAsync(FileInfo fileName, ObservableCollection<Measurement> measColl)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            DeleteIfExists(fileName);

            using var package = new ExcelPackage(fileName);

            var ws = package.Workbook.Worksheets.Add("MainReport");

            var range = ws.Cells["A2"].LoadFromCollection(measColl, true);
            range.AutoFitColumns();

            // Formats the header
            ws.Cells["A1"].Value = "Measurements";
            ws.Cells["A1:C1"].Merge = true;
            ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Row(1).Style.Font.Size = 24;
            ws.Row(1).Style.Font.Color.SetColor(Color.Blue);

            ws.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Row(2).Style.Font.Bold = true;
            ws.Column(3).Width = 20;

            await package.SaveAsync();
        }

        private static void DeleteIfExists(FileInfo fileName)
        {
            if (fileName.Exists)
            {
                fileName.Delete();
            }
        }
    }
}
