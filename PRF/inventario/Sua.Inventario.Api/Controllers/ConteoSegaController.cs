using Corp.Cencosud.Supermercados.Sua.Inventario.Api.Models;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz;
using Corp.Cencosud.Supermercados.Sua.Inventario.Api.Helpers;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Controllers
{
    [RoutePrefix("api/v1/ConteoSega")]
    public class ConteoSegaController : ApiController
    {
        private readonly IDocumentoBiz _docBiz;
        private readonly IPosicionesBiz _posBiz;

        public ConteoSegaController(IDocumentoBiz docBiz, IPosicionesBiz posBiz)
        {
            _docBiz = docBiz;
            _posBiz = posBiz;
        }


        [HttpGet, Route("{legajo}", Name = "xLegajo")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Documento))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetByLegajo(string legajo)
        {
            var documento = _docBiz.GetByLegajo(legajo);
            if (documento == null)
                return BadRequest(string.Format("Legajo {0} no contiene documento asociado", legajo));

            var docAm = Mapper.GetBindedModel<DocumentoAM>(documento);
            docAm.posiciones = new List<PosicionAM>();
            foreach (var pos in documento.posiciones) {
                docAm.posiciones.Add(Mapper.GetBindedModel<PosicionAM>(pos));
            }
            
            return Ok(docAm);
        }

        [HttpPut, Route("{posicion}", Name = "xPosicion")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Documento))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult UpdatePosicion(PosicionAM posAm)
        {
            if (!ModelState.IsValid)
                return BadRequest("posicion invalida");

            var posicion = Mapper.GetBindedModel<PosicionUpdate>(posAm);

            return Ok(_posBiz.UpdatePosicion(posicion));
        }
    }
}
