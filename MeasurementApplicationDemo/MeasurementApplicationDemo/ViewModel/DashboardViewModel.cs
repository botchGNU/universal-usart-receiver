using GUI_Meas_Demo.Command;
using GUI_Meas_Demo.Model;
using System.Windows.Input;
using System.Windows.Media;

namespace GUI_Meas_Demo.ViewModel
{
    class DashboardViewModel : ViewModelBase
    {
        private MeasurementManager _measMan;
        private SolidColorBrush _actionButtonColor;
        private string _actionButtonContent;
        private bool _exportEnabled = false;
        public DashboardViewModel(MeasurementManager measMan)
        {
            this._measMan = measMan;
            ActionCommand = new ControlMeasurmentCommand(measMan, this);
            _actionButtonColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#32CD32"));
            _actionButtonContent = "Start Measurement";
        }

        #region Commands
        public ICommand ExportCommand { get; }
        public ICommand ActionCommand { get; }
        #endregion
        #region properties
        public SolidColorBrush ActionButtonColor 
        { 
            get => _actionButtonColor; 
            set
            {
                _actionButtonColor = value;
                OnPropertyChanged(nameof(ActionButtonColor));
            }
        }
        public string ActionButtonContent 
        { 
            get => _actionButtonContent;
            set
            {
                _actionButtonContent = value;
                OnPropertyChanged(nameof(ActionButtonContent));
            }
        }

        public bool ExportEnabled 
        { 
            get => _exportEnabled;
            set
            {
                _exportEnabled = value;
                OnPropertyChanged(nameof(ExportEnabled));
            }
        }

        #endregion

    }
}
