using Microsoft.EntityFrameworkCore;
using ReportProducer.Context;

namespace ReportProducer.Extensions
{
    public static class DataBaseConfigurationExtension
    {
        public static void ConfigureDataBase(this IServiceCollection services)
        {
            IServiceCollection serviceCollection =
            services.AddDbContext<AppDbContext>(opt =>
            {
                    opt.UseSqlServer("Server=sqlserver,1433;Database=ReportProduceDB;User ID=sa;Password=1a2b3c4r#$;Trusted_Connection=False;TrustServerCertificate=True;");
                    opt.EnableSensitiveDataLogging();
            }, ServiceLifetime.Scoped);
        }
    }
}
