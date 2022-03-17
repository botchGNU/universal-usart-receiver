using GUI_Meas_Demo.Stores;
using GUI_Meas_Demo.ViewModel;
using System;

namespace GUI_Meas_Demo.Command
{
    internal class NavigateCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            this._navigationStore = navigationStore;
            this._createViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
