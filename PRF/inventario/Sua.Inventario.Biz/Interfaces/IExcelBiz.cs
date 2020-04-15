using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using System.Collections.Generic;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces
{
    public interface IExcelBiz
    {
        byte[] DescargarEstadoActual(int idInventario);

        byte[] DescargarPosicionesExcel(int idDocumento);

        byte[] DescargarPosicionexInventario(int idInventario);
    }
}
