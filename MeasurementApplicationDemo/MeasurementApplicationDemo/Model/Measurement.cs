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

        public string TimeStamp 
        { 
            get
            {
                string stamp = _timeStamp.Second + ":" + _timeStamp.Millisecond;
                return stamp;
            }
        }
        //private DateTime TimeStamp { get => _timeStamp; }
        public int Value { get => _value; }
    }
}
