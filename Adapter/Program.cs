using System;

// Interface representing a generic message
interface IMessage
{
    void Send();
}

// Class representing a text message
class TextMessage : IMessage
{
    public void Send()
    {
        Console.WriteLine("Sending text message...");
    }
}

// Class representing an email message
class EmailMessage
{
    public void SendEmail()
    {
        Console.WriteLine("Sending email...");
    }
}

// Adapter that allows sending an email message as if it were a generic message
class EmailMessageAdapter : IMessage
{
    private EmailMessage emailMessage;

    public EmailMessageAdapter(EmailMessage emailMessage)
    {
        this.emailMessage = emailMessage;
    }

    public void Send()
    {
        // Use the adapter to call the method of the email message
        emailMessage.SendEmail();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating an instance of the text message
        IMessage textMessage = new TextMessage();
        textMessage.Send();

        // Creating an instance of the email message
        EmailMessage emailMessage = new EmailMessage();

        // Creating an adapter to send the email message as a generic message
        IMessage adapter = new EmailMessageAdapter(emailMessage);
        adapter.Send();

        Console.ReadKey();
    }
}
