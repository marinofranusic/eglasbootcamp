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

            var cRijeka = cityService.FindCitiesByName("Rijeka");
            foreach(var cR in cRijeka)
            {
                Console.WriteLine($"{cR.Id} - {cR.Name}");
            }

            var cHrv = cityService.FindCitiesByCountryCode("HRV");
            foreach (var cHr in cHrv)
            {
                Console.WriteLine($"{cHr.Id} - {cHr.Name}");
            }
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
