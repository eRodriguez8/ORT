using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Web.Http;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Controllers
{
    [RoutePrefix("api/v1/CC")]
    public class CCController : ApiController
    {
        private readonly ICCBiz _ccBiz;

        public CCController(ICCBiz ccBiz)
        {
            _ccBiz = ccBiz;
        }

        [HttpGet, Route("xIdRegion/{idRegion}", Name = "GetxIdRegion")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CC))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetxIdRegion(short idRegion)
        {
            var result = _ccBiz.GetxIdRegion(idRegion);
            return Ok(result);
        }
    }
}
