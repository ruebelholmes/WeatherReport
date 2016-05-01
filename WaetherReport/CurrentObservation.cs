namespace WeatherReport.WeatherReport
{
    public class CurrentObservation
    {
        public Image Image { get; set; }
        public DisplayLocation DisplayLocation { get; set; }
        public ObservationLocation ObservationLocation { get; set; }
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
}