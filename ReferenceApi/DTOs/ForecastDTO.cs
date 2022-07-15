using ReferenceApi.Models;

namespace ReferenceApi.DTOs
{
    public class ForecastDTO
    {
        public string? User { get; set; }
        public int CountOf { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public List<Weather>? Weathers { get; set; }
    }
}
