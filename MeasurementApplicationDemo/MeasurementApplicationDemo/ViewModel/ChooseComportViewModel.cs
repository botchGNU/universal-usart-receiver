using GUI_Meas_Demo.Command;
using GUI_Meas_Demo.Model;
using GUI_Meas_Demo.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Windows.Input;

namespace GUI_Meas_Demo.ViewModel
{
    class ChooseComportViewModel : ViewModelBase, IConfirmButtonViewModel
    {
        #region fields
        private ObservableCollection<string> _comportList = new ObservableCollection<string>();
        private PortManager _portManager;
        private bool _isButtonEnabled = false;
        #endregion

        #region methods
        public void UpdateComportList()
        {
            foreach (var item in SerialPort.GetPortNames())
            {
                this._comportList.Add(item);
                Notification.Create();
            }

            if (_comportList.Count <= 0) { /*Notification.Show("Error", "No comports found! Please instert device", Notifications.Wpf.NotificationType.Error); */}
            else { _isButtonEnabled = true;}
        }

        #region ctor
        public ChooseComportViewModel(PortManager portManager, NavigationStore navigationStore, Func<DeviceSettingsViewModel> createDeviceSettingsViewModel)
        {
            this._portManager = portManager;
            UpdateComportList();
            SelectedCommand = new EnableConfirmButtonCommand(this);
            ConfirmCommand = new NavigateCommand(navigationStore, createDeviceSettingsViewModel);
        }
        #endregion

        public void ListBoxSelect()
        {
            IsConfirmButtonEnabled = true;
        }
        #endregion methods

        #region commands
        public ICommand ConfirmCommand { get; }
        public ICommand SelectedCommand { get; }
        #endregion

        #region properties
        public IEnumerable<string> ComportList => _comportList;
        public bool IsConfirmButtonEnabled { get => _isButtonEnabled; set { _isButtonEnabled = value; OnPropertyChanged(nameof(IsConfirmButtonEnabled)); } }
        public string ListBoxCurrentSelected
        {
            get => _portManager.PortName;
            set
            {
                _portManager.PortName = value;

                OnPropertyChanged(nameof(ListBoxCurrentSelected));
            }
        }

        public bool IsConfirmButtonRequirementsMet => _portManager.IsRequiredInfoSet();
        #endregion
    }
}
