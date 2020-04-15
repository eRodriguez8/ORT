using Corp.Cencosud.Supermercados.Sua.Inventario.Dal;
using System.Collections.Generic;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces
{
    public interface IInventarioBiz
    {
        string ImportarExcel(byte[] file, int idInventario, bool primeraFilaCabecera);
        Entities.Inventario Create(Entities.Inventario inv);
        Entities.Inventario GetxCC(short cc);
        List<Entities.Inventario> GetxFechas_CC(string desde, string hasta, short cc);
        Entities.Inventario GetxId(int id);
        string Cancelar(int id);
        List<INV_EstadoActual_Result> GetReporteInventario(int id, int? fase);
    }
}
