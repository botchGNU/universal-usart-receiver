using CLI_Excel_Demo;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;

namespace GUI_Meas_Demo.Model
{
    public static class ExportManager
    {
        public static async void ExportAsync(ObservableCollection<Measurement> measList)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "Measurement.xlsx";
            savefile.Filter = "Excel Sheet (*.xlsx)|*.xlsx|Binary (*.bin)|*.bin|All files (*.*)|*.*";

            if (savefile.ShowDialog() == true)
            {
                string fileExt = System.IO.Path.GetExtension(savefile.FileName);

                switch (fileExt.ToLower())
                {
                    case ".csv":
                        //not implemented yet
                        break;

                    case ".json":
                        //not implemented yet
                        break;

                    case ".xlsx":
                        await ExcelConverter.ExportAsync(new FileInfo(savefile.FileName), measList);
                        break;

                    case ".bin":
                    case ".address":
                        await ExportBinAsync(new FileInfo(savefile.FileName), measList);
                        break;

                    case ".db":
                    case ".sqlite":
                        //not implemented yet
                        break;
                    default:
                        break;
                }

            }  
        }



        private static async Task ExportBinAsync(FileInfo fileName, ObservableCollection<Measurement> measColl)
        {
            Stream str = File.OpenWrite(fileName.ToString());
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(str, measColl);
            str.Close();
        }


    }
}
