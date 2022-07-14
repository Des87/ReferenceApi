namespace ReferenceApi.DTOs
{
    public class WeatherDTO
    {
        public LocationDTO? Location { get; set; }
        public CurrentDTO? Current { get; set; }
    }
    public class LocationDTO
    {
        public string? Name { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string? Tz_id { get; set; }
        public string? Localtime_epoch { get; set; }
        public string? Localtime { get; set; }
    }
    public class CurrentDTO
    {
        public string? Last_updated_epoch { get; set; }
        public string? Last_updated { get; set; }
        public string? Temp_c { get; set; }
        public string? Temp_f { get; set; }
        public string? Is_day { get; set; }
        public decimal Wind_mph { get; set; }
        public decimal Wind_kph { get; set; }
        public decimal Wind_degree { get; set; }
        public string? Wind_dir { get; set; }
        public decimal Pressure_mb { get; set; }
        public decimal Pressure_in { get; set; }
        public decimal Precip_mm { get; set; }
        public decimal Precip_in { get; set; }
        public decimal Humidity { get; set; }
        public decimal Cloud { get; set; }
        public decimal Feelslike_c { get; set; }
        public decimal Feelslike_f { get; set; }
        public decimal Vis_km { get; set; }
        public decimal Vis_miles { get; set; }
        public decimal Uv { get; set; }
        public decimal Gust_mph { get; set; }
        public decimal Gust_kph { get; set; }
        public ConditionDTO? Condition { get; set; }
    }
    public class ConditionDTO
    {
        public string? Text { get; set; }
        public string? Icon { get; set; }
        public int Code { get; set; }
    }
}
