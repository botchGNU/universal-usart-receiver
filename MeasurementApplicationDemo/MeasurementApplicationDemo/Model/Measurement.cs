using System;

namespace GUI_Meas_Demo.Model
{
    public class Measurement
    {
        private int _value;
        private DateTime _timeStamp;
        private const char SEP = ',';

        public Measurement(int value)
        {
            _timeStamp = DateTime.UtcNow;
            _value = value;
        }

        public string Serialize()
        {
            return
                $"German{SEP}{_timeStamp}{SEP}{_value}{SEP}";
        }

        public int Value { get => _value; }
        public DateTime TimeStamp { get => _timeStamp; }
    }
}
