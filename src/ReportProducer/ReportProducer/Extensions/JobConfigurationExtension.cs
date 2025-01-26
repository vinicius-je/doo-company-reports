using Hangfire;
using ReportProducer.Jobs.GenerateAndSend.Interfaces;

namespace ReportProducer.Extensions
{
    public static class JobConfigurationExtension
    {
        [Obsolete]
        public static void ConfiureJobs(this WebApplication app)
        {
            RecurringJob.AddOrUpdate<IGenerateAndSendFinanceReportJob>(f => f.Process(), "*/1 * * * *");
            RecurringJob.AddOrUpdate<IGenerateAndSendOperationReportJob>(o => o.Process(), "*/2 * * * *");
        }
    }
}
