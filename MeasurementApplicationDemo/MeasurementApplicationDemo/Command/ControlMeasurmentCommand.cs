using GUI_Meas_Demo.Model;
using GUI_Meas_Demo.ViewModel;
using System.Windows.Media;

namespace GUI_Meas_Demo.Command
{
    internal class ControlMeasurmentCommand : CommandBase
    {
        private MeasurementManager _measMan;
        private DashboardViewModel _viewModel;
        public ControlMeasurmentCommand(MeasurementManager measMan, DashboardViewModel viewModel)
        {
            _measMan = measMan;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (_measMan.IsRunning)
            {
                _measMan.StopMeasureThread();
                _viewModel.ActionButtonColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#32CD32")); //green
                _viewModel.ActionButtonContent = "Start Measurement";
                _viewModel.ExportEnabled = true;
            }
            else
            {
                _measMan.StartMeasureThread();
                _viewModel.ActionButtonColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF4500")); //red
                _viewModel.ActionButtonContent = "Stop Measurement";
                _viewModel.ExportEnabled = false;
            }
        }
    }
}
