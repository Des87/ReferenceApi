
using ReferenceApi.Helper;
using ReferenceApi.Repository;

namespace ReferenceApi
{ 
    public interface IUnitOfWork
    {
        IWeatherRepository weatherRepository { get; }
        IUserInfoRepository userInfoRepository { get; }
        ITokenhelper tokenhelper { get; }

        Task<int> Complete();
        void Dispose();
    }
}