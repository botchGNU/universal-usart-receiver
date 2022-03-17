using Notifications.Wpf;

namespace GUI_Meas_Demo.Model
{
    public static class Notification
    {
        public static void Show(string title, string message, NotificationType notificationType)
        {
            var notificationManager = new NotificationManager();

            notificationManager.Show(new NotificationContent
            {
                Title = title,
                Message = message,
                Type = notificationType
            });

        }
    }
}
