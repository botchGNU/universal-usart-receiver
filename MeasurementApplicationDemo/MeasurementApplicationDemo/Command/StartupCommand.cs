using GUI_Meas_Demo.Model;

namespace GUI_Meas_Demo.Command
{
    internal class StartupCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Notification.Create();
        }
    }
}