using ReportProducer.Services.Save.Interfaces;

namespace ReportProducer.Services.Save.Services
{
    public class SaveReport : ISaveReport
    {
        public string Process(string report)
        {
            string filePath = $"report_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            File.WriteAllText(filePath, report);
            return filePath;
        }
    }
}
