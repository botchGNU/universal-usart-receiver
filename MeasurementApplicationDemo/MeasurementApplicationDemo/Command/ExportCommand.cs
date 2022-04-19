using GUI_Meas_Demo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI_Meas_Demo.Command
{
    class ExportCommand : CommandBase
    {
        private MeasurementManager _measMan;

        public ExportCommand(MeasurementManager measMan)
        {
            _measMan = measMan;
        }

        public override void Execute(object parameter)
        {
            ExportManager.AsExcelAsync(_measMan.MeasurementCollection);            
        }

    }
}
