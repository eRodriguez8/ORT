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

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Controllers
{
    [RoutePrefix("api/v1/Inventario")]
    public class InventarioController : ApiController
    {
        private readonly IInventarioBiz _invBiz;
        private readonly IExcelBiz _excelBiz;

        public InventarioController(IInventarioBiz invBiz,IExcelBiz excelBiz)
        {
            _invBiz = invBiz;
            _excelBiz = excelBiz;
        }

        [HttpPost, Route("ImportarExcel/{idInventario}/{conEncabezado}", Name = "Importar")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult ImportarExcel(int idInventario, bool conEncabezado)
        {
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(HttpContext.Current.Request.Files[0].InputStream))
            {
                fileData = binaryReader.ReadBytes(HttpContext.Current.Request.Files[0].ContentLength);
            }

            var result = _invBiz.ImportarExcel(fileData, idInventario, conEncabezado);
            return Ok(result);
        }

        [HttpPost, Route("", Name = "Crear")]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(Entities.Inventario))]
        public IHttpActionResult Crear([FromBody] InventarioAM am)
        {
            var inventario = new Entities.Inventario()
            {
                estado = Estado.Iniciado,
                cc = am.cc,
                nombre = am.nombre
            };
            var result = _invBiz.Create(inventario);
            return Ok(result);
        }

        [HttpGet, Route("xCC/{cc}", Name = "GetxCC")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Entities.Inventario))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetxCC(short cc)
        {
            var result = _invBiz.GetxCC(cc);
            return Ok(result);
        }

        [HttpGet, Route("xFechas_CC/{desde}/{hasta}/{cc}", Name = "GetxFechas_CC")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Entities.Inventario>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetxFechas_CC(string desde, string hasta, short cc)
        {
            var result = _invBiz.GetxFechas_CC(desde, hasta, cc);
            return Ok(result);
        }

        [HttpDelete, Route("{id}", Name = "Cancelar")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult Cancelar(int id)
        {
            var result = _invBiz.Cancelar(id);
            return Ok(result);
        }

        [HttpGet, Route("EstadoExcel/{id}", Name = "GetEstadoExcel")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Json))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetExcelReporteInventario(int id)
        {
            var result = _excelBiz.DescargarEstadoActual(id);
            return Json(new {bytes = result, nombre = "Estado Actual " + id });
        }
        [HttpGet, Route("ExcelPosiciones/{id}", Name = "GetExcelPosicionexInventarios")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Json))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public IHttpActionResult GetExcelPosicionexInventarios(int id)
        {
            var result = _excelBiz.DescargarPosicionexInventario(id);
            return Json(new { bytes = result, nombre = "PosicionesInventario " + id });
        }
    }
}
