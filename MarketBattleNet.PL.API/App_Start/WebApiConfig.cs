using MarketBattleNet.DAL.DbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MarketBattleNet.PL.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            // Web API configuration and services
            var cors = new EnableCorsAttribute("http://localhost:3919", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            Database.SetInitializer<MarketBattleNetDbContext>(null);
        }
    }
}
