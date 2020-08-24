using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

// NOTE: Add nuget for Microsoft.Extensions.Configuration.Json and Microsoft.Extensions.Configuration.Binder
namespace Common
{
    public class AppSettings
    {
        public static string Setting1 { get; private set; }
        
        static AppSettings()
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
    
    // Make sure appSettings files are set to "Embedded Resource"
    public class XamarinAppSettings
    {
        using System.Linq
        using System.Reflection;
        
        public static string Setting1 { get; private set; }
        
        static XamarinAppSettings()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonStream(GetEmbeddedResource("appSettings.json"))
#if RELEASE
                .AddJsonStream(GetEmbeddedResource("appSettings.Release.json"), true)
#endif
                ;


            Configuration = builder.Build();

            Setting1 = Configuration.GetValue<string>("Setting1");
        }

        static Stream GetEmbeddedResource(string resourceName)
        {
            var assembly = assembly.GetCallingAssembly();

            var resourcePath = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith(resourceName));

            return assembly.GetManifestResourceStream(resourcePath);
        }
    }
}
}
