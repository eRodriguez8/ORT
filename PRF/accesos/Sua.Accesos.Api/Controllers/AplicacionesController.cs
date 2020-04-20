using Corp.Cencosud.Supermercados.Sua.Accesos.Biz;
using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Api.Controllers
{
    [RoutePrefix("api/v1/Aplicaciones")]
    public class AplicacionesController : ApiController
    {
        private readonly IAplicacionBiz _aplicacionBiz;

        public AplicacionesController (IAplicacionBiz aplicacionBiz)
        {
            _aplicacionBiz = aplicacionBiz;
        }

        [HttpGet, Route("", Name = "GetAplicaciones")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Aplicacion>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetAplicaciones()
        {
            var result = _aplicacionBiz.GetAll();
            return Ok(result);

        }
    }
}
