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
    [RoutePrefix("api/v1/Regiones")]
    [Authorize]
    public class RegionesController : ApiController
    {
        private readonly IRegionBiz _regionBiz;

        public RegionesController(IRegionBiz regionBiz)
        {
            _regionBiz = regionBiz;
        }

        [HttpGet, Route("", Name = "GetRegiones")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Region>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetRegiones()
        {
            var result = _regionBiz.GetAll();
            return Ok(result);

        }
    }
}
