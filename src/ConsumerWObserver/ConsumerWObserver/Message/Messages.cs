using ConsumerWObserver.Interface;

namespace ConsumerWObserver.Message;

public class ConsoleMessageObserver : IMessageObserver
{
    public void OnMessageReceived(string message)
    {
        Console.WriteLine($"Mensagem Recebida: {message}");
    }
}

public class CustomMessageHandler : IMessageObserver
{
    public void OnMessageReceived(string message)
    {
        // Implementa lógica específica para a mensagem
        Console.WriteLine($"Processando Mensagem: {message}");
    }
}