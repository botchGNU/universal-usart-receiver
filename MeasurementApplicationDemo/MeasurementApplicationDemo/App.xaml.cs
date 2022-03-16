using GUI_Meas_Demo.Model;
using GUI_Meas_Demo.Stores;
using GUI_Meas_Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MeasurementApplicationDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private PortManager _portManager;
        public App()
        {
            _portManager = new PortManager();
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new ChooseComportViewModel(_portManager, _navigationStore, CreateDeviceSettingsViewModel);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private DeviceSettingsViewModel CreateDeviceSettingsViewModel()
        {
            return new DeviceSettingsViewModel(_portManager, _navigationStore, CreateDashboardViewModel);
        }

        private DashboardViewModel CreateDashboardViewModel()
        {
            return new DashboardViewModel(_portManager);
        }

        private ChooseComportViewModel CreateChooseComportViewModel()
        {
            return new ChooseComportViewModel(_portManager, _navigationStore, CreateDeviceSettingsViewModel);
        }
    }
}
