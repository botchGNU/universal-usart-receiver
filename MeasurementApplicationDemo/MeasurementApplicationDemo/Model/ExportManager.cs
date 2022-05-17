using CLI_Excel_Demo;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GUI_Meas_Demo.Model
{
    public static class ExportManager
    {
        public static async void ExportAsync(ObservableCollection<Measurement> measList)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            string filenameDate = DateTime.Now.Day + "-" + 
                                  DateTime.Now.Month + "-" + 
                                  DateTime.Now.Year + "_" + 
                                  DateTime.Now.Hour + "-" +
                                  DateTime.Now.Minute + "-" +
                                  DateTime.Now.Second + "_" +
                                  "_Measurement.xlsx";

            savefile.FileName = filenameDate;
            savefile.Filter = "Excel Sheet (*.xlsx)|*.xlsx|Binary (*.bin)|*.bin|CSV (*.csv)|*.csv|Database SQLite (*.db)|*.db|XAML (*.xaml)|*.xaml|JSON (*.json)|*.json";

            if (savefile.ShowDialog() == true)
            {
                string fileExt = System.IO.Path.GetExtension(savefile.FileName);

                switch (fileExt.ToLower())
                {
                    case ".csv":    //not tested
                        await ExportCSVAsync(new FileInfo(savefile.FileName), measList);
                        break;

                    case ".json":
                        await ExportJSONAsync(new FileInfo(savefile.FileName), measList);
                        break;

                    case ".xaml":
                        await ExportXAMLAsync(new FileInfo(savefile.FileName), measList);
                        break;

                    case ".xlsx":   //not working ATM
                        await ExcelConverter.ExportAsync(new FileInfo(savefile.FileName), measList);
                        break;

                    case ".bin":
                    case ".binary":
                        await ExportBinAsync(new FileInfo(savefile.FileName), measList);
                        break;

                    case ".db":
                    case ".sqlite":
                        await ExportDatabaseAsync(savefile.FileName, measList);
                        break;
                    default:
                        break;
                }

            }
            OpenFolderOnFile(savefile.FileName);
        }

        private static void OpenFolderOnFile(string folderPath)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string _path = folderPath;
            startInfo.Arguments = string.Format("/C start {0}", _path);
            process.StartInfo = startInfo;
            process.Start();
        }


        
        private static SQLiteConnection CreateSQLiteConnection(string fileName)
        {
            SQLiteConnection conn = new SQLiteConnection($"Data Source={fileName}");
            try
            {
                conn.Open();
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return conn;
        }
        
        #region export Tasks
        public static async Task ExportXAMLAsync(FileInfo fileName, ObservableCollection<Measurement> measList)
        {
            try
            {
                XmlSerializer writer = new XmlSerializer(typeof(ObservableCollection<Measurement>));

                using (StreamWriter file = new StreamWriter(fileName.ToString()))
                {
                    writer.Serialize(file, measList);
                    file.Close();
                }
                Notification.PrintFileMessage(true, fileName.Name);
            }
            catch (Exception)
            {
                Notification.PrintFileMessage(false, fileName.Name);
            }

        }


        private static async Task ExportBinAsync(FileInfo fileName, ObservableCollection<Measurement> measColl)
        {
            try
            {
                Stream str = File.OpenWrite(fileName.ToString());
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(str, measColl);
                str.Close();
                Notification.PrintFileMessage(true, fileName.Name);
            }
            catch (Exception)
            {

                Notification.PrintFileMessage(false, fileName.Name);
            }
        }

        private static async Task ExportJSONAsync(FileInfo fileName, ObservableCollection<Measurement> measColl)
        {
            try
            {
                Newtonsoft.Json.JsonSerializer writer = new Newtonsoft.Json.JsonSerializer();
                writer.Formatting = Formatting.Indented;

                using (StreamWriter wfile = new StreamWriter(fileName.ToString()))
                {
                    writer.Serialize(wfile, measColl);
                    wfile.Close();
                }
                Notification.PrintFileMessage(true, fileName.Name);
            }
            catch (Exception)
            {
                Notification.PrintFileMessage(false, fileName.Name);
            }


        }

        private static async Task ExportCSVAsync(FileInfo fileName, ObservableCollection<Measurement> measColl)
        {
            try
            {
                StreamWriter writer = new StreamWriter(fileName.ToString());

                writer.WriteLine(
                        "TimeStamp,Value");
                foreach (var item in measColl)
                {
                    writer.WriteLine(item.Serialize());
                }
                writer.Close();
                Notification.PrintFileMessage(true, fileName.Name);
            }
            catch (Exception)
            {
                Notification.PrintFileMessage(false, fileName.Name);
            }
        }
        private static async Task ExportDatabaseAsync(string filename, ObservableCollection<Measurement> measColl)
        {



            try
            {
                SQLiteConnection connection = CreateSQLiteConnection(filename);

                SQLiteCommand cmd = new SQLiteCommand(connection);
                cmd.CommandText = "DROP TABLE IF EXISTS measurements";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE measurements(id INTEGER PRIMARY KEY,
                              timestamp TEXT, value INT)";
                cmd.ExecuteNonQuery();

                foreach (Measurement item in measColl)
                {
                    cmd.CommandText = $"INSERT INTO " +
                                    $"measurements(timestamp, value) " +
                                    $"VALUES('{item.TimeStamp}', {(int)item.Value})";
                    cmd.ExecuteNonQuery();
                }

                connection.Close();
                Notification.PrintFileMessage(true, filename);
            }
            catch (Exception)
            {
                Notification.PrintFileMessage(false, filename);
            }


        }
        #endregion

    }
}
