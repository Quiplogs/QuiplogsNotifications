using Microsoft.Extensions.Configuration;
using System;

namespace Quiplogs.Notifications.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .AddCommandLine(args)
               .Build();
        }
    }
}
