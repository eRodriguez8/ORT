using Corp.Cencosud.Supermercados.Sua.Inventario.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua_Inventario.Dal
{
    public interface IUOW_CDsDB
    {
        IGenericRepository<INV_dPosiciones, CDsEntities> INV_dPosicionesRepository { get; }
        IGenericRepository<INV_dInventario, CDsEntities> INV_dInventarioRepository { get; }
        IGenericRepository<INV_dDocumentos, CDsEntities> INV_dDocumentosRepository { get; }
        IGenericRepository<INV_dCCsActivos, CDsEntities> INV_dCCsActivosRepository { get; }
        string Sp_ControlForzado(int iddoc);
        List<INV_EstadoActual_Result> Sp_ReporteInventario(int id, int? fase);
        void sp_ImpactarSega(int idDoc);
        bool Sp_Update_Posicion(Nullable<int> id, string usuario, string digito, Nullable<double> bultosInv, string usuarioInventario, Nullable<int> hxPInv, Nullable<int> cajasSueltasInv, string observaciones, string codigoArticulo);
        void Dispose();
        string sp_ControlAutomatico(int idDoc);
        bool sp_ResetDocumento(int idDoc);
        void Save();
    }
}
