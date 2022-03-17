using GUI_Meas_Demo.Model;

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
