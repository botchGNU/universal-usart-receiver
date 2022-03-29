using System.Collections.ObjectModel;
using System.IO;

namespace GUI_Meas_Demo.Model
{
    class SaveManager
    {
        private ObservableCollection<Measurement> _collection;

        public SaveManager(ObservableCollection<Measurement> collection)
        {
            _collection = collection;
        }

        private void SaveToCsv(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(
                    "# Time,Value");
                foreach (var item in _collection)
                {
                    writer.WriteLine(item.Serialize());
                }
                writer.Close();
            }
        }
    }
}
