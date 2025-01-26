using ReportProducer.Jobs.GenerateAndSend.Interfaces;
using ReportProducer.Jobs.GenerateAndSend.Services;
using ReportProducer.Services.Reports.Interfaces;
using ReportProducer.Services.Reports.Services;
using ReportProducer.Services.Save.Interfaces;
using ReportProducer.Services.Save.Services;
using ReportProducer.Services.Send.Interfaces;
using ReportProducer.Services.Send.Services;

namespace ReportProducer.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection service)
        {
            service.AddScoped<IGenerateFinanceReport, GenerateFinanceReport>();
            service.AddScoped<IGenerateOperationReport, GenerateOperationReport>();
            service.AddScoped<ISendReport, SendReport>();
            service.AddScoped<ISaveReport, SaveReport>();
            service.AddScoped<IGenerateAndSendFinanceReportJob, GenerateAndSendFinanceReportJob>();
        }
    }
}
