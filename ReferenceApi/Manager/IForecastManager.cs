using ReferenceApi.DTOs;

namespace ReferenceApi.Manager
{
    public interface IForecastManager
    {
        ForecastDTO GetAllForecast(string location, int page, int pageSize, OrderBy orderBy, Direction orderDir, string user);
    }
}