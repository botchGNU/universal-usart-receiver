using GUI_Meas_Demo.Model;
using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace CLI_Meas_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //set variables MANUALLY
            int baudRate = 9600;
            string portName = "COM4";
            StopBits stopBits = StopBits.One;
            Parity parity = Parity.None;
            Handshake portHandshake = Handshake.None;


            DeviceInfo deviceInfo = new DeviceInfo();
            deviceInfo.BaudRate = 9600;
            deviceInfo.StopBits = StopBits.One;
            deviceInfo.Parity = Parity.None;
            deviceInfo.Handshake = Handshake.None;

            //save and read device info (testing purpuse)
            DeviceInfoManager.SaveDeviceInfo(@"C:\Users\User\Downloads\myDeviceInfo.json", deviceInfo);
            deviceInfo = DeviceInfoManager.GetDeviceInfo(@"C:\Users\User\Downloads\myDeviceInfo.json");


            //initialize port
            SerialPort devicePort = new SerialPort();
            devicePort.PortName = portName;
            devicePort.BaudRate = deviceInfo.BaudRate;
            devicePort.Parity = deviceInfo.Parity;
            devicePort.StopBits = deviceInfo.StopBits;
            devicePort.Handshake = deviceInfo.Handshake;

            //try open port
            while (true)
            {
                try
                {
                    devicePort.Open(); //try opening port
                    ConsoleLine("[Info] Port opened", ConsoleColor.Blue);
                    readPortLoop(devicePort); //try reading port
                }
                catch (Exception)
                {
                    ConsoleLine("[Error] Failed to OPEN port!", ConsoleColor.Red);
                }

                Thread.Sleep(5000);
            }
        }

        public static void readPortLoop(SerialPort devicePort)
        {
            while (devicePort.IsOpen)
            {
                try
                {
                    
                    char message = (char)devicePort.ReadChar(); //read from device port
                    Console.Write(message); //print received char
                }
                catch (OperationCanceledException) { ConsoleLine("[Error] Operation was cancelled! (Timeout)", ConsoleColor.Red); }
                catch (TimeoutException) { ConsoleLine("[Error] Failed to READ port! (Timeout)", ConsoleColor.Red); }
            }
            ConsoleLine("[Info] Deviceport Closed", ConsoleColor.Blue);
        }

        public static void ConsoleLine(string message, ConsoleColor color)
        {
            Console.WriteLine("");
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteComportList()
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();

            Console.WriteLine("The following serial ports were found:");

            // Display each port name to the console.
            foreach (string port in ports)
            {
                Console.WriteLine(port);
            }
        }
    }
}
