using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace WorldClient
{
    class Program
    {
        private static readonly HttpClient _client = new HttpClient();
        private static readonly DataContractJsonSerializer _citySerializer = new DataContractJsonSerializer(typeof(List<CityParser>));

        private static async Task GetCities()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("User-Agent", ".NET client");

            var stream = _client.GetStreamAsync("https://localhost:44379/api/city");
            var cities = _citySerializer.ReadObject(await stream) as List<CityParser>;

            foreach (var c in cities)
            {
                Console.WriteLine(c.Name);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for API.");

            Console.WriteLine();
            GetCities().Wait();
        }
    }
}
