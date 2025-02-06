using ConsumerWObserver.Message;
using ConsumerWObserver.Observable;

public class Program
{
    public static void Main(string[] args)
    {
        var rabbitMqHost = "localhost";
        var queueName = "fila-arquivos";

        var rabbitMqObservable = new RabbitMqObservable(rabbitMqHost, queueName);

        // Adicionar Observadores (Observers)
        rabbitMqObservable.Subscribe(new ConsoleMessageObserver());
        rabbitMqObservable.Subscribe(new CustomMessageHandler());

        // Inicia o processo de consumo contínuo
        rabbitMqObservable.StartConsuming();
    }
}