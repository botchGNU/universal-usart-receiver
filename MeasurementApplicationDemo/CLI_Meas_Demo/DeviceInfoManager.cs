using System.IO;
using System.Text.Json;

namespace GUI_Meas_Demo.Model
{
    internal class DeviceInfoManager
    {
        private static JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true, IgnoreNullValues = false };

        public static DeviceInfo GetDeviceInfo(string path)
        {
            string jsonString;

            using (StreamReader streamReader = new StreamReader(path))
            {
                jsonString = streamReader.ReadToEnd();
                streamReader.Close();
            }

            return JsonSerializer.Deserialize<DeviceInfo>(jsonString, _options);
        }

        public static void SaveDeviceInfo(string path, DeviceInfo deviceInfo)
        {
            string jsonString = JsonSerializer.Serialize(deviceInfo, _options);
            File.WriteAllText(path, jsonString);
        }
    }
}
