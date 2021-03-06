using GUI_Meas_Demo.ViewModel;

namespace GUI_Meas_Demo.Command
{
    internal class EnableConfirmButtonCommand : CommandBase
    {
        private IConfirmButtonViewModel viewModel;

        public EnableConfirmButtonCommand(IConfirmButtonViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (viewModel.IsConfirmButtonRequirementsMet) { viewModel.IsConfirmButtonEnabled = true; }
            //Notification.Show("tets", "test", NotificationType.Information);
        }
    }
}
