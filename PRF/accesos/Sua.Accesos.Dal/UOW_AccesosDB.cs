using log4net;
using System;

namespace Corp.Cencosud.Supermercados.Sua_Accesos.Dal
{
    /// <summary>
    /// The unit of work class serves one purpose: to make sure that when you use multiple repositories,
    /// they share a single database context.
    /// </summary>
    public class UOW_AccesosDB : IDisposable, IUOW_AccesosDB
    {

        private readonly AccesosSUAEntities _accesosDBContext;
        private readonly ILog Logger;

        public UOW_AccesosDB(AccesosSUAEntities accesosDBContext)
        {
            _accesosDBContext = accesosDBContext;
            Logger = LogManager.GetLogger(GetType());
            _accesosDBContext.Database.Log = (dblog => Logger.Debug(dblog));
        }

        private IGenericRepository<ACC_dAcciones, AccesosSUAEntities> _ACCdAccionesRepository;
        public IGenericRepository<ACC_dAcciones, AccesosSUAEntities> ACCdAccionesRepository
        {
            get
            {


                if (_ACCdAccionesRepository == null)
                {
                    _ACCdAccionesRepository = new GenericRepository<ACC_dAcciones, AccesosSUAEntities>(_accesosDBContext);
                }
                return _ACCdAccionesRepository;
            }
        }

        private IGenericRepository<ACC_dAplicaciones, AccesosSUAEntities> _ACC_dAplicacionesRepository;
        public IGenericRepository<ACC_dAplicaciones, AccesosSUAEntities> ACC_dAplicacionesRepository
        {
            get
            {
                if (_ACC_dAplicacionesRepository == null)
                {
                    _ACC_dAplicacionesRepository = new GenericRepository<ACC_dAplicaciones, AccesosSUAEntities>(_accesosDBContext);
                }
                return _ACC_dAplicacionesRepository;
            }
        }


        private IGenericRepository<ACC_dMenu, AccesosSUAEntities> _ACC_dMenuRepository;
        public IGenericRepository<ACC_dMenu, AccesosSUAEntities> ACC_dMenuRepository
        {
            get
            {
                if (_ACC_dMenuRepository == null)
                {
                    _ACC_dMenuRepository = new GenericRepository<ACC_dMenu, AccesosSUAEntities>(_accesosDBContext);
                }
                return _ACC_dMenuRepository;
            }
        }

        private IGenericRepository<ACC_dPerfiles, AccesosSUAEntities> _ACC_dPerfilesRepository;
        public IGenericRepository<ACC_dPerfiles, AccesosSUAEntities> ACC_dPerfilesRepository
        {
            get
            {
                if (_ACC_dPerfilesRepository == null)
                {
                    _ACC_dPerfilesRepository = new GenericRepository<ACC_dPerfiles, AccesosSUAEntities>(_accesosDBContext);
                }
                return _ACC_dPerfilesRepository;
            }
        }

        private IGenericRepository<ACC_dUsuarios, AccesosSUAEntities> _ACC_dUsuariosRepository;
        public IGenericRepository<ACC_dUsuarios, AccesosSUAEntities> ACC_dUsuariosRepository
        {
            get
            {
                if (_ACC_dUsuariosRepository == null)
                {
                    _ACC_dUsuariosRepository = new GenericRepository<ACC_dUsuarios, AccesosSUAEntities>(_accesosDBContext);
                }
                return _ACC_dUsuariosRepository;
            }
        }

        private IGenericRepository<ACC_sEstados, AccesosSUAEntities> _ACC_sEstadosRepository;
        public IGenericRepository<ACC_sEstados, AccesosSUAEntities> ACC_sEstadosRepository
        {
            get
            {
                if (_ACC_sEstadosRepository == null)
                {
                    _ACC_sEstadosRepository = new GenericRepository<ACC_sEstados, AccesosSUAEntities>(_accesosDBContext);
                }
                return _ACC_sEstadosRepository;
            }
        }

        private IGenericRepository<ACC_sRegiones, AccesosSUAEntities> _ACC_sRegionesRepository;
        public IGenericRepository<ACC_sRegiones, AccesosSUAEntities> ACC_sRegionesRepository
        {
            get
            {
                if (_ACC_sRegionesRepository == null)
                {
                    _ACC_sRegionesRepository = new GenericRepository<ACC_sRegiones, AccesosSUAEntities>(_accesosDBContext);
                }
                return _ACC_sRegionesRepository;
            }
        }

        private IGenericRepository<ACC_rdMenu_dAcciones, AccesosSUAEntities> _ACC_rdMenu_dAccionesRepository;
        public IGenericRepository<ACC_rdMenu_dAcciones, AccesosSUAEntities> ACC_rdMenu_dAccionesRepository
        {
            get
            {
                if (_ACC_rdMenu_dAccionesRepository == null)
                {
                    _ACC_rdMenu_dAccionesRepository = new GenericRepository<ACC_rdMenu_dAcciones, AccesosSUAEntities>(_accesosDBContext);
                }
                return _ACC_rdMenu_dAccionesRepository;
            }
        }

        private IGenericRepository<ACC_rdPerfil_dAcciones, AccesosSUAEntities> _ACC_rdPerfil_dAccionesRepository;
        public IGenericRepository<ACC_rdPerfil_dAcciones, AccesosSUAEntities> ACC_rdPerfil_dAccionesRepository
        {
            get
            {
                if (_ACC_rdPerfil_dAccionesRepository == null)
                {
                    _ACC_rdPerfil_dAccionesRepository = new GenericRepository<ACC_rdPerfil_dAcciones, AccesosSUAEntities>(_accesosDBContext);
                }
                return _ACC_rdPerfil_dAccionesRepository;
            }
        }

        private IGenericRepository<ACC_rdUsuarios_dPerfiles_dAcciones, AccesosSUAEntities> _ACC_rdUsuarios_dPerfiles_dAccionesRepository;
        public IGenericRepository<ACC_rdUsuarios_dPerfiles_dAcciones, AccesosSUAEntities> ACC_rdUsuarios_dPerfiles_dAccionesRepository
        {
            get
            {
                if (_ACC_rdUsuarios_dPerfiles_dAccionesRepository == null)
                {
                    _ACC_rdUsuarios_dPerfiles_dAccionesRepository = new GenericRepository<ACC_rdUsuarios_dPerfiles_dAcciones, AccesosSUAEntities>(_accesosDBContext);
                }
                return _ACC_rdUsuarios_dPerfiles_dAccionesRepository;
            }
        }

        public void Save()
        {
            _accesosDBContext.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _accesosDBContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}