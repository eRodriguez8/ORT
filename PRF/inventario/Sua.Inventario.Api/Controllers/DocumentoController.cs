using Corp.Cencosud.Supermercados.Sua.Inventario.Api.Models;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Controllers
{
    [RoutePrefix("api/v1/Documento")]
    [Authorize]
    public class DocumentoController : ApiController
    {
        private readonly IDocumentoBiz _documentoBiz;

        public DocumentoController(IDocumentoBiz documentoBiz)
        {
            _documentoBiz = documentoBiz;
        }

        [HttpGet, Route("{idDocumento}", Name = "xIdDocumento")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Documento))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult Get(short id)
        {
            var result = _documentoBiz.GetById(id);
            return Ok(result);
        }

        [HttpGet, Route("xIdInventario/{idInventario}", Name = "Documentos")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Documento>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetAll(int idInventario)
        {
            var result = _documentoBiz.GetAll(idInventario);
            return Ok(result);
        }

        [HttpPost, Route("xFiltros", Name = "xFiltros")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Documento>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetAllxFiltros([FromBody] DocFiltroAM doc)
        {
            var result = _documentoBiz.GetAllxFiltros(doc.pasillo, doc.columna, doc.nivel, doc.documento, doc.fase, doc.idInventario,doc.estado,doc.legajo);
            return Ok(result);
        }

        [HttpPost, Route("Asignacion/{id}/{legajo}", Name = "Asignar")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult Asignar(int id, string legajo)
        {
            var result = _documentoBiz.Asignar(id, legajo);
            return Ok(result);
        }

        [HttpPost, Route("Desasignacion/{idDoc}", Name = "Desasignar")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult Desasignar(int idDoc)
        {
            var result = _documentoBiz.Desasignar(idDoc);
            return Ok(result);
        }

        [HttpDelete, Route("CancelarDocumento/{idDocumento}", Name = "CancelarDocumento")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult CancelarDocumento(int idDocumento)
        {
            var result = _documentoBiz.CancelarDocumentoxId(idDocumento);
            return Ok(result);
        }

        [HttpPost, Route("ControlManual/{idDoc}", Name = "ControlManual")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult ControlManual(int idDoc)
        {
            var result = _documentoBiz.ControlForzado(idDoc);
            return Ok(result);
        }
    }
}
