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
        //private static bool _currentObservations;

        static void Main(string[] args)
        {

            var client = new RestClient("http://api.wunderground.com/api/e61993d80592339d/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("conditions/q/{State}/{City}.json", Method.GET);

            request.AddUrlSegment("State", "AR");
            request.AddUrlSegment("City", "North_Little_Rock");

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string

            Console.WriteLine(content);

            Console.ReadLine();
        }
    }

    public enum LookupType
    {
        Zip,
        CityState,
    }

    public class WeatherManger
    {

        public WeatherInfo GetWeather(string userInput)
        {
            //determine which lookup to use
            LookupType lookupType = FigureOutLookupType(userInput);


            ILookup lookup = new WUGLookup();
            //determine if userINput is a zip or otherwise using regex
            //if it was a zip string then
            RootObject result;

            switch (lookupType)
            {
                case LookupType.Zip:
                    result = lookup.GetByZip(userInput);
                    break;
                case LookupType.CityState:
                default:
                    result = lookup.GetByCityState(userInput);
                    break;
            }


            //map result to weatherinfo
            var info = new WeatherInfo();
            //info.Temp = result.CurrentObservations.Temperature + "° F";

            return info;
        }

        private LookupType FigureOutLookupType(string userInput)
        {
            //do regex check for zip here.
            throw new NotImplementedException();
        }
    }

    public class WUGLookup
    {
    }
}
