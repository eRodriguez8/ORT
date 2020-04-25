using Corp.Cencosud.Supermercados.Sua.Inventario.Dal;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using Corp.Cencosud.Supermercados.Sua_Inventario.Dal;
using System;
using System.Collections.Generic;

namespace Sua.Inventario.Test.Biz.Fakes
{
    public class FakeUOW_CDsDB : IDisposable, IUOW_CDsDB
    {
        public FakeUOW_CDsDB()
        {
            AccessCounterSave = 0;
            AccessCounterDispose = 0;
        }

        public int AccessCounterSave { get; private set; }
        public int AccessCounterDispose { get; private set; }

        public IList<INV_dPosiciones> INV_dPosiciones { get; set; }
        public IList<INV_dInventario> INV_dInventario { get; set; }
        public IList<INV_dCCsActivos> CCs { get; set; }
        public IList<INV_dDocumentos> INV_dDocumentos { get; set; }
       
        public FakeRepository<INV_dPosiciones, CDsEntities> FakeINV_dPosicionesRepository { get; set; }
        IGenericRepository<INV_dPosiciones, CDsEntities> IUOW_CDsDB.INV_dPosicionesRepository
        {
            get
            {
                FakeINV_dPosicionesRepository = FakeINV_dPosicionesRepository ?? 
                    new FakeRepository<INV_dPosiciones, CDsEntities>(INV_dPosiciones);
                return FakeINV_dPosicionesRepository;
            }
        }

        public FakeRepository<INV_dInventario, CDsEntities> FakeINV_dInventarioRepository { get; set; }
        IGenericRepository<INV_dInventario, CDsEntities> IUOW_CDsDB.INV_dInventarioRepository
        {
            get
            {
                FakeINV_dInventarioRepository = FakeINV_dInventarioRepository ?? new FakeRepository<INV_dInventario, CDsEntities>(INV_dInventario);
                return FakeINV_dInventarioRepository;
            }
        }


        public FakeRepository<INV_dDocumentos, CDsEntities> FakeINV_dDocumentosRepository { get; set; }
        IGenericRepository<INV_dDocumentos, CDsEntities> IUOW_CDsDB.INV_dDocumentosRepository
        {
            get
            {
                FakeINV_dDocumentosRepository = FakeINV_dDocumentosRepository ?? new FakeRepository<INV_dDocumentos, CDsEntities>(INV_dDocumentos);
                return FakeINV_dDocumentosRepository;
            }
        }

        public FakeRepository<INV_dCCsActivos, CDsEntities> FakeINV_dCCsActivosRepository { get; set; }
        IGenericRepository<INV_dCCsActivos, CDsEntities> IUOW_CDsDB.INV_dCCsActivosRepository
        {
            get
            {
                FakeINV_dCCsActivosRepository = FakeINV_dCCsActivosRepository ?? new FakeRepository<INV_dCCsActivos, CDsEntities>(CCs);
                return FakeINV_dCCsActivosRepository;
            }
        }

        public void Dispose()
        {
            AccessCounterDispose++;
        }

        public void Save()
        {
            AccessCounterSave++;
        }

        public string Sp_ControlForzado(int iddoc)
        {
            return "OK";
        }

        public List<INV_EstadoActual_Result> Sp_ReporteInventario(int id, int? fase)
        {
            return new List<INV_EstadoActual_Result>();
        }

        public void sp_ImpactarSega(int idDoc)
        {
        }

        public bool Sp_Update_Posicion(int? id, string usuario, string digito, double? bultosInv, string usuarioInventario, int? hxPInv, int? cajasSueltasInv, string observaciones, string codigoArticulo)
        {
            throw new NotImplementedException();
        }

        public string sp_ControlAutomatico(int idDoc)
        {
            throw new NotImplementedException();
        }

        public bool sp_ResetDocumento(int idDoc)
        {
            throw new NotImplementedException();
        }
    }
}
