using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RestSharp;
using WeatherReport;

namespace WeatherReport
{
    public interface ILookup
    {
        List<RootObject> GetByCityStateConditions(string citystate);
        List<RootObject> GetByZipConditions(string zip);
        List<Forecast10day> GetByZipForecast(string zip);
        List<Forecast10day> GetByCityStateForecast(string citystate);
        List<Hurricanes> GetHurricanes();
    }

    public class WUGLookup : ILookup
    {
        public List<Hurricanes> GetHurricanes()
        {
            //Active Hurricanes
            var client = new RestClient("http://api.wunderground.com/api/3936351a6e594384/currenthurricane/");

            var request = new RestRequest($"view.json", Method.GET);

            var response = client.Execute<List<Hurricanes>>(request);
            return response.Data;
        }

        public List<RootObject> GetByCityStateConditions(string citystate)
        {
            //Today's conditions
            var isValid = ConvertCityState(citystate);

            if (isValid)
            {
                String[] citystateSplit = citystate.Split(',');
                var client = new RestClient("http://api.wunderground.com/api/3936351a6e594384/conditions/q/");

                var request = new RestRequest($"{citystateSplit[1]}/{citystateSplit[0]}.json", Method.GET);

                var response = client.Execute<List<RootObject>>(request);
                return response.Data;
            }

            Console.WriteLine("Invalid Input");
            Console.ReadLine();
            Console.Clear();
            return new List<RootObject>();

        }

        public List<RootObject> GetByZipConditions(string zip)
        {
            //Today's conditions
            var client = new RestClient("http://api.wunderground.com/api/3936351a6e594384/conditions/q/");

            var request = new RestRequest($"{zip}.json", Method.GET);

            var response = client.Execute<List<RootObject>>(request);
            return response.Data;
        }

        public List<Forecast10day> GetByZipForecast(string zip)
        {
            //10 day Forcast
            var client = new RestClient("http://api.wunderground.com/api/3936351a6e594384/forecast10day/q/");

            var request = new RestRequest($"{zip}.json", Method.GET);

            var response = client.Execute<List<Forecast10day>>(request);
            return response.Data;
        }

        public List<Forecast10day> GetByCityStateForecast(string citystate)
        {
            //10 day Forcast
            var isValid = ConvertCityState(citystate);
            String[] citystateSplit = citystate.Split(',');

            var client = new RestClient("http://api.wunderground.com/api/3936351a6e594384/forecast10day/q/");

            var request = new RestRequest($"{citystateSplit[1]}/{citystateSplit[0]}.json", Method.GET);

            var response = client.Execute<List<Forecast10day>>(request);
            return response.Data;
        }

        public bool ConvertCityState(string citystate)
        {
            Regex rx = new Regex(@"(^[\w\s]+,\s\w{2}$)", RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(citystate);

            if (matches.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}