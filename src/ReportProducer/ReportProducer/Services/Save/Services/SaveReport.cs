using ReportProducer.Services.Save.Interfaces;
using System.Text;

namespace ReportProducer.Services.Save.Services
{
    public class SaveReport : ISaveReport
    {
        public string Process(string report)
        {
            StringBuilder sb = new StringBuilder();

            string filePath = $"ReportFiles/report_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            File.WriteAllText(filePath, report);
            return filePath;
        }
    }
}
