using System;
using RestSharp;

namespace OpenWeatherExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.openweathermap.org");

            var request = new RestRequest("data/2.5/weather", Method.GET);
            request.AddParameter("q", "New York"); // replace with the city you want to get the weather for
            request.AddParameter("appid", "=abe3a0f4d0b6cebfbe7393b4b4e3aa28"); // replace with your actual API key

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine("Error retrieving weather data.");
            }

            Console.ReadLine();
        }
    }
}
