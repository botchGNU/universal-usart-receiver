using GUI_Meas_Demo.Command;
using GUI_Meas_Demo.Stores;
using System.Windows.Input;

namespace GUI_Meas_Demo.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            CloseCommand = new CloseCommand();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }



        public ViewModelBase CurrentViewModel { get => _navigationStore.CurrentViewModel; }

        public ICommand CloseCommand { get; }

    }
}
