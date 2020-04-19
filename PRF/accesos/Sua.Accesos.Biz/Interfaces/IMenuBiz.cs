using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using System.Collections.Generic;


namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces
{
    public interface IMenuBiz
    {
        List<Menu> GetMenu(string idAplicacion);
    }
}
