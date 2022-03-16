using GUI_Meas_Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI_Meas_Demo.Command
{
    class SetDeviceSettingsCommand : CommandBase
    {
        private DeviceSettingsViewModel _deviceSettingsViewModel;

        public SetDeviceSettingsCommand(DeviceSettingsViewModel deviceSettingsViewModel)
        {
            _deviceSettingsViewModel = deviceSettingsViewModel;
        }

        public override void Execute(object parameter)
        {
            _deviceSettingsViewModel.ImportDeviceInfo();

            if (_deviceSettingsViewModel.IsConfirmButtonRequirementsMet) { _deviceSettingsViewModel.IsConfirmButtonEnabled = true; }
        }
    }
}
