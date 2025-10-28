using System;

public interface INotificationStrategy
{
    void Send(string message);
}

public class EmailNotification : INotificationStrategy
{
    public void Send(string message)
    {
        Console.WriteLine($"Enviando Email com a mensagem: {message}");
    }
}

public class SmsNotification : INotificationStrategy
{
    public void Send(string message)
    {
        Console.WriteLine($"Enviando SMS com a mensagem: {message}");
    }
}

public class PushNotification : INotificationStrategy
{
    public void Send(string message)
    {
        Console.WriteLine($"Enviando Notificação Push com a mensagem: {message}");
    }
}

public class NotificationContext
{
    private INotificationStrategy _strategy;

    public NotificationContext(INotificationStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(INotificationStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Notify(string message)
    {
        _strategy.Send(message);
    }
}

public class Program
{
    public static void Main()
    {
        var context = new NotificationContext(new EmailNotification());
        context.Notify("Olá via Email!");

        context.SetStrategy(new SmsNotification());
        context.Notify("Olá via SMS!");

        context.SetStrategy(new PushNotification());
        context.Notify("Olá via Notificação Push!");
    }
}
