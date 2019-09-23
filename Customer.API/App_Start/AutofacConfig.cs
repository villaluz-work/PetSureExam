using Autofac;
using Autofac.Integration.WebApi;
using Customers.Data;
using Customers.Data.Interface;
using Customers.Data.Repositories;
using System.Data.Entity;
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
            //register the controller
            container.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //register customer repository
            container.RegisterType(typeof(CustomerRepository))
               .As(typeof(ICustomerRepository))
               .InstancePerRequest();
            //register context
            container.RegisterType<CustomerContext>().InstancePerRequest();
            //create the container
            Container = container.Build();

            GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver(Container);
        }
    }
}