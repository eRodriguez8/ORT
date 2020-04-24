using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Models
{
    public class DocumentoAM
    {
        public int id { get; set; }
        public string documento { get; set; }
        public List<PosicionAM> posiciones { get; set; }
        public int? lTotales  { get; set; }
        public int? lContadas  { get; set; }
    }
}
