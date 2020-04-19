using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua_Accesos.Dal
{
    public interface IUOW_AccesosDB
    {
        IGenericRepository<ACC_dAcciones, AccesosSUAEntities> ACCdAccionesRepository { get; }

        IGenericRepository<ACC_dAplicaciones, AccesosSUAEntities> ACC_dAplicacionesRepository { get; }

        IGenericRepository<ACC_dMenu, AccesosSUAEntities> ACC_dMenuRepository { get; }

        IGenericRepository<ACC_dPerfiles, AccesosSUAEntities> ACC_dPerfilesRepository { get; }

        IGenericRepository<ACC_dUsuarios, AccesosSUAEntities> ACC_dUsuariosRepository { get; }

        IGenericRepository<ACC_sEstados, AccesosSUAEntities> ACC_sEstadosRepository { get; }

        IGenericRepository<ACC_sRegiones, AccesosSUAEntities> ACC_sRegionesRepository { get; }

        IGenericRepository<ACC_rdMenu_dAcciones, AccesosSUAEntities> ACC_rdMenu_dAccionesRepository { get; }

        IGenericRepository<ACC_rdPerfil_dAcciones, AccesosSUAEntities> ACC_rdPerfil_dAccionesRepository { get; }

        IGenericRepository<ACC_rdUsuarios_dPerfiles_dAcciones, AccesosSUAEntities> ACC_rdUsuarios_dPerfiles_dAccionesRepository { get; }

    void Dispose();

        void Save();
    }
}
