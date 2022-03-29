using GUI_Meas_Demo.Model;
using System.Collections.ObjectModel;

namespace GUI_Meas_Demo.Command
{
    internal class ExportCommand : CommandBase
    {
        private ObservableCollection<Measurement> _measurements;

        public ExportCommand(ObservableCollection<Measurement> measurements)
        {
            _measurements = measurements;
        }

        public override void Execute(object parameter)
        {
            ExportManager.AsExcelAsync(_measurements);
        }
    }
}
