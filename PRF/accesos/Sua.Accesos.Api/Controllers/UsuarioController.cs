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
    [RoutePrefix("api/v1/Usuarios")]
    [Authorize]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioBiz _usuarioBiz;

        public UsuarioController(IUsuarioBiz usuarioBiz)
        {
            _usuarioBiz = usuarioBiz;
        }

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpGet, Route("{dominio}/{usuarioAD}", Name = "UsuarioxDomAD"), ResponseType(typeof(Usuario))]
        public IHttpActionResult UsuarioxDomAD(string dominio, string usuarioAD)
        {
            var result = _usuarioBiz.GetxUsuarioAD(dominio + "\\" + usuarioAD);
            return Ok(result);
        }

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpGet, Route("", Name = "Usuario"), ResponseType(typeof(Usuario))]
        public IHttpActionResult Usuario()
        {
            var result = _usuarioBiz.GetxUsuarioAD(Security.GetUser());
            return Ok(result);
        }

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpGet, Route("xIdAplicacion/{idAplicacion}", Name = "UsuarioxIdAplicacion"), ResponseType(typeof(Usuario))]
        public IHttpActionResult UsuarioxIdAplicacion(string idAplicacion)
        {
            var result = _usuarioBiz.GetByIdUsuarioAplicacion(Security.GetUser(), idAplicacion);
            return Ok(result);
        }


        [HttpOptions, Route("", Name = "Options")]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(string))]
        public IHttpActionResult Options()
        {
            return Ok("ok");
        }

        [HttpPost, Route("", Name = "CrearUsuario")]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(Usuario))]
        public IHttpActionResult CrearUsuario([FromBody] UsuarioRequestVM usuario)
        {

            var user = new Entities.Usuario()
            {
                nombre = usuario.nombre,
                apellido = usuario.apellido,
                legajo = usuario.legajo,
                usuarioAD = usuario.usuarioAD,
                usuario = Security.GetUser(),
                Estado = Estado.A.ToString(),
                fhAlta = DateTime.Now,
                ts = DateTime.Now,
                email = usuario.email
            };
            var result = _usuarioBiz.Create(user);
            return Created($"Usuario/" + result.id, result);
        }

        [HttpPut, Route("Copiar/{legajoOrigen}/{legajoDestino}", Name = "CopiarUsuarioPerfil")]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(Usuario))]
        public IHttpActionResult CopiarUsuarioPerfil(string legajoOrigen, string legajoDestino)
        {
            var result = _usuarioBiz.CopiarUsuarioPerfil(legajoOrigen, legajoDestino, Security.GetUser());
            return Ok(result);
        }

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpGet, Route("xLegajo/{legajo}/{idAplicacion}", Name = "Legajo_IdApp"), ResponseType(typeof(Usuario))]
        public IHttpActionResult Legajo(string legajo, string idAplicacion)
        {
            var result = _usuarioBiz.GetByLegajoIdAplicacion(legajo, idAplicacion);
            return Ok(result);
        }

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpGet, Route("xLegajo/{legajo}", Name = "Legajo"), ResponseType(typeof(Usuario))]
        public IHttpActionResult Legajo(string legajo)
        {
            var result = _usuarioBiz.GetxLegajoConPerfiles(legajo);
            return Ok(result);
        }

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpDelete, Route("{legajo}", Name = "EliminarUsuario"), ResponseType(typeof(string))]
        public IHttpActionResult EliminarUsuario(string legajo)
        {
            var result = _usuarioBiz.Delete(legajo, Security.GetUser());
            return Ok(result);
        }

        [HttpPut, Route("", Name = "ActualizarUsuario")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Usuario))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult ActualizarUsuario([FromBody] Entities.Usuario usuario)
        {
            usuario.usuario = Security.GetUser();
            usuario.ts = DateTime.Now;
            var result = _usuarioBiz.Update(usuario);
            return Ok(result);
        }

        [HttpPut, Route("AsociarPerfil/{idPerfiles}/{legajo}", Name = "AsociarPerfil")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Usuario))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult AsociarPerfil(short idPerfiles, string legajo)
        {
            var result = _usuarioBiz.AsociarPerfil(legajo, new List<short>() { idPerfiles }, Security.GetUser());
            return Ok(result);
        }
    }
}