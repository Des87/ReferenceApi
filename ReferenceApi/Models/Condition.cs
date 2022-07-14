namespace ReferenceApi.Models
{
    public class Condition : IHasId
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public string? Icon { get; set; }
        public int? Code { get; set; }
    }
}
