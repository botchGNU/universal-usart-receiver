using GUI_Meas_Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI_Meas_Demo.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
            }
        }
    }
}
