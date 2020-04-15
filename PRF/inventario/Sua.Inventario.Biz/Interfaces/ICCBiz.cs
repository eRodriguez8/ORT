using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using System.Collections.Generic;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces
{
    public interface ICCBiz
    {
        List<CC> GetxIdRegion(short idRegion);
    }
}
