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

        public UnitOfWork()
        {
            this.contextDb = new ContextDb();
            weatherRepository = new WeatherRepository(contextDb);
        }
        public IWeatherRepository weatherRepository { get; private set; }
        public Task<int> Complete()
        {
            return contextDb.SaveChangesAsync();
        }
    }
}
