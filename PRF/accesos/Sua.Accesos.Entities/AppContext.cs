using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Entities
{
    public class AppContext
    {
        public Usuario usuario { get; set; }
        public List<Menu> menu { get; set; }
    }
}
