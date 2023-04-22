using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var apiKey = "YOUR_API_KEY";
            var city = "New York"; // replace with the city you want to get the weather for

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://api.openweathermap.org/data/2.5/weather?q=Anakapalle&appid=abe3a0f4d0b6cebfbe7393b4b4e3aa28&units=metric");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Error retrieving weather data.");
            }

            Console.ReadLine();
        }
    }
}
