using System.Web.Http;

namespace MarketBattleNet.PL.API.App_Start
{
    public class IOC_Run
    {
        public static void Run()
        {
            SetAutofacWebAPIServices();
        }

        private static void SetAutofacWebAPIServices()
        {
            var configuration = GlobalConfiguration.Configuration;
            configuration.DependencyResolver = IOC.AutofacWebApiDependencyResolver();

        }
    }
}