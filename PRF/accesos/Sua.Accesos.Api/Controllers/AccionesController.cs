using Corp.Cencosud.Supermercados.Sua.Accesos.Biz;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces;
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
    [RoutePrefix("api/v1/Acciones")]
    [Authorize]
    public class AccionesController : ApiController
    {
        private readonly IAccionBiz _accionesBiz;

        public AccionesController(IAccionBiz accionesBiz)
        {
            _accionesBiz = accionesBiz;
        }

        [HttpGet, Route("xIdAplicacion/{idApp}", Name = "GetAccionesxIdApp")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Accion>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetAccionesxIdApp(string idApp)
        {
            var result = _accionesBiz.GetByIdApp(idApp);
            return Ok(result);

        }

        [HttpGet, Route("", Name = "GetAcciones")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Accion>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetAcciones()
        {
            var result = _accionesBiz.GetAll();
            return Ok(result);

        }
    }
}
