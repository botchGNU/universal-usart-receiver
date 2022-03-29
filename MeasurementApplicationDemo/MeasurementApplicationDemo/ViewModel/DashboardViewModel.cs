using GUI_Meas_Demo.Command;
using GUI_Meas_Demo.Model;
using System.Windows.Input;
using System.Windows.Media;

namespace GUI_Meas_Demo.ViewModel
{
    class DashboardViewModel : ViewModelBase
    {
        private MeasurementManager _measMan;
        public DashboardViewModel(MeasurementManager measMan)
        {
            this._measMan = measMan;
            ActionCommand = new ControlMeasurmentCommand(measMan);
        }

        #region Commands
        public ICommand ExportCommand { get; }
        public ICommand ActionCommand { get; }
        #endregion
        #region properties
        public string ActionButtonContent
        {
            get
            {
                if (_measMan.IsRunning)
                {
                    return "Stop Measurement";
                }
                else
                {
                    return "Start Measurement";
                }
            }
        }

        public SolidColorBrush ActionButtonColor
        {
            get
            {
                if (_measMan.IsRunning) { return Brushes.Red; }
                else { return Brushes.LightGreen; }
            }
        }
        #endregion

    }
}
