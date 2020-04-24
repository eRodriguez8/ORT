using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Models
{
    public class PosicionAM
    {
        public int id { get; set; }
        public string sector { get; set; }
        public string pasillo { get; set; }
        public string columna { get; set; }
        public string nivel { get; set; }
        public string compart { get; set; }
        public string etiqueta { get; set; }

        public string dun14 { get; set; } // TODO: ver si va
        public string ean13 { get; set; }
        public string descripcion { get; set; } 

        public string cxh { get; set; }
        public string bultos { get; set; }
        public string tipoinventario { get; set; }
    }
}
