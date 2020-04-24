using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using System.Collections.Generic;
using System.Dynamic;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces
{
    public interface IDocumentoBiz
    {
        List<Documento> GetByIdInventario(int idInventario);
        Documento GetById(int id);
        List<Documento> InsertBulk(List<Documento> documentos);
        List<Documento> GetAll(int idInventario);
        List<Documento> GetAllxFiltros(string pasillo, double? columna, double? nivel, string documento, int? fase, int idInventario,int? estado,string legajo);
        string Asignar(int idDoc, string legajo);
        string Desasignar(int idDoc);
        void CancelarDocumentosxIdInventario(int idInventario);
        string CancelarDocumentoxId(int idDoc);
        string ControlForzado(int idDoc);
        string UpdateEstadoSega(int idDoc);
        Documento GetByLegajo(string legajo);
    }
}
