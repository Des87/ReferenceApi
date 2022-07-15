
using ReferenceApi.Repository;

namespace ReferenceApi
{ 
    public interface IUnitOfWork
    {
        IWeatherRepository weatherRepository { get; }
        Task<int> Complete();
    }
}