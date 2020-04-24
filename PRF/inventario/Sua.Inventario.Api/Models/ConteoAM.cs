using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Models
{
    public class ConteoAM
    {
        public string usuario { get; set; }
        public string digito { get; set; }
        public double? bultosinv { get; set; }
        public DateTime? ts { get; set; }
        public string fechaact { get; set; }
        public string usuarioinventario { get; set; }
        public int? hxpinv { get; set; }
    }
}
