using ReportProducer.Jobs.GenerateAndSend.Interfaces;
using ReportProducer.Services.Reports.Interfaces;
using ReportProducer.Services.Save.Interfaces;
using ReportProducer.Services.Send.Interfaces;

namespace ReportProducer.Jobs.GenerateAndSend.Services
{
    public class GenerateAndSendFinanceReportJob : IGenerateAndSendFinanceReportJob
    {
        protected readonly ISendReport _send;
        protected readonly ISaveReport _save;
        protected readonly IGenerateFinanceReport _report;

        public GenerateAndSendFinanceReportJob(ISendReport send, ISaveReport save, IGenerateFinanceReport report)
        {
            _send = send;
            _save = save;
            _report = report;
        }

        public void Process()
        {
            try
            {
                // Generate Report
                var report = _report.Process();

                // Save Report
                var reportPath = _save.Process(report);

                // Send Report
                _send.Process(reportPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }
    }
}
