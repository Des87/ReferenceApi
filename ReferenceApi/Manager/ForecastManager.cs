using ReferenceApi.DTOs;
using ReferenceApi.Models;

namespace ReferenceApi.Manager
{
    public class ForecastManager : IForecastManager
    {
        private readonly IUnitOfWork unitOfWork;

        public ForecastManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ForecastDTO GetAllForecast(string location, int page, int pageSize, OrderBy orderBy, Direction orderDir, string user)
        {
            var weathers = GetWeathers(location, orderBy, orderDir);

            ForecastDTO forecastDTO = new ForecastDTO()
            {
                User = user,
                CountOf = weathers.Count(),
                Page = page,
                Weathers = weathers.Skip((page - 1) * pageSize).Take(pageSize).ToList()
            };
            forecastDTO.PageSize = forecastDTO.Weathers.Count();

            return forecastDTO;
        }

        private List<Weather> GetWeathers(string location, OrderBy orderBy, Direction orderDir)
        {
            List<Weather> weathers = new List<Weather>();
            if (!string.IsNullOrWhiteSpace(location))
            {
                weathers = unitOfWork.weatherRepository.GetByCriteria(x => x.Location.Name == location).ToList();
                if (orderBy == OrderBy.Location && orderDir == Direction.Descending)
                {
                    weathers = weathers.OrderByDescending(x => x.Location?.Name).ToList();
                }
                else if (orderBy == OrderBy.Location && orderDir == Direction.Ascending)
                {
                    weathers = weathers.OrderBy(x => x.Location?.Name).ToList();
                }
                else if (orderBy == OrderBy.Date && orderDir == Direction.Descending)
                {
                    weathers = weathers.OrderByDescending(x => x.CreatedOn).ToList();
                }
                else if (orderBy == OrderBy.Date && orderDir == Direction.Ascending)
                {
                    weathers = weathers.OrderBy(x => x.CreatedOn).ToList();
                }
            }
            else
            {
                weathers = unitOfWork.weatherRepository.GetAll().ToList();
                if (orderBy == OrderBy.Location && orderDir == Direction.Descending)
                {
                    weathers = weathers.OrderByDescending(x => x.Location?.Name).ToList();
                }
                else if (orderBy == OrderBy.Location && orderDir == Direction.Ascending)
                {
                    weathers = weathers.OrderBy(x => x.Location?.Name).ToList();
                }
                else if (orderBy == OrderBy.Date && orderDir == Direction.Descending)
                {
                    weathers = weathers.OrderByDescending(x => x.CreatedOn).ToList();
                }
                else if (orderBy == OrderBy.Date && orderDir == Direction.Ascending)
                {
                    weathers = weathers.OrderBy(x => x.CreatedOn).ToList();
                }
            }
            return weathers;
        }
    }
}
