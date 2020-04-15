using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Corp.Cencosud.Supermercados.Sua.IWMS.Web.Models
{
    public class UsuarioVM
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
        public Estado Estado { get; set; }
        public List<Perfil> Perfiles { get; set; }
    }

    public enum Estado
    {
        [Display(Name = "Activo")]
        A,
        [Display(Name = "Inactivo")]
        I
    }

    public class Perfil
    {
        public short id { get; set; }
        public short idRegion { get; set; }
        public string idAplicacion { get; set; }
        public string descripcion { get; set; }
        public string usuario { get; set; }
        public DateTime ts { get; set; }
        public Estado Estado { get; set; }
    }
}