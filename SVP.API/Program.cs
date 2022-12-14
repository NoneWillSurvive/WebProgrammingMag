using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace SVP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
              .SetBasePath(GetBasePath())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            if (IsDevelopment)
                configuration.AddJsonFile("appsettings.Development.json", optional: true);

            configuration.AddEnvironmentVariables();

            var configurationRoot = configuration.Build();
            
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static bool IsDevelopment => (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development);

        private static string GetBasePath()
        {
            using var processModule = Process.GetCurrentProcess().MainModule;
            if(processModule.ModuleName == "dotnet.exe" || processModule.ModuleName == "dotnet")
                return AppContext.BaseDirectory;
                
            return Path.GetDirectoryName(processModule?.FileName);
        }
    }
}
