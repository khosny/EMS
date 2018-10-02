using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EMS.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "MatchRequestApi",
                routeTemplate: "api/{controller}/{personId}/{sectorId}",
                defaults: new { sectorId = RouteParameter.Optional, investorId = RouteParameter.Optional }
            );
        }
    }
}
