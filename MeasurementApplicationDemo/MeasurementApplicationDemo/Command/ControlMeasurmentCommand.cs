using GUI_Meas_Demo.Model;
using GUI_Meas_Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI_Meas_Demo.Command
{
    class ControlMeasurmentCommand : CommandBase
    {
        private MeasurementManager _measMan;

        public ControlMeasurmentCommand(MeasurementManager measMan)
        {
            _measMan = measMan;
        }

        public override void Execute(object parameter)
        {
            if (_measMan.IsRunning) { _measMan.StopMeasure(); }
            else { _measMan.StartMeasure(); }
        }
    }
}
