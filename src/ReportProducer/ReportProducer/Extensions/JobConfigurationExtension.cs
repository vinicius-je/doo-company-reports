using Hangfire;
using ReportProducer.Jobs.GenerateAndSend.Interfaces;

namespace ReportProducer.Extensions
{
    public static class JobConfigurationExtension
    {
        public static void ConfiureJobs(this WebApplication app)
        {
            BackgroundJob.Enqueue<IGenerateAndSendFinanceReportJob>(e => e.Process());
        }
    }
}
