using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Entities
{
    public class Accion
    {
        public short id { get; set; }

        public string idAplicacion { get; set; }

        public string descripcion { get; set; }

        public string idEstado { get; set; }

        public string usuario { get; set; }

        public System.DateTime ts { get; set; }

        public Aplicacion Aplicacion{ get; set; }

        public Estado Estado { get; set; }
    }
}
