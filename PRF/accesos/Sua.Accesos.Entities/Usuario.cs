using System;
using System.Collections.Generic;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Entities
{
    [Serializable]
    public class Usuario
    {
        public short id { get; set; }
        public string usuarioAD { get; set; }
        public string legajo { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public System.DateTime fhAlta { get; set; }
        public Nullable<System.DateTime> fhBaja { get; set; }
        public string usuario { get; set; }
        public System.DateTime ts { get; set; }
        public string email { get; set; }
        private Estado _estado  { get; set; }
        public string Estado
        {
            set { _estado = (Entities.Estado) Enum.Parse(typeof(Entities.Estado),value); }
            get { return _estado.ToString(); }
        }
        public List<Perfil> Perfiles { get; set; }

        public List<Aplicacion> Aplicaciones { get; set; }
    }
}
