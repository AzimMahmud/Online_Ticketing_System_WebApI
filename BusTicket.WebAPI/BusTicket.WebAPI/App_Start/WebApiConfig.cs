using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BusTicket.WebAPI.App_Start;
using BusTicket.WebAPI.Core;
using BusTicket.WebAPI.Core.Repositories;
using BusTicket.WebAPI.Persistence;
using BusTicket.WebAPI.Persistence.Repositories;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Unity;
using Unity.Lifetime;

namespace BusTicket.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            //container.RegisterType<IMapper, Mapper>();
            config.DependencyResolver = new UnityResolver(container);


            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // setup camel-case for property names
            var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
