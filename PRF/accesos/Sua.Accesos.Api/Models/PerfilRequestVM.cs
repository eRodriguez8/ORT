using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Api.Models
{
    public class PerfilRequestVM
    {
        public short id { get; set; }
        public short idRegion { get; set; }
        public List<short> idAcciones { get; set; }
        public string idAplicacion { get; set; }
        public string descripcion { get; set; }
    }
}