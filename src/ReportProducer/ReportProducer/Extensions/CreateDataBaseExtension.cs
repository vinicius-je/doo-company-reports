using Microsoft.EntityFrameworkCore;
using ReportProducer.Context;

namespace ReportProducer.Extensions
{
    public static class CreateDataBaseExtension
    {
        public static void CreateDatabase(this WebApplication app)
        {
            var serviceScope = app.Services.CreateScope();
            var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
            dataContext?.Database.EnsureCreated();
            //dataContext?.Database.Migrate();
        }
    }
}
