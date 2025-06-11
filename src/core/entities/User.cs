public class User : INotificationObserver
{
    public string Name { get; set; }
    public string Email { get; set; }
    public Role UserRole { get; set; }
    NotificationDecorator receiveDevices { get; set; }

    public User()
    {
        // אתחול של receiveDevices עם BasicNotifier
        receiveDevices = new BasicNotifier(); // או כל סוג אחר של NotificationDecorator
    }

    public void Update(string message)
    {
        if (receiveDevices == null)
        {
            Console.WriteLine("receiveDevices is not initialized.");
            return;
        }

        receiveDevices.Send($"I {Name} got this message {message}");
    }
}
