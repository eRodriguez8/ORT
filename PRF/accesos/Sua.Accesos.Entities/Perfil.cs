
using System;
using System.Collections.Generic;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Entities
{
    public class Perfil
    {
        public short id { get; set; }
        public short idRegion { get; set; }
        public string idAplicacion { get; set; }
        public string descripcion { get; set; }
        public string idEstado { get; set; }
        public string usuario { get; set; }
        public DateTime ts { get; set; }

        public Aplicacion Aplicacion { get; set; }
        public Estado Estado { get; set; }
        public Region Region { get; set; }
        public List<Accion> Acciones { get; set; }
    }
}
