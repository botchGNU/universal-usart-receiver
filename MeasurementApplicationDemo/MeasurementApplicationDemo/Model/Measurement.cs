using System;
using System.Collections.Generic;
using System.Text;

namespace GUI_Meas_Demo.Model
{
    public class Measurement
    {
        private int _value;
        private DateTime _timeStamp;

        public Measurement(int value)
        {
            _timeStamp = DateTime.UtcNow;
            _value = value;
        }

        public int Value { get => _value; set => }
        public DateTime TimeStamp { get => _timeStamp;}
    }
}
