using GUI_Meas_Demo.Command;
using GUI_Meas_Demo.Model;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            ExportMeasCommand = new ExportCommand(_measMan);
            _actionButtonColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#32CD32"));
            _actionButtonContent = "Start Measurement";
        }

        #region Commands
        public ICommand ExportMeasCommand { get; }
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

        public ImageSource DisplayImageSource
        {
            get
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(@"..\Resources\donotunplug.jpg", UriKind.Relative);
                bi3.EndInit();
                return bi3;
            }
        }

        #endregion

    }
}
