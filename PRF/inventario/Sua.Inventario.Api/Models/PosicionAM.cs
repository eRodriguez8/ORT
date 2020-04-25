using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Models
{
    public class PosicionAM
    {
        public int? Id { get; set; }
        public int CajasSueltas { get; set; }
        public string Tipoinventario { get; set; }
        public int idDocumento { get; set; }
        public string UsuarioInventario { get; set; }
        public string Usuario { get; set; }
        public string Ubicacion { get; set; }
        public string Articulo { get; set; }
        public string Observaciones { get; set; }
        public string Digito { get; set; }
        public double Camadas { get; set; }
        public double? iCxHActual { get; set; }

    }
}
