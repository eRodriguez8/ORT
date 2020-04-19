using Corp.Cencosud.Supermercados.Sua.Accesos.Api.Helpers;
using Corp.Cencosud.Supermercados.Sua.Accesos.Api.Models;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Api.Controllers
{
    [RoutePrefix("api/v1/Usuario")]
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUsuarioBiz _usuarioBiz;

        public UserController(IUsuarioBiz usuarioBiz)
        {
            _usuarioBiz = usuarioBiz;
        }

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpGet, Route("xLegajo/{legajo}/{idAplicacion}", Name = "Legajo_IdApp_old"), ResponseType(typeof(Usuario))]
        public IHttpActionResult LegajoOld(string legajo, string idAplicacion)
        {
            var result = _usuarioBiz.GetByLegajoIdAplicacion(legajo, idAplicacion);
            return Ok(result);
        }

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpGet, Route("xLegajo/{legajo}", Name = "Legajo_old"), ResponseType(typeof(Usuario))]
        public IHttpActionResult LegajoOld(string legajo)
        {
            var result = _usuarioBiz.GetxLegajoConPerfiles(legajo);
            return Ok(result);
        }
    }
}