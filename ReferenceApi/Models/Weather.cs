using System.Text.Json.Serialization;

namespace ReferenceApi.Models
{
    public class Weather : IHasId
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Location? Location { get; set; }
        public virtual Current? Current { get; set; }

    }
}
