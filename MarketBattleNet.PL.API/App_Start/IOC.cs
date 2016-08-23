using Autofac;
using Autofac.Integration.WebApi;
using MarketBattleNet.BLL.Repository;
using MarketBattleNet.BLL.Service;
using MarketBattleNet.BLL.ServiceInterface;
using MarketBattleNet.DAL.DbContext;
using MarketBattleNet.DAL.RepositoryInterface;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Http.Controllers;

namespace MarketBattleNet.PL.API.App_Start
{
    public class IOC
    {
        public static AutofacWebApiDependencyResolver AutofacWebApiDependencyResolver()
        {
            var builder = new ContainerBuilder();

            // Register API controllers using assembly scanning.
            builder.RegisterApiControllers(Assembly.GetCallingAssembly());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                 .Where(t => typeof(IHttpController).IsAssignableFrom(t) && t.Name.EndsWith("Controller"));

            //Db connection
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.Register<DbContext>(c => new MarketBattleNerDbContext());

            builder.RegisterType<ArtService>().As<IArtService>().InstancePerRequest();
            builder.RegisterType<RequestService>().As<IRequestService>().InstancePerRequest();
            builder.RegisterType<ServiceService>().As<IServiceService>().InstancePerRequest();
            builder.RegisterType<UserProfileService>().As<IUserProfileService>().InstancePerRequest();

            var container = builder.Build();

            // Set the dependency resolver implementation.
            var resolver = new AutofacWebApiDependencyResolver(container);

            return resolver;

        }
    }
}