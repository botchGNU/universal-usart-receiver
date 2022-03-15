using GUI_Meas_Demo.Command;
using GUI_Meas_Demo.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Text;
using System.Windows.Input;

namespace GUI_Meas_Demo.ViewModel
{
    class DeviceSettingsViewModel : ViewModelBase
    {
        #region fields
        private PortManager _portManager;
        #endregion

        #region ctor
        public DeviceSettingsViewModel(PortManager aPortManager)
        {
            _portManager = aPortManager;
            ConfirmCommand = new ConfirmDeviceSettingsCommand();
            SetCommand = new SetDeviceSettingsCommand();
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
        ICommand ConfirmCommand { get;  }
        ICommand SetCommand { get; }
        #endregion
    }
}
