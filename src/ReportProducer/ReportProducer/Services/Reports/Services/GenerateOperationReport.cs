using ReportProducer.Services.Reports.Interfaces;

namespace ReportProducer.Services.Reports.Services
{
    public class GenerateOperationReport : IGenerateOperationReport
    {
        public string Process()
        {
            var totalOrdersProcessed = GenerateRandomInt(10, 1000);
            var successfulOrders = GenerateRandomInt(10, totalOrdersProcessed);
            var failedOrders = totalOrdersProcessed - successfulOrders;

            return "-- Operation Report --\n" +
                  "-----------------------\n" +
                  $"Generate on: {DateTime.Now}\n" +
                  "Status: Completed\n" +
                  $"Total Orders Processed: {totalOrdersProcessed}\n" +
                  $"Successful Orders: {successfulOrders}\n" +
                  $"Failed Orders: {failedOrders}\n";
        }

        private int GenerateRandomInt(int minValue, int maxValue)
        {
            Random random = new Random();
            return random.Next(minValue, maxValue + 1);
        }
    }
}
