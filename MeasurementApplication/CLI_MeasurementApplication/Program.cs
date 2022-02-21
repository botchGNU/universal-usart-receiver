using System;
using System.IO.Ports;
using System.Threading;

namespace MyApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //set variables MANUALLY
            int baudRate = 16000000;
            StopBits stopBits = StopBits.None;
            Parity parity = Parity.None;
            Handshake portHandshake = Handshake.None;

            int readTimeout = 500;
            int writeTimeout = 500;

            //initialize port
            SerialPort devicePort = new SerialPort();
            devicePort.BaudRate = baudRate;
            devicePort.Parity = parity;
            devicePort.StopBits = stopBits;
            devicePort.Handshake = portHandshake;
            devicePort.ReadTimeout = readTimeout;
            devicePort.WriteTimeout = writeTimeout;

            //try open port
            try
            {
                devicePort.Open();
            }
            catch (Exception)
            {

                Console.WriteLine("Error OPENING port!");
            }

            //try reading port
            readPortLoop(devicePort);
        }

        public static void readPortLoop( SerialPort devicePort)
        {
            while (Console.ReadLine() != "q")
            {
                try
                {
                    string message = devicePort.ReadLine();
                    Console.WriteLine(message);
                }
                catch (TimeoutException) { Console.WriteLine("Error REDING port!"); }
            }
        }
    }
}