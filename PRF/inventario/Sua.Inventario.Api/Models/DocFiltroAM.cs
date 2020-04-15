using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Models
{
    public class DocFiltroAM
    {
        public string pasillo { get; set; }
        public double? columna { get; set; }
        public double? nivel { get; set; }
        public string documento { get; set; }
        public int? fase { get; set; }
        public int idInventario { get; set; }
        public int? estado { get; set; }
        public string legajo { get; set; }

    }
    }