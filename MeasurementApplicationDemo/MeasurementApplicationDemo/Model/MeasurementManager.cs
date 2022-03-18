using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Meas_Demo.Model
{
    class MeasurementManager : INotifyPropertyChanged
    {

        #region fields
        private ObservableCollection<Measurement> _measColl = new ObservableCollection<Measurement>();
        private PortManager _portMan;
        private bool _measRunning = false;
        #endregion

        public MeasurementManager(PortManager portMan)
        {
            this._portMan = portMan;
        }

        #region methods
        public void StartMeasure()
        {
            try
            {
                IsRunning = true;           //just TEMPORARY bevor port opening for TESTING PURPOSE
                _portMan.OpenPort();
                Task.Run( () => MeasurementLoopAsync());
            }
            catch (Exception)
            {
                //throw;                //just TEMPORARY DISABLED for TESTING PURPOSE
            }
        }

        public void StopMeasure()
        {
            IsRunning = false;
        }

        private async Task MeasurementLoopAsync()
        {
            while (true) //requires token -> not immplemented yet
            {
                try
                {
                    char receivedValue = (char)_portMan.ReadChar();

                    var newMeas = new Measurement(receivedValue);
                    MeasurementCollection.Add(newMeas);
                }
                catch (Exception)
                {
                    StopMeasure();
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
