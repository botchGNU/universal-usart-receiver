using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;

namespace GUI_Meas_Demo.Model
{
    internal class MeasurementManager : INotifyPropertyChanged
    {
        #region fields
        private ObservableCollection<Measurement> _measColl;
        private PortManager _portMan;
        private bool _measRunning;
        private Thread _measThread;
        #endregion
        public MeasurementManager(PortManager portMan)
        {
            this._portMan = portMan;
            _measRunning = false;
            _measColl = new ObservableCollection<Measurement>();
        }

        #region methods

        public void StartMeasureThread()
        {
            _portMan.OpenPort();
            IsRunning = true;
            _measThread = new Thread(MeasurementLoopThread);
            _measThread.Start();
        }

        public void StopMeasureThread()
        {
            // <- implement thread stop
            IsRunning = false;
            _portMan.ClosePort();
        }
        #endregion

        #region tasks/threads
        private void MeasurementLoopThread()
        {
            while (IsRunning)
            {
                try
                {
                    int receivedValue = _portMan.ReadByte();
                    var newMeas = new Measurement(receivedValue);
                    MeasurementCollection.Add(newMeas);
                }
                catch (Exception e)
                {
                    Notification.Show("Error", e.Message, Notifications.Wpf.NotificationType.Error);
                    StopMeasureThread();
                }
            }
        }


        #endregion

        #region properties
        public ObservableCollection<Measurement> MeasurementCollection { get => _measColl; set => _measColl = value; }
        public bool IsRunning
        {
            get => _measRunning;
            set
            {
                _measRunning = value;
                OnPropertyChanged(propertyName: "IsRunning");
            }
        }



        #endregion

        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
