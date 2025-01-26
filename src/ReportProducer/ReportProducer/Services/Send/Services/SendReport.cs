using ReportProducer.Services.Send.Interfaces;

namespace ReportProducer.Services.Send.Services
{
    public class SendReport : ISendReport
    {
        public void Process(string filePath)
        {
            Console.WriteLine($"[x] Sent report to RabbitMQ: {filePath}");
        }
    }
}
