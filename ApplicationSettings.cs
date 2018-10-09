using Microsoft.Extensions.Configuration;
using System.IO;

// NOTE: Add nuget for Microsoft.Extensions.Configuration.Json and Microsoft.Extensions.Configuration.Binder
namespace Common
{
    public class ApplicationSettings
    {
        public static string Setting1 { get; private set; }
        
        private static IConfiguration Configuration;

        static ApplicationSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
#if RELEASE
                .AddJsonFile($"appsettings.Release.json", true)
#endif
                ;

            Configuration = builder.Build();

            Setting1 = Configuration.GetValue<string>("Setting1");
        }
    }
}
