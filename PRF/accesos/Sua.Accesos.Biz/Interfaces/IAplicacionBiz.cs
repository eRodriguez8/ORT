using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using System.Collections.Generic;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz
{
    public interface IAplicacionBiz
    {
        Aplicacion GetxId(string id);
        List<Aplicacion> GetAll();
    }
}