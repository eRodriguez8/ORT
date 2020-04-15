using Corp.Cencosud.Supermercados.Sua.Inventario.Api.Models;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Controllers
{
    [RoutePrefix("api/v1/Fase")]
    [Authorize]
    public class FaseController : ApiController
    {
        [HttpGet, Route("", Name = "Get")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<FaseAM>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult Get()
        {
            var result = Enum.GetValues(typeof(Fase)).Cast<Fase>().Select(x => new FaseAM()
            {
                id = (int)x,
                descripcion = x.ToString()
            }).ToList();

            return Ok(result);
        }
    }
}
