using GUI_Meas_Demo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI_Meas_Demo.ViewModel
{
    class DashboardViewModel : ViewModelBase
    {
        private PortManager _portManager;

        public DashboardViewModel(PortManager portManager)
        {
            _portManager = portManager;
        }
    }
}
