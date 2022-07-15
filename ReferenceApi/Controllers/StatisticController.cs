using Microsoft.AspNetCore.Mvc;

namespace ReferenceApi.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IUnitOfWork iUnitOfWork;

        public StatisticController(IUnitOfWork iUnitOfWork)
        {
            this.iUnitOfWork = iUnitOfWork;
        }
    }
}