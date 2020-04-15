using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corp.Cencosud.Supermercados.Sua.IWMS.Ent
{
    public class InventarioUpdate
    {
        public int? id { get; set; }
        public string usuario { get; set; }
        public string digito { get; set; }
        public double? bultosInv { get; set; }
        public string usuarioInventario { get; set; }
        public int hxPInv { get; set; }
        public int cajasSueltasInv { get; set; }
        public string observaciones { get; set; }
        public string codigoArticulo { get; set; }
    }
}
