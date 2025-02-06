using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using ConsumerWObserver.Interface;

namespace ConsumerWObserver.Observable;

public class RabbitMqObservable
{
    private readonly List<IMessageObserver> _observers = new();
    private readonly string _queueName;
    private readonly string _hostName;

    public RabbitMqObservable(string hostName, string queueName)
    {
        _hostName = hostName;
        _queueName = queueName;
    }

    public void Subscribe(IMessageObserver observer)
    {
        _observers.Add(observer);
    }

    public void Unsubscribe(IMessageObserver observer)
    {
        _observers.Remove(observer);
    }

    public void StartConsuming()
    {
        var factory = new ConnectionFactory() { HostName = _hostName };

        while (true) // Loop contínuo para manter o processo rodando
        {
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                NotifyObservers(message); // Notifica todos os observadores registrados
            };

            channel.BasicConsume(queue: _queueName,
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine("Consumindo mensagens... Pressione Ctrl+C para interromper.");
            Console.ReadLine(); // Pausa e mantém o processo ativo
        }
    }

    private void NotifyObservers(string message)
    {
        foreach (var observer in _observers)
        {
            observer.OnMessageReceived(message);
        }
    }
}