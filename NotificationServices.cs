namespace DelegatesTask
{
    public interface INotificationService
    {
        void Notify(string message);
    }

    public class SMSService : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"SMS: {message}");
        }
    }

    public class EmailService : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Email: {message}");
        }
    }

    public class PushNotificationService : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Push Notification: {message}");
        }
    }
}
