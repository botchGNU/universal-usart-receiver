using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace GUI_Meas_Demo.Model
{
    class DeviceInfo
    {
        private int _baudRate;
        private StopBits _stopBits;
        private Parity _parity;
        private Handshake handshake;

        #region properties
        public int BaudRate { get => _baudRate; set => _baudRate = value; }
        public StopBits StopBits { get => _stopBits; set => _stopBits = value; }
        public Parity Parity { get => _parity; set => _parity = value; }
        public Handshake Handshake { get => handshake; set => handshake = value; }
        #endregion
    }
}
