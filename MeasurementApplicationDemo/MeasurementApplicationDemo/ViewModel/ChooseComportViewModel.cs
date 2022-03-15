using GUI_Meas_Demo.Command;
using GUI_Meas_Demo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI_Meas_Demo.ViewModel
{
    class ChooseComportViewModel : ViewModelBase
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
            }
        }

        #region ctor
        public ChooseComportViewModel(PortManager aPortManger)
        {
            _portManager = aPortManger;
            UpdateComportList();
            ConfirmCommand = new ConfirmComportCommand(this);
        }
        #endregion

        public void ListBoxSelect()
        {
            IsButtonEnabled = true;
        }
        #endregion methods

        #region commands
        public ICommand ConfirmCommand { get; }
        #endregion

        #region properties
        public IEnumerable<string> ComportList => _comportList;
        public bool IsButtonEnabled { get => _isButtonEnabled; set { _isButtonEnabled = value; OnPropertyChanged(nameof(IsButtonEnabled)); } }
        public string ListBoxCurrentSelected { get => _portManager.PortName; set { _portManager.PortName = value; OnPropertyChanged(nameof(ListBoxCurrentSelected)); } }
        #endregion
    }
}
