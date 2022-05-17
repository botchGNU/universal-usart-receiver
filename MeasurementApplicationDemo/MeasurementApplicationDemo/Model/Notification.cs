using Notifications.Wpf;
using System;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;


namespace GUI_Meas_Demo.Model
{
    public static class Notification
    {

        public static Notifier notifier;

        public static void Create()
        {
            notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new PrimaryScreenPositionProvider(
                    corner: Corner.BottomRight,
                    offsetX: 10,
                    offsetY: 10);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });
        }

        public static void Show(string title, string message, NotificationType notificationType)
        {
            switch (notificationType)
            {
                case NotificationType.Success:
                    notifier.ShowSuccess(message); break;
                case NotificationType.Warning:
                    notifier.ShowWarning(message); break;
                case NotificationType.Error:
                    notifier.ShowError(message); break;
                case NotificationType.Information:
                    notifier.ShowInformation(message); break;
                default:
                    break;
            }

        }
        public static void Dispose()
        {
            try
            {
                notifier.Dispose();
            }
            catch (Exception)
            {

            }

        }

        public static void PrintFileMessage(bool success, string fileName)
        {
            if (success)
            {
                Notification.Show("Success", "Export of " + fileName + " was successsfull", Notifications.Wpf.NotificationType.Success);
            }
            else
            {
                Notification.Show("Error", "Export of " + fileName + " was unsuccesssfull", Notifications.Wpf.NotificationType.Error);
            }
        }

    }
}
