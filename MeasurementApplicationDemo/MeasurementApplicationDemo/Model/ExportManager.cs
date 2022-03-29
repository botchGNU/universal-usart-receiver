using CLI_Excel_Demo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace GUI_Meas_Demo.Model
{
    public static class ExportManager
    {
        public static async void AsExcelAsync(ObservableCollection<Measurement> measList)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "Measurement.xlsx";
            savefile.Filter = "Excel Sheet (*.xlsx)|*.txt|All files (*.*)|*.*";

            savefile.ShowDialog();

            await ExcelConverter.ExportAsync(new FileInfo(savefile.FileName), measList);
        }
    }
}
