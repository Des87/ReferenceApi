using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReferenceApi.Models;

namespace ReferenceApi.Manager
{
    public class FullfillDbManager
    {
        private const string apiKey = "f4a06426ad2040bf960191544221207";
        private const string url = "http://api.weatherapi.com/v1/current.json?key=";
        public async Task FullfillDb()
        {
            HttpClient client = new HttpClient();
            var request = await client.GetAsync($"{url}{apiKey}&q=Budapest&aqi=no");
            int i = 5;

            var t = await request.Content.ReadAsStringAsync();
            var r = JObject.Parse(t);
            Weather result = new Weather()
            {
                Wind_mph = 5
            };

            result = JsonConvert.DeserializeAnonymousType(t, result);

        }
    }
}
