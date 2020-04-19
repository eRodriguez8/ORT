using System.Web.Http;
using WebActivatorEx;
using Corp.Cencosud.Supermercados.Sua.Accesos.Api;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Api
{
    public static class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Corp.Cencosud.Supermercados.Sua.Accesos.Api");
                        
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DisableValidator();
                    });
        }
    }
}
