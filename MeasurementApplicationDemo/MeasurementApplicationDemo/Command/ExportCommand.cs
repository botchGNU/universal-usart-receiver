using GUI_Meas_Demo.Model;

namespace GUI_Meas_Demo.Command
{
    internal class ExportCommand : CommandBase
    {
        private MeasurementManager _measMan;

        public ExportCommand(MeasurementManager measMan)
        {
            _measMan = measMan;
        }

        public override void Execute(object parameter)
        {
            ExportManager.ExportAsync(_measMan.MeasurementCollection);
        }

    }
}
