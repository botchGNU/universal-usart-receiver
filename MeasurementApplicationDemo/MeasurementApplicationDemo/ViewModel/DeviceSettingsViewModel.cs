using GUI_Meas_Demo.Command;
using GUI_Meas_Demo.Model;
using GUI_Meas_Demo.Stores;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Text;
using System.Windows.Input;

namespace GUI_Meas_Demo.ViewModel
{
    class DeviceSettingsViewModel : ViewModelBase, IConfirmButtonViewModel
    {
        #region fields
        private PortManager _portManager;
        private bool _isButtonEnabled = false;
        #endregion

        #region ctor
        public DeviceSettingsViewModel(PortManager aPortManager, NavigationStore navigationStore,Func<DashboardViewModel> createDashbaordViewModel)
        {
            _portManager = aPortManager;
            ConfirmCommand = new NavigateCommand(navigationStore, createDashbaordViewModel);
            SetCommand = new SetDeviceSettingsCommand(this);
        }
        #endregion

        #region methods
        public void ImportDeviceInfo()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Config file (.json)|*.json|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.ShowDialog();

            _portManager.Info = DeviceInfoManager.GetDeviceInfo(openFileDialog.FileName);
        }
        #endregion

        #region commands
        public ICommand ConfirmCommand { get;  }
        public ICommand SetCommand { get; }
        #endregion

        #region properties
        public bool IsConfirmButtonEnabled 
        {
            get => _isButtonEnabled; 
            set 
            { 
                _isButtonEnabled = value; 
                OnPropertyChanged(nameof(IsConfirmButtonEnabled)); 
            } 
        }

        public bool IsConfirmButtonRequirementsMet => _portManager.IsRequiredInfoSet();
        #endregion
    }
}
