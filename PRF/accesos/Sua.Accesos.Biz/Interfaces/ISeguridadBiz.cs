using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces
{
    public interface ISeguridadBiz
    {
        Usuario GetUsuario();

        void ValidatePermissions();
    }
}