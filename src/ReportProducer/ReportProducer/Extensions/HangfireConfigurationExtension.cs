using Hangfire;

namespace ReportProducer.Extensions
{
    public static class HangfireConfigurationExtension
    {
        public static void ConfigureHangfire(this IServiceCollection service)
        {
            service.
                AddHangfire(cfg => cfg
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Server=sqlserver,1433;Database=ReportProduceDB;User ID=sa;Password=1a2b3c4r#$;Trusted_Connection=False;TrustServerCertificate=True;"));
        }
    }
}
