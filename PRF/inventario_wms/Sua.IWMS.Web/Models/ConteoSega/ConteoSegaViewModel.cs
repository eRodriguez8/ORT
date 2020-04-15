using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corp.Cencosud.Supermercados.Sua.IWMS.Web.Models.ConteoSega
{
    public class ConteoSegaViewModel
    {
        public int? Id { get; set; }
        public int? Indice { get; set; }
        public int CajasSueltas { get; set; }
        public int? RegistroCargado { get; set; }
        public int? RegistroTotal { get; set; }

        public int idDocumento { get; set; }
        public string Documento { get; set; }
        public string UsuarioInventario { get; set; }
        public string Usuario { get; set; }
        public string Ubicacion { get; set; }
        public string Articulo { get; set; }
        public string TipoInventario { get; set; }
        public string Observaciones { get; set; }
        public string MsgError { get; set; }
        public string Etiqueta { get; set; }
        public string Digito { get; set; }

        public bool Leido { get; set; }
        public bool First { get; set; }
        public bool Finalizado { get; set; }

        public double Camadas { get; set; }
        public double Bulto { get; set; }
        public double? iCxHActual { get; set; }

        public ConteoSegaViewModel()
        {
            Documento = "";
            UsuarioInventario = "";
            Ubicacion = "";
            Digito = "0";
            Camadas = 0;
            CajasSueltas = 0;
            Observaciones = "";
            Leido = false;
            First = true;
            TipoInventario = "";
            Indice = 0;
            RegistroCargado = 0;
            RegistroTotal = 0;
            MsgError = "";
            Finalizado = false;
        }
    }
}