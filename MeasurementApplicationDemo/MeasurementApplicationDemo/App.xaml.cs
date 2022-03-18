using GUI_Meas_Demo.Model;
using GUI_Meas_Demo.Stores;
using GUI_Meas_Demo.ViewModel;
using System.Windows;

namespace MeasurementApplicationDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navStore;
        private PortManager _portMan;
        private MeasurementManager _measMan;
        public App()
        {
            _portMan = new PortManager();
            _navStore = new NavigationStore();
            _measMan = new MeasurementManager(_portMan);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navStore.CurrentViewModel = new ChooseComportViewModel(_portMan, _navStore, CreateDeviceSettingsViewModel);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private DeviceSettingsViewModel CreateDeviceSettingsViewModel()
        {
            return new DeviceSettingsViewModel(_portMan, _navStore, CreateDashboardViewModel);
        }

        private DashboardViewModel CreateDashboardViewModel()
        {
            return new DashboardViewModel(_measMan);
        }

        private ChooseComportViewModel CreateChooseComportViewModel()
        {
            return new ChooseComportViewModel(_portMan, _navStore, CreateDeviceSettingsViewModel);
        }
    }
}
