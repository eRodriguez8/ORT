using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using System;
using System.Collections.Generic;

namespace Sua.Accesos.Test.Biz.Fakes
{
    public class FakeUOW_AccesosDB : IDisposable, IUOW_AccesosDB
    {
        public FakeUOW_AccesosDB()
        {
            AccessCounterSave = 0;
            AccessCounterDispose = 0;
        }

        public int AccessCounterSave { get; private set; }
        public int AccessCounterDispose { get; private set; }

        public IList<ACC_dAcciones> ACC_dAcciones { get; set; }
        public IList<ACC_dAplicaciones> ACC_dAplicaciones { get; set; }
        public IList<ACC_dMenu> ACC_dMenu { get; set; }
        public IList<ACC_dPerfiles> ACC_dPerfiles { get; set; }
        public IList<ACC_dUsuarios> ACC_dUsuarios { get; set; }
        public IList<ACC_sEstados> ACC_sEstados { get; set; }
        public IList<ACC_sRegiones> ACC_sRegiones { get; set; }
        public IList<ACC_rdMenu_dAcciones> ACC_rdMenu_dAcciones { get; set; }
        public IList<ACC_rdPerfil_dAcciones> ACC_rdPerfil_dAcciones { get; set; }
        public IList<ACC_rdUsuarios_dPerfiles_dAcciones> ACC_rdUsuarios_dPerfiles_dAcciones { get; set; }

    public FakeRepository<ACC_dAcciones, AccesosSUAEntities> FakeACCdAccionesRepository { get; set; }
        IGenericRepository<ACC_dAcciones, AccesosSUAEntities> IUOW_AccesosDB.ACCdAccionesRepository
        {
            get
            {
                FakeACCdAccionesRepository = FakeACCdAccionesRepository ?? 
                    new FakeRepository<ACC_dAcciones, AccesosSUAEntities>(ACC_dAcciones);
                return FakeACCdAccionesRepository;
            }
        }

        public FakeRepository<ACC_dAplicaciones, AccesosSUAEntities> FakeACC_dAplicacionesRepository { get; set; }
        IGenericRepository<ACC_dAplicaciones, AccesosSUAEntities> IUOW_AccesosDB.ACC_dAplicacionesRepository
        {
            get
            {
                FakeACC_dAplicacionesRepository = FakeACC_dAplicacionesRepository ?? new FakeRepository<ACC_dAplicaciones, AccesosSUAEntities>(ACC_dAplicaciones);
                return FakeACC_dAplicacionesRepository;
            }
        }

        public FakeRepository<ACC_dMenu, AccesosSUAEntities> FakeACC_dMenuRepository { get; set; }
        IGenericRepository<ACC_dMenu, AccesosSUAEntities> IUOW_AccesosDB.ACC_dMenuRepository
        {
            get
            {
                FakeACC_dMenuRepository = FakeACC_dMenuRepository ?? new FakeRepository<ACC_dMenu, AccesosSUAEntities>(ACC_dMenu);
                return FakeACC_dMenuRepository;
            }
        }

        public FakeRepository<ACC_dPerfiles, AccesosSUAEntities> FakeACC_dPerfilesRepository { get; set; }
        IGenericRepository<ACC_dPerfiles, AccesosSUAEntities> IUOW_AccesosDB.ACC_dPerfilesRepository
        {
            get
            {
                FakeACC_dPerfilesRepository = FakeACC_dPerfilesRepository ?? new FakeRepository<ACC_dPerfiles, AccesosSUAEntities>(ACC_dPerfiles);
                return FakeACC_dPerfilesRepository;
            }
        }

        public FakeRepository<ACC_dUsuarios, AccesosSUAEntities> FakeACC_dUsuariosRepository { get; set; }
        IGenericRepository<ACC_dUsuarios, AccesosSUAEntities> IUOW_AccesosDB.ACC_dUsuariosRepository
        {
            get
            {
                FakeACC_dUsuariosRepository = FakeACC_dUsuariosRepository ?? new FakeRepository<ACC_dUsuarios, AccesosSUAEntities>(ACC_dUsuarios);
                return FakeACC_dUsuariosRepository;
            }
        }

        public FakeRepository<ACC_sEstados, AccesosSUAEntities> FakeACC_sEstadosRepository { get; set; }
        IGenericRepository<ACC_sEstados, AccesosSUAEntities> IUOW_AccesosDB.ACC_sEstadosRepository
        {
            get
            {
                FakeACC_sEstadosRepository = FakeACC_sEstadosRepository ?? new FakeRepository<ACC_sEstados, AccesosSUAEntities>(ACC_sEstados);
                return FakeACC_sEstadosRepository;
            }
        }

        public FakeRepository<ACC_sRegiones, AccesosSUAEntities> FakeACC_sRegionesRepository { get; set; }
        IGenericRepository<ACC_sRegiones, AccesosSUAEntities> IUOW_AccesosDB.ACC_sRegionesRepository
        {
            get
            {
                FakeACC_sRegionesRepository = FakeACC_sRegionesRepository ?? new FakeRepository<ACC_sRegiones, AccesosSUAEntities>(ACC_sRegiones);
                return FakeACC_sRegionesRepository;
            }
        }

        public FakeRepository<ACC_rdMenu_dAcciones, AccesosSUAEntities> FakeACC_rdMenu_dAccionesRepository { get; set; }
        IGenericRepository<ACC_rdMenu_dAcciones, AccesosSUAEntities> IUOW_AccesosDB.ACC_rdMenu_dAccionesRepository
        {
            get
            {
                FakeACC_rdMenu_dAccionesRepository = FakeACC_rdMenu_dAccionesRepository ?? new FakeRepository<ACC_rdMenu_dAcciones, AccesosSUAEntities>(ACC_rdMenu_dAcciones);
                return FakeACC_rdMenu_dAccionesRepository;
            }
        }

        public FakeRepository<ACC_rdPerfil_dAcciones, AccesosSUAEntities> FakeACC_rdPerfil_dAccionesRepository { get; set; }
        IGenericRepository<ACC_rdPerfil_dAcciones, AccesosSUAEntities> IUOW_AccesosDB.ACC_rdPerfil_dAccionesRepository
        {
            get
            {
                FakeACC_rdPerfil_dAccionesRepository = FakeACC_rdPerfil_dAccionesRepository ?? new FakeRepository<ACC_rdPerfil_dAcciones, AccesosSUAEntities>(ACC_rdPerfil_dAcciones);
                return FakeACC_rdPerfil_dAccionesRepository;
            }
        }

        public FakeRepository<ACC_rdUsuarios_dPerfiles_dAcciones, AccesosSUAEntities> FakeACC_rdUsuarios_dPerfiles_dAccionesRepository { get; set; }
        IGenericRepository<ACC_rdUsuarios_dPerfiles_dAcciones, AccesosSUAEntities> IUOW_AccesosDB.ACC_rdUsuarios_dPerfiles_dAccionesRepository
        {
            get
            {
                FakeACC_rdUsuarios_dPerfiles_dAccionesRepository = FakeACC_rdUsuarios_dPerfiles_dAccionesRepository ?? new FakeRepository<ACC_rdUsuarios_dPerfiles_dAcciones, AccesosSUAEntities>(ACC_rdUsuarios_dPerfiles_dAcciones);
                return FakeACC_rdUsuarios_dPerfiles_dAccionesRepository;
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
    }
}
