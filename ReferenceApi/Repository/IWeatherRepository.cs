using ReferenceApi.Models;
using System.Linq.Expressions;

namespace ReferenceApi.Repository
{
    public interface IWeatherRepository
    {
        Task<bool> Add(Weather weather);
        IQueryable<Weather> GetByCriteria(Expression<Func<Weather, bool>> predicate, bool includeRelatedEntities = true);
        IQueryable<Weather> GetAll(bool includeRelatedEntities = true);
    }
}