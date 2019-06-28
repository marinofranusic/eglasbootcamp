using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace WorldData
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new world.worldContext(GetDatabaseConnectionString());
            var cityService = new world.CityService(context);
            var c = cityService.GetCity(777);
            Console.WriteLine(c.Name ?? "NOT FOUND");

        }

        private static string GetDatabaseConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            return configuration.GetConnectionString("WorldDatabase");
        }
    }
}
