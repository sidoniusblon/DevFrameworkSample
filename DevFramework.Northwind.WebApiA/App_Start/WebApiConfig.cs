﻿using DevFramework.Northwind.WebApiA.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DevFramework.Northwind.WebApiA
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API yapılandırması ve hizmetleri
            config.MessageHandlers.Add(new AuthenticationHandler());
            // Web API yolları
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
