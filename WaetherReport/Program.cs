using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WeatherReport
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://api.wunderground.com/api/e61993d80592339d/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("conditions/q/{State}/{City}.json", Method.GET);

            request.AddUrlSegment("State", "AR");
            request.AddUrlSegment("City", "Little Rock");

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string

            Console.WriteLine(content);
            Console.ReadLine();
        }
    }


    public class Features
    {
        public int conditions { get; set; }
    }

    public class Response
    {
        public string version { get; set; }
        public string termsofService { get; set; }
        public Features features { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }

    public class DisplayLocation
    {
        public string Full { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateName { get; set; }
        public string Country { get; set; }
        public string CountryIso3166 { get; set; }
        public string Zip { get; set; }
        public string Magic { get; set; }
        public string Wmo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Elevation { get; set; }
    }

    public class ObservationLocation
    {
        public string Full { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CountryIso3166 { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Elevation { get; set; }
    }

    public class Estimated
    {
    }

    public class CurrentObservation
    {
        public Image Image { get; set; }
        public DisplayLocation DisplayLocation { get; set; }
        public ObservationLocation ObservationLocation { get; set; }
        public Estimated Estimated { get; set; }
        public string StationId { get; set; }
        public string ObservationTime { get; set; }
        public string ObservationTimeRfc822 { get; set; }
        public string ObservationEpoch { get; set; }
        public string LocalTimeRfc822 { get; set; }
        public string LocalEpoch { get; set; }
        public string LocalTzShort { get; set; }
        public string LocalTzLong { get; set; }
        public string LocalTzOffset { get; set; }
        public string Weather { get; set; }
        public string TemperatureString { get; set; }
        public double TempF { get; set; }
        public double TempC { get; set; }
        public string RelativeHumidity { get; set; }
        public string WindString { get; set; }
        public string WindDir { get; set; }
        public int WindDegrees { get; set; }
        public double WindMph { get; set; }
        public string WindGustMph { get; set; }
        public double WindKph { get; set; }
        public string WindGustKph { get; set; }
        public string PressureMb { get; set; }
        public string PressureIn { get; set; }
        public string PressureTrend { get; set; }
        public string DewpointString { get; set; }
        public int DewpointF { get; set; }
        public int DewpointC { get; set; }
        public string HeatIndexString { get; set; }
        public string HeatIndexF { get; set; }
        public string HeatIndexC { get; set; }
        public string WindchillString { get; set; }
        public string WindchillF { get; set; }
        public string WindchillC { get; set; }
        public string FeelslikeString { get; set; }
        public string FeelslikeF { get; set; }
        public string FeelslikeC { get; set; }
        public string VisibilityMi { get; set; }
        public string VisibilityKm { get; set; }
        public string Solarradiation { get; set; }
        public string UV { get; set; }
        public string Precip1HrString { get; set; }
        public string Precip1HrIn { get; set; }
        public string Precip1HrMetric { get; set; }
        public string PrecipTodayString { get; set; }
        public string PrecipTodayIn { get; set; }
        public string PrecipTodayMetric { get; set; }
        public string Icon { get; set; }
        public string IconUrl { get; set; }
        public string ForecastUrl { get; set; }
        public string HistoryUrl { get; set; }
        public string ObUrl { get; set; }
        public string Nowcast { get; set; }
    }

    public class RootObject
    {
        public Response Response { get; set; }
        public CurrentObservation CurrentObservation { get; set; }
    }

}
