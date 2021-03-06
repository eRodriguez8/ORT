﻿using Corp.Cencosud.Supermercados.Sua.Inventario.Api.Models;
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
            foreach (var pos in documento.posiciones)
            {
                var posAm = Mapper.GetBindedModel<PosicionAM>(pos);
                posAm.ubicacion = $"{pos.sector} - {pos.pasillo} - {pos.columna} -  {pos.compart}";
                posAm.tipoInventario = pos.tipoinventario;
                posAm.ean13 = pos.ean13;
                posAm.etiqueta = pos.etiqueta;
                posAm.articulo = pos.codigoarticulo;
                posAm.cajasSueltas = pos.cajassueltasinv;
                posAm.camadas = pos.bultosinv.HasValue ? pos.bultosinv.Value : 0;
                docAm.posiciones.Add(posAm);
            }
            
            return Ok(docAm);
        }

        [HttpPut, Route("xPosicion", Name = "xPosicion")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(PosicionAM))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult UpdatePosicion([FromBody]PosicionAM posAm)
        {
            if (!ModelState.IsValid)
                return BadRequest("posicion invalida");

            var posicion = Mapper.GetBindedModel<PosicionUpdate>(posAm);

            return Ok(_posBiz.UpdatePosicion(posicion));
        }

        [HttpPut, Route("{idDoc}", Name = "xIdDoc")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult ResetDocumento(int idDoc)
        {
            return Ok(_posBiz.ResetPosicion(idDoc));
        }
    }
}
