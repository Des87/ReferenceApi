namespace ReferenceApi.Models
{
    public class Location : IHasId
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string? Tz_id { get; set; }
        public string? Localtime_epoch { get; set; }
        public DateTime Localtime { get; set; }
    }
}
