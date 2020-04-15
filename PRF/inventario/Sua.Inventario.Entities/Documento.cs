using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Entities
{
    public class Documento
    {
        public int id { get; set; }
        public string documento { get; set; }
        public string legajoAsignado { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public EstadoDocumento estado { get; set; }
        public System.DateTime fecha { get; set; }
        public string usuario { get; set; }

        public int idInventario { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Fase fase { get; set; }
        public int? idDocumentoPadre { get; set; }
        public List<Posicion> posiciones { get; set; }


        public int? lTotales  { get; set; }
        public int? lContadas  { get; set; }
        public int? porcentaje  { get; set; }
        public System.DateTime? pLectura { get; set; }
        public System.DateTime? uLectura { get; set; }
        public double? tOperacionMin  { get; set; }
        public double? tUltimaLectura  { get; set; }
        public double? promLineasxMin  { get; set; }
        public int? promLineasDescuadre { get; set; }
        public Documento documentoPadre { get; set; }
        public string ultimoLegajoAsignado { get; set; }
        public bool? impactadoSega { get; set; }


    }
}
