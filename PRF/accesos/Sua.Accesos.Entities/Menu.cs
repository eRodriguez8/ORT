using System;
using System.Collections.Generic;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Entities
{
    public class Menu
    {
        public short id { get; set; }
        public string idAplicacion { get; set; }
        public Nullable<short> idMenu_Precede { get; set; }
        public short orden { get; set; }
        public string nombre { get; set; }
        public string tooltip { get; set; }
        public string descripcion { get; set; }
        public string idEstado { get; set; }
        public string imagen { get; set; }
        public Nullable<short> usuariosMaximos { get; set; }
        public string usuario { get; set; }
        public System.DateTime ts { get; set; }
        public string url { get; set; }
        public List<Menu> SubMenu { get; set; }
    }
}