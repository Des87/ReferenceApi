using Microsoft.EntityFrameworkCore;
using ReferenceApi.Models;
using System.Linq.Expressions;

namespace ReferenceApi.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly ContextDb contextDb;

        public WeatherRepository(ContextDb contextDb)
        {
            this.contextDb = contextDb;
        }

        public async Task<bool> Add(Weather weather)
        {
            try
            {
               await contextDb.Weather.AddAsync(weather);
                return true;
            }
            catch (Exception ex)
            {
                //TODO Log
                return false;
            }
        }
        public IQueryable<Weather> GetByCriteria(Expression<Func<Weather, bool>> predicate, bool includeRelatedEntities = true)
        {
            var weather = contextDb.Weather.Where(predicate);
            if (includeRelatedEntities)
            {
                weather = weather.Include(r => r.Location).Include(r => r.Current).Include(r => r.Current.Condition);
            }
            return weather;
        }
        public IQueryable<Weather> GetAll(bool includeRelatedEntities = true)
        {
            var weather = contextDb.Weather.AsQueryable();
            if (includeRelatedEntities)
            {
                weather = weather.Include(r => r.Location).Include(r => r.Current).Include(r => r.Current.Condition);
            }
            return weather;
        }
    }
}
