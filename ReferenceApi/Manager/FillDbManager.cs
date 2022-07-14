using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReferenceApi.DTOs;
using ReferenceApi.Models;

namespace ReferenceApi.Manager
{
    public class FillDbManager
    {
        private const string apiKey = "f4a06426ad2040bf960191544221207";
        private const string url = "http://api.weatherapi.com/v1/current.json?key=";
        private readonly IUnitOfWork unitOfWork;

        public FillDbManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Weather> FullfillDb(string city)
        {
            HttpClient client = new HttpClient();
            var request = await client.GetAsync($"{url}{apiKey}&q={city}&aqi=no").Result.Content.ReadAsStringAsync(); ;

            var result = JsonConvert.DeserializeObject<WeatherDTO>(request);           
            var weather = await MappingWeather(result);
            if (weather != null)
            {
                await SaveWeather(weather);
                return weather;
            }
            return null;
        }

        private Task SaveWeather(Weather weather)
        {
            unitOfWork.weatherRepository.Add(weather);
            var success = unitOfWork.Complete();
            //TODO log
            return Task.CompletedTask;
        }

        private async Task<Weather> MappingWeather(WeatherDTO? result)
        {
            Location location = new Location();
            Current current = new Current();
            Condition condition = new Condition();
            Weather weather = new Weather()
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                Location = new Location()
                {
                    Id = Guid.NewGuid(),
                    Name = result.Location.Name,
                    Tz_id = result.Location.Tz_id,
                    Country = result.Location.Country,
                    Lat = result.Location.Lat,
                    Localtime = DateTime.Parse(result.Location.Localtime),
                    Localtime_epoch = result.Location.Localtime_epoch,
                    Lon = result.Location.Lon,
                    Region = result.Location.Region
                },
                Current = new Current()
                {
                    Id = Guid.NewGuid(),
                    Temp_c = result.Current.Temp_c,
                    Temp_f = result.Current.Temp_f,
                    Feelslike_c = result.Current.Feelslike_c,
                    Feelslike_f = result.Current.Feelslike_f,
                    Cloud = result.Current.Cloud,
                    Gust_kph = result.Current.Gust_kph,
                    Gust_mph = result.Current.Gust_mph,
                    Humidity = result.Current.Humidity,
                    Is_day = result.Current.Is_day,
                    Precip_in = result.Current.Precip_in,
                    Last_updated = result.Current.Last_updated,
                    Last_updated_epoch = result.Current.Last_updated_epoch,
                    Wind_degree = result.Current.Wind_degree,
                    Wind_dir = result.Current.Wind_dir,
                    Wind_kph = result.Current.Wind_kph,
                    Wind_mph = result.Current.Wind_mph,
                    Precip_mm = result.Current.Precip_mm,
                    Pressure_in = result.Current.Pressure_in,
                    Pressure_mb = result.Current.Pressure_mb,
                    Uv = result.Current.Uv,
                    Vis_km = result.Current.Vis_km,
                    Vis_miles = result.Current.Vis_miles,
                    Condition = new Condition()
                    {
                        Id = Guid.NewGuid(),
                        Text = result.Current.Condition.Text,
                        Code = result.Current.Condition.Code,
                        Icon = result.Current.Condition.Icon
                    }
                }
            };
            return weather;
        }
    }
}
