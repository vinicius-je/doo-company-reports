using ReportProducer.Jobs.GenerateAndSend.Interfaces;
using ReportProducer.Services.Reports.Interfaces;
using ReportProducer.Services.Save.Interfaces;
using ReportProducer.Services.Send.Interfaces;

namespace ReportProducer.Jobs.GenerateAndSend.Services
{
    public class GenerateAndSendOperationReportJob : GenerateAndSendReportBaseJob, IGenerateAndSendOperationReportJob
    {
        public GenerateAndSendOperationReportJob(ISendReport send, ISaveReport save, IGenerateOperationReport report) : base(send, save, report)
        {
        }
    }
}
