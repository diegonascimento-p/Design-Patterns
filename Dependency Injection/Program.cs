using System;

// Interface representing a notification service
interface INotificationService
{
    void SendNotification(string message);
}

// Implementation of an email notification service
class EmailNotificationService : INotificationService
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Sending email notification: {message}");
    }
}

// Implementation of an SMS notification service
class SmsNotificationService : INotificationService
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Sending SMS notification: {message}");
    }
}

// Class responsible for sending notifications
class NotificationService
{
    private readonly INotificationService _notificationService;

    // Constructor injection
    public NotificationService(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    // Method to send notifications
    public void SendNotification(string message)
    {
        _notificationService.SendNotification(message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating an instance of email notification service
        INotificationService emailService = new EmailNotificationService();

        // Creating an instance of SMS notification service
        INotificationService smsService = new SmsNotificationService();

        // Creating notification service and injecting email service
        NotificationService notificationServiceWithEmail = new NotificationService(emailService);
        notificationServiceWithEmail.SendNotification("Hello from email!");

        // Creating notification service and injecting SMS service
        NotificationService notificationServiceWithSms = new NotificationService(smsService);
        notificationServiceWithSms.SendNotification("Hello from SMS!");

        Console.ReadKey();
    }
}
