﻿using ReportProducer.Jobs.GenerateAndSend.Interfaces;
using ReportProducer.Services.Reports.Interfaces;
using ReportProducer.Services.Save.Interfaces;
using ReportProducer.Services.Send.Interfaces;

namespace ReportProducer.Jobs.GenerateAndSend.Services
{
    public class GenerateAndSendFinanceReportJob : GenerateAndSendReportBaseJob, IGenerateAndSendFinanceReportJob
    {
        public GenerateAndSendFinanceReportJob(ISendReport send, ISaveReport save, IGenerateFinanceReport report) : base(send, save, report)
        {
        }
    }
}
