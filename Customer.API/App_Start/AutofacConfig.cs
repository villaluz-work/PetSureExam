using Autofac;
using Autofac.Integration.WebApi;
using Customers.Data.Interface;
using Customers.Data.Repositories;
using System.Reflection;
using System.Web.Http;

namespace Customer.API.App_Start
{
    public static class AutofacConfig
    {
        public static IContainer Container;
        public static void Register()
        {
            var container = new ContainerBuilder();

            container.RegisterApiControllers(Assembly.GetExecutingAssembly());

            container.RegisterType(typeof(CustomerRepository))
               .As(typeof(ICustomerRepository))
               .InstancePerRequest();

            Container = container.Build();

            GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver(Container);
        }
    }
}