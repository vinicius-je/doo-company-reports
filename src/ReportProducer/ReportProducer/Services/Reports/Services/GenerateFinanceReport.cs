using ReportProducer.Services.Reports.Interfaces;

namespace ReportProducer.Services.Reports.Services
{
    public class GenerateFinanceReport : IGenerateFinanceReport
    {
        public string Process()
        {
            decimal revenue = GenerateRandomDecimal(100000, 200000);
            decimal expenses = GenerateRandomDecimal(100000, revenue);

            return "-- Finance Report --\n" +
                   "--------------------\n" +
                   $"Generate on: {DateTime.Now}\n" +
                   "Status: Completed\n" +
                   $"Revenue: ${revenue}\n" +
                   $"Expenses: ${expenses}\n" +
                   $"Profit: ${CalculateProfit(revenue, expenses)}\n";
        }

        private decimal GenerateRandomDecimal(decimal minValue, decimal maxValue)
        {
            Random random = new Random();
            double range = (double)(maxValue - minValue);
            return minValue + (decimal)(random.NextDouble() * range);
        }

        private decimal CalculateProfit(decimal revenue, decimal expenses) => revenue - expenses;
    }
}
