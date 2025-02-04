using RabbitMQ.Client;
using ReportProducer.Services.Send.Interfaces;
using System.Text;
using System.IO;

namespace ReportProducer.Services.Send.Services
{
    public class SendReport : ISendReport
    {
        public async void Process(string filePath)
        {
            // Ler o conteúdo do arquivo
            string fileContent = File.ReadAllText(filePath);

            var factory = new ConnectionFactory() { HostName = "host.docker.internal" }; // Altere se necessário
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            string queueName = "fila-arquivos";

            // Cria a fila
            await channel.QueueDeclareAsync(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            // Enviar mensagem (conteúdo do arquivo)
            var body = Encoding.UTF8.GetBytes(fileContent);
            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: queueName, body: body);

            Console.WriteLine("Enviado relatório para a fila do RabbitMQ.");
        }
    }
}
