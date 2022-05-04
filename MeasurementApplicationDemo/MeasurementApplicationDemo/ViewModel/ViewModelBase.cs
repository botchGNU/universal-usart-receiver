using GUI_Meas_Demo.Command;
using System.ComponentModel;
using System.Windows.Input;

namespace GUI_Meas_Demo.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CloseCommand = new CloseCommand();
    }
}