using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace GUI_Meas_Demo.Model
{
    /// <summary>
    /// class to manage DeviceInfo files (load / save)
    /// </summary>
    
    class DeviceInfoManager
    {
        private static JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true, IgnoreNullValues = false };

        public static DeviceInfo GetDeviceInfo(string path)
        {
            string jsonString;

            

            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    jsonString = streamReader.ReadToEnd();
                    streamReader.Close();
                }

                return JsonSerializer.Deserialize<DeviceInfo>(jsonString, _options);
            }
            catch (Exception)
            {
                return new DeviceInfo(); //return empty device info on failure
            }

            
        }

        public static void SaveDeviceInfo(string path, DeviceInfo deviceInfo)
        {
            string jsonString = JsonSerializer.Serialize(deviceInfo, _options);
            File.WriteAllText(path, jsonString);
        }
    }
}
