using Hangfire.Dashboard;
using System.Diagnostics.CodeAnalysis;

namespace ConsumerWObserver.Extensions
{
    public class HangfireAuthorizationFilterExtension : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
