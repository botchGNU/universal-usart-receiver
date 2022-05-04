using GUI_Meas_Demo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI_Meas_Demo.Command
{
    internal class CloseCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Notification.Dispose();
        }
    }
}
