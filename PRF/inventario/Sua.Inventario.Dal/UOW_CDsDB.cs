using Corp.Cencosud.Supermercados.Sua.Inventario.Dal;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Corp.Cencosud.Supermercados.Sua_Inventario.Dal
{
    /// <summary>
    /// The unit of work class serves one purpose: to make sure that when you use multiple repositories,
    /// they share a single database context.
    /// </summary>
    public class UOW_CDsDB : IDisposable, IUOW_CDsDB
    {

        private readonly CDsEntities _CDsDBContext;
        private readonly ILog Logger;

        public UOW_CDsDB(CDsEntities CDsDBContext)
        {
            _CDsDBContext = CDsDBContext;
            Logger = LogManager.GetLogger(GetType());
            _CDsDBContext.Database.Log = (dblog => Logger.Debug(dblog));
        }

        private IGenericRepository<INV_dPosiciones, CDsEntities> _INV_dPosicionesRepository;
        public IGenericRepository<INV_dPosiciones, CDsEntities> INV_dPosicionesRepository
        {
            get
            {


                if (_INV_dPosicionesRepository == null)
                {
                    _INV_dPosicionesRepository = new GenericRepository<INV_dPosiciones, CDsEntities>(_CDsDBContext);
                }
                return _INV_dPosicionesRepository;
            }
        }

        private IGenericRepository<INV_dInventario, CDsEntities> _INV_dInventarioRepository;
        public IGenericRepository<INV_dInventario, CDsEntities> INV_dInventarioRepository
        {
            get
            {


                if (_INV_dInventarioRepository == null)
                {
                    _INV_dInventarioRepository = new GenericRepository<INV_dInventario, CDsEntities>(_CDsDBContext);
                }
                return _INV_dInventarioRepository;
            }
        }


        private IGenericRepository<INV_dDocumentos, CDsEntities> _INV_dDocumentosRepository;
        public IGenericRepository<INV_dDocumentos, CDsEntities> INV_dDocumentosRepository
        {
            get
            {
                if (_INV_dDocumentosRepository == null)
                {
                    _INV_dDocumentosRepository = new GenericRepository<INV_dDocumentos, CDsEntities>(_CDsDBContext);
                }
                return _INV_dDocumentosRepository;
            }
        }

        private IGenericRepository<INV_dCCsActivos, CDsEntities> _INV_dCCsActivosRepository;
        public IGenericRepository<INV_dCCsActivos, CDsEntities> INV_dCCsActivosRepository
        {
            get
            {
                if (_INV_dCCsActivosRepository == null)
                {
                    _INV_dCCsActivosRepository = new GenericRepository<INV_dCCsActivos, CDsEntities>(_CDsDBContext);
                }
                return _INV_dCCsActivosRepository;
            }
        }

        public bool Sp_Update_Posicion(Nullable<int> id, string usuario, string digito, Nullable<double> bultosInv, string usuarioInventario, Nullable<int> hxPInv, Nullable<int> cajasSueltasInv, string observaciones, string codigoArticulo)
        {
            return _CDsDBContext.INV_dPosiciones_Update(id, usuario, digito, bultosInv, usuarioInventario, hxPInv, cajasSueltasInv, observaciones, codigoArticulo).SingleOrDefault().Value;
        }

        public string Sp_ControlForzado(int iddoc)
        {
            return _CDsDBContext.INV_dPosiciones_CrearControlForzado(iddoc).FirstOrDefault();
        }
        public void Save()
        {
            _CDsDBContext.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _CDsDBContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<INV_EstadoActual_Result> Sp_ReporteInventario(int id, int? fase)
        {
            return _CDsDBContext.INV_EstadoActual(id, fase).ToList();
        }

        public void sp_ImpactarSega(int idDoc)
        {
            _CDsDBContext.INV_dPosiciones_AjusteSega(idDoc);
        }

        public string sp_ControlAutomatico(int idDoc)
        {
            return _CDsDBContext.INV_dPosiciones_ValidarYCrearControles(idDoc).SingleOrDefault();
        }
        
    }
}