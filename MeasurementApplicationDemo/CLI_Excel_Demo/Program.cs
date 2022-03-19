using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace CLI_Excel_Demo
{
    public class Program
    {
        

        static async Task Main(string[] args)
        {
            var _measList = GetMeasurements();
            var _fileInfo = new FileInfo(@"C:\Users\Tim\Desktop\Test.xlsx");

            await ExcelConverter.ExportAsync(_fileInfo, _measList);
        }

        public static ObservableCollection<Measurement> GetMeasurements()
        {
            var measList = new ObservableCollection<Measurement>();

            for (int i = 0; i < 11; i++)
            {
                var newMeas = new Measurement(i);
                measList.Add(newMeas);
            }

            return measList;
        }
    }
}
