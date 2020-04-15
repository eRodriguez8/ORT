using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces
{
    public interface ISeguridadBiz
    {
        void ValidatePermissions();
    }
}