using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Api.Models
{
	public class UsuarioRequestVM
	{
        public string apellido { get; set; }

        public string nombre { get; set; }

        public string legajo { get; set; }

        public string usuarioAD { get; set; }

        public string email { get; set; }
    }
}