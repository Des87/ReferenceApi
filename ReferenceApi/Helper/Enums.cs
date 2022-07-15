using System.Text.Json.Serialization;

namespace ReferenceApi
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderBy
    {
        None,
        Location,
        Date
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Direction
    {
        Descending,
        Ascending
    }
}
