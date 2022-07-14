namespace ReferenceApi.Models
{
    public class Current : IHasId
    {
        public Guid Id { get; set; }
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
        public virtual Condition? Condition { get; set; }
    }
}
