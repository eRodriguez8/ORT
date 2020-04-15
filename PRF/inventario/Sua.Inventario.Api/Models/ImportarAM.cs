using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Models
{
    public class ImportarAM
    {
        public int idInventario { get; set; }
        public bool conEncabezado { get; set; }
    }
}