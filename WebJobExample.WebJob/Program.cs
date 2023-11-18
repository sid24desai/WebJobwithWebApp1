using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WebJobExample.WebJob
{
    class Program
    {
        static async Task Main()
        {
            var builder = new HostBuilder();
#if DEBUG
            builder.UseEnvironment("development");
#endif
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();

            });
            builder.ConfigureLogging((context, b) =>
            {
                b.AddConsole();
            });
            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
