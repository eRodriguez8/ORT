using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;
using System.Configuration;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            var origin = ConfigurationManager.AppSettings["cors"];
            var headers = "*";
            var methods = "*";
            config.MapHttpAttributeRoutes();
            EnableCorsAttribute cors = new EnableCorsAttribute(origin, headers, methods);

            cors.SupportsCredentials = true;
            config.EnableCors(cors);

            using (var handler = new RedirectHandler(m => m.RequestUri.ToString(), "swagger"))
            {
                config.Routes.MapHttpRoute(
                    name: "swagger_root",
                    routeTemplate: "",
                    defaults: null,
                    constraints: null,
                    handler: handler);
            }

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));

            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore; 
        }
    }
}
