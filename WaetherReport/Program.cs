using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using WeatherReport.WeatherReport;

namespace WeatherReport
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var userInput = GetUserInput();
                var mgr = new WeatherManager();
                var conditions = mgr.GetConditions(userInput);

                if (conditions.Any())
                {
                    Console.Clear();

                    var forecast = mgr.GetForecast(userInput);
                    var hurricanes = mgr.GetHurricanes();

                    //display Conditions
                    Console.WriteLine("\n===Current Conditions===");
                    Console.WriteLine();

                    foreach (var c in conditions)
                    {
                        Console.WriteLine($"{c.CurrentObservation.display_location.city}, " +
                                          $"{c.CurrentObservation.display_location.state_name} {c.CurrentObservation.display_location.zip}");
                        Console.WriteLine($"\nOverall: {c.CurrentObservation.weather}");
                        Console.WriteLine($"\nTemp: {c.CurrentObservation.temperature_string} " +
                                          $"Feels Like: {c.CurrentObservation.feelslike_string}");
                        Console.WriteLine($"\nPrecipitaion Today: {c.CurrentObservation.precip_today_string} " +
                                          $"Humidity: {c.CurrentObservation.relative_humidity}");
                        Console.WriteLine(
                            $"\nWind: {c.CurrentObservation.wind_string} Wind Chill: {c.CurrentObservation.windchill_string}");
                    }

                    //display forecast
                    Console.WriteLine("\n===10 Day Forecast===");
                    foreach (var f in forecast)
                    {
                        for (int i = 0; i < f.forecast.txt_forecast.forecastday.Count; i++)
                        {
                            Console.WriteLine($"\n{f.forecast.txt_forecast.forecastday[i].title}");
                            Console.WriteLine($"    {f.forecast.txt_forecast.forecastday[i].fcttext}");
                        }
                    }

                    //display hurricanes
                    Console.WriteLine("\n===Hurricanes===");

                    if (hurricanes != null)
                    {
                        foreach (var h in hurricanes)
                        {
                            Console.WriteLine($"    {h.currenthurricane.storminfo.stormName}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("     There are no hurricanes at this time");
                    }

                    Console.ReadLine();
                }
            }

        }

        public static string GetUserInput()
        {
            Console.WriteLine("Please enter a zipcode.");
            var userInput = Console.ReadLine();

            return userInput;
        }
    }
}