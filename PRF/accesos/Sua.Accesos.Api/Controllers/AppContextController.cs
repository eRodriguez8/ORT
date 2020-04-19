using Corp.Cencosud.Supermercados.Sua.Accesos.Api.Helpers;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Api.Controllers
{
    [RoutePrefix("api/v1/AppContext")]
    [Authorize]
    public class AppContextController : ApiController
    {
        private readonly IAppContextBiz _appContextBiz;

        public AppContextController(IAppContextBiz appContextBiz)
        {
            _appContextBiz = appContextBiz;
        }

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpGet, Route("{idAplicacion}", Name = "AppContext"), ResponseType(typeof(AppContext))]
        public IHttpActionResult AppContext(string idAplicacion)
        {
            var result = _appContextBiz.GetContext(Security.GetUser(), idAplicacion);
            return Ok(result);

        }
    }
}    