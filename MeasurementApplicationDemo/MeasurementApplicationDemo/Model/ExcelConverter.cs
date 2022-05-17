using GUI_Meas_Demo.Model;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System;
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
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                DeleteIfExists(fileName);

                //calculate chart ranges
                int itemSize = measColl.Count;
                string rangeLabelString = "A3:A" + itemSize;
                string range1String = "B3:B" + itemSize;


                using var package = new ExcelPackage(fileName);

                //create new worksheet
                var ws = package.Workbook.Worksheets.Add("MainReport");

                var range = ws.Cells["A2"].LoadFromCollection(measColl, true);
                range.AutoFitColumns();

                // Formats the header
                ws.Cells["A1"].Value = "Measurements";
                ws.Cells["A1:B1"].Merge = true;
                ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Row(1).Style.Font.Size = 16;
                ws.Row(1).Style.Font.Color.SetColor(Color.DarkBlue);

                ws.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Row(2).Style.Font.Bold = true;
                ws.Column(3).Width = 20;

                //create a new piechart of type Line
                ExcelLineChart lineChart = ws.Drawings.AddChart("lineChart", eChartType.Line) as ExcelLineChart;

                //set the title
                lineChart.Title.Text = "Measurement on " + DateTime.Now.ToString();

                //create the ranges for the chart
                var rangeLabel = ws.Cells[rangeLabelString];
                var range1 = ws.Cells[range1String];

                //add the ranges to the chart
                lineChart.Series.Add(range1, rangeLabel);

                //set the names of the legend
                lineChart.Series[0].Header = "Results ";
                //lineChart.Series[1].Header = worksheet.Cells["A3"].Value.ToString();

                //position of the legend
                lineChart.Legend.Position = eLegendPosition.Right;

                //size of the chart
                lineChart.SetSize(800, 300);

                //allign chart
                lineChart.SetPosition(2, 0, 3, 0);

                await package.SaveAsync();

                Notification.PrintFileMessage(true, fileName.Name);
            }
            catch (Exception)
            {
                Notification.PrintFileMessage(false, fileName.Name);
            }
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
