using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace GUI_Meas_Demo.Model
{
    public class PortManager
    {
        DeviceInfo _info;
        SerialPort _port = new SerialPort();

        void UpdateInfo()
        {
            _port.BaudRate = _info.BaudRate;
            _port.StopBits = _info.StopBits;
            _port.Parity = _info.Parity;
            _port.Handshake = _info.Handshake;
        }

        public bool IsPortOpenable()
        {
            try
            {
                _port.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DeviceInfo Info { get => _info; set { _info = value; UpdateInfo(); } } //also updates port
        public string PortName { get => _port?.PortName; set => _port.PortName = value; }
    }
}
