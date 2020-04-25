using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Entities
{
    public class PosicionUpdate
    {
        public int? id { get; set; }
        public int idDocumento { get; set; }
        public string usuario { get; set; }
        public string usuarioInventario { get; set; }
        public string digito { get; set; }
        public int cajasSueltas { get; set; }
        public string tipoInventario { get; set; }
        public string observaciones { get; set; }
        public double camadas { get; set; }
        public double? iCxHActual { get; set; }
        public int registroCargado { get; set; }
        public int registroTotal { get; set; }
        public double? bultosInv { get; set; }
        public int hxPInv { get; set; }
        public int cajasSueltasInv { get; set; }
        public string articulo { get; set; }
        public string codigoArticulo { get; set; }

    }
}
