using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Entities
{
    public class ReporteInventario
    {
        public string documento { get; set; }
        public int lineaTotales { get; set; }
        public int lineaContadas { get; set; }
        public float porcentaje { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public EstadoDocumento estado { get; set; }
        public DateTime? primeraLectura { get; set; }
        public DateTime? ultimaLectura { get; set; }
        public int tiempoOperacionMinutos { get; set; }
        public int tiempoUltimaLecturaMinutos { get; set; }
        public float promedioLineasXMinuto { get; set; }
        public float promedioDescuadre { get; set; }
        public int totalSinDescuadre { get; set; }
        public int totalDiferenciaEtiqueta { get; set; }
        public int totalDiferenciaBulto { get; set; }
        public int totalConDescuadre { get; set; }
        public int totalDescuadreArticulo { get; set; }
    }
}
