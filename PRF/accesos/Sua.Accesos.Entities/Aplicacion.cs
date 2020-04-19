using System;
using System.Collections.Generic;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Entities
{
    [Serializable]
    public class Aplicacion
    {
        public string id { get; set; }
        public string descripcion { get; set; }
        public string accesos { get; set; }
        public System.DateTime ts { get; set; }
        public bool esPocket { get; set; }
        public string tooltip { get; set; }
        public string imagen { get; set; }
        public string url { get; set; }

        public List<Accion> Acciones { get; set; }
        public Estado Estado { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Perfil> Perfiles { get; set; }
    }
}
