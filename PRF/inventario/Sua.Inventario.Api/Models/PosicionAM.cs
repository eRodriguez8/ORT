using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Models
{
    public class PosicionAM
    {
        public int? id { get; set; }
        public int idDocumento { get; set; }
        public string usuarioInventario { get; set; }
        public string digito { get; set; }
        public int cajas { get; set; }
        public int cajasSueltas { get; set; }
        public string tipoInventario { get; set; }
        public string observaciones { get; set; }
        public double camadas { get; set; }
        public double? iCxHActual { get; set; }
        public string articulo { get; set; }
        public string etiqueta { get; set; }
        public string ubicacion { get; set; }
        public string ean13 { get; set; }
        public string descripcion { get; set; }
    }
}
