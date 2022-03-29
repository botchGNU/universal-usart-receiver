using CLI_Excel_Demo;
using GUI_Meas_Demo.Model;
using GUI_Meas_Demo.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
