using Corp.Cencosud.Supermercados.Sua.Accesos.Api.Helpers;
using Corp.Cencosud.Supermercados.Sua.Accesos.Api.Models;
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
    [RoutePrefix("api/v1/Perfiles")]
    public class PerfilController : ApiController
    {
        private readonly IPerfilBiz _perfilBiz;

        public PerfilController(IPerfilBiz perfilBiz)
        {
            _perfilBiz = perfilBiz;
        }

        [HttpPost, Route("", Name = "CrearPerfil")]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(Perfil))]
        public IHttpActionResult CrearPerfil([FromBody] PerfilRequestVM perfil)
        {
            var perf = new Entities.Perfil()
            {
                id = 0,
                descripcion = perfil.descripcion,
                idAplicacion = perfil.idAplicacion,
                Acciones = new List<Accion>(),
                idEstado = Estado.A.ToString(),
                idRegion = perfil.idRegion,
                usuario = Security.GetUser(),
                ts = System.DateTime.Now
            };

            perfil.idAcciones.ForEach(x =>
            perf.Acciones.Add(new Accion() { id = x }));

            var result = _perfilBiz.Create(perf);
            return Created($"Perfil/" + result.id, result);

        }

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpDelete, Route("{id}", Name = "EliminarPerfil"), ResponseType(typeof(string))]
        public IHttpActionResult EliminarPerfil(short id)
        {
            var result = _perfilBiz.Delete(id, Security.GetUser());
            return Ok(result);

        }

        [HttpPut, Route("", Name = "ActualizarPerfil")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Usuario))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult ActualizarPerfil([FromBody] Entities.Perfil perfil)
        {
            perfil.usuario = Security.GetUser();
            perfil.ts = System.DateTime.Now;

            var result = _perfilBiz.Update(perfil);
            return Ok(result);
        }

        [HttpGet, Route("", Name = "GetAllPerfil")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Perfil>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetAllPerfil()
        {
            var result = _perfilBiz.GetAll();
            return Ok(result);
        }

        [HttpGet, Route("xRegionApp/{idRegion}/{idApp}", Name = "GetAllxRegionApp")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Perfil>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetAllxRegionApp(short idRegion, string idApp)
        {
            var result = _perfilBiz.GetAll(idRegion, idApp);
            return Ok(result);
        }
        
    }
}