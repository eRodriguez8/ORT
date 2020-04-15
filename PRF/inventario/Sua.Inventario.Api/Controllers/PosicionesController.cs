using System;
using Corp.Cencosud.Supermercados.Sua.Inventario.Api.Models;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Transactions;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Controllers
{
    [RoutePrefix("api/v1/Posicion")]
    [Authorize]
    public class PosicionesController : ApiController
    {
        private readonly IPosicionesBiz _posBiz;
        private readonly IExcelBiz _excelBiz;
        private readonly IDocumentoBiz _docBiz;

        public PosicionesController(IPosicionesBiz posBiz, IExcelBiz excelBiz, IDocumentoBiz docBiz)
        {
            _posBiz = posBiz;
            _excelBiz = excelBiz;
            _docBiz = docBiz;
        }

        [HttpGet, Route("xDocumentoId/{idDoc}", Name = "GetxDocumentoId")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Entities.Inventario))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetxDocumentoId(int idDoc)
        {
            var result = _posBiz.GetxDocumentoId(idDoc);
            return Ok(result);
        }

        [HttpPost, Route("xFiltrosPos", Name = "xFiltrosPos")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Documento>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetAllxFiltros([FromBody] DocFiltroAM doc)
        {
            var result = _posBiz.GetAllxFiltros(doc.pasillo, doc.columna, doc.nivel, doc.idInventario);
            return Ok(result);
        }
        [HttpGet, Route("ExportarExcel/{id}", Name = "ExportarExcel")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Json))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetExcelPosiciones(int id)
        {
            var result = _excelBiz.DescargarPosicionesExcel(id);
            return Json(new { bytes = result, nombre = "Posiciones Documento " + id });
        }
        [HttpPut, Route("ImpactarSega/{id}", Name = "ImpactarSega")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult ImpactarSega(int id )
        {
            //var documento = _docBiz.GetById(id);
            //var posiciones = _posBiz.GetxDocumentoId(id);
            //posiciones.ForEach(x => _posBiz.ImpactarSega(x.estado, x.etiqueta, x.ean13, x.bultosinv));
            //_docBiz.UpdateEstadoSega(id);
            _posBiz.ImpactarSega(id);
            return Ok();

        }
    }
}
