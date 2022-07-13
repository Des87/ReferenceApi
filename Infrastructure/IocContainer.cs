using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class IocContainer
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();


           
           // builder.RegisterType<NullCheckDatabase>().As<INullCheckDatabase>();

            builder.RegisterType<ContextDb>().SingleInstance();


            return builder.Build();
        }
    }
}
