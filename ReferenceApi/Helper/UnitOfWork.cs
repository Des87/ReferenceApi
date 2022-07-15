using ReferenceApi.Helper;
using ReferenceApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceApi
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextDb contextDb;
        private readonly UserInfoDb userInfoDb;

        public UnitOfWork()
        {
            this.contextDb = new ContextDb();
            this.userInfoDb = new UserInfoDb();
            weatherRepository = new WeatherRepository(contextDb);
            userInfoRepository = new UserInfoRepository(userInfoDb);
            tokenhelper = new Tokenhelper();
        }
        public IWeatherRepository weatherRepository { get; private set; }
        public IUserInfoRepository userInfoRepository { get; private set; }
        public ITokenhelper tokenhelper { get; private set; }

        public Task<int> Complete()
        {
            return contextDb.SaveChangesAsync();
        }
        public void Dispose()
        {
             contextDb.Dispose();
            userInfoDb.Dispose();
        }
    }
}
