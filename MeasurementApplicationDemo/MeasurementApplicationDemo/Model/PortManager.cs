using System;
using System.IO.Ports;

namespace GUI_Meas_Demo.Model
{
    public class PortManager
    {
        private bool _isDeviceInfoUpdated = false;
        private DeviceInfo _info;
        private SerialPort _port = new SerialPort();


        void UpdateInfo()
        {
            try
            {
                _port.BaudRate = _info.BaudRate;
                _port.StopBits = _info.StopBits;
                _port.Parity = _info.Parity;
                _port.Handshake = _info.Handshake;
                IsDeviceInfoUpdated = true;
            }
            catch (Exception)
            {
                Notification.Show("Error", "Device info could not be updated!", Notifications.Wpf.NotificationType.Error);
            }
        }

        public bool IsRequiredInfoSet() //check if requiored info is set in order to open port
        {
            if (_port.BaudRate <= 0) { return false; }
            if (String.IsNullOrEmpty(_port.PortName)) { return false; }
            if (!IsDeviceInfoUpdated) { return false; }

            IsDeviceInfoUpdated = true;
            Notification.Show("Succes", "Device info updated!", Notifications.Wpf.NotificationType.Success);
            return true;

            //default values
            //stopbits 1
            //parity none
            //handshake none
        }

        public bool IsPortOpenable() //check if port can be opened and closed without any exception
        {
            try
            {
                _port.Open();
                _port.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ClosePort()
        {
            _port.Close();
        }

        public void OpenPort()
        {
            try
            {
                _port.Open();
            }
            catch (Exception)
            {
                Notification.Show("Error", "Port could not be opened!", Notifications.Wpf.NotificationType.Error);
            }
            
        }

        public int ReadChar()
        {
            return _port.ReadChar();
        }

        public DeviceInfo Info { get => _info; set { _info = value; UpdateInfo(); } } //also updates port
        public string PortName { get => _port?.PortName; set => _port.PortName = value; }
        public bool IsDeviceInfoUpdated { get => _isDeviceInfoUpdated; set => _isDeviceInfoUpdated = value; }
    }
}
