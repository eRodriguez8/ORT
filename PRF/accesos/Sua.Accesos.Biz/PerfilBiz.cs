using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz
{
    public class PerfilBiz : BaseBiz, IPerfilBiz
    {
        private readonly ISeguridadBiz _seguridadBiz;
        public PerfilBiz(IUOW_AccesosDB unitOfWorkOfAccesosDB, ISeguridadBiz seguridadBiz) : base(unitOfWorkOfAccesosDB)
        {
            _seguridadBiz = seguridadBiz;
        }

        private ACC_dPerfiles GetxId(short id)
        {
            var perfil = _unitOfWorkOfAccesosDB.ACC_dPerfilesRepository
            .Get(x => x.id == id)
            .SingleOrDefault();

            if (perfil == null)
            {
                throw new NotFoundException();
            }

            return perfil;
        }

        public Perfil Get(short id)
        {
            var perfil = GetxId(id);
            return perfil.ToModel();
        }

        public List<Perfil> GetAll()
        {
            var perfiles = _unitOfWorkOfAccesosDB.ACC_dPerfilesRepository
            .Get().ToList();

            if (perfiles != null && perfiles.Count() > 0)
            {
                return perfiles.ToModel();
            }

            return new List<Perfil>();
        }

        public List<Perfil> GetAll(short idRegion, string idApp)
        {
            var perfiles = _unitOfWorkOfAccesosDB.ACC_dPerfilesRepository
            .Get(x => x.idRegion == idRegion && x.idAplicacion == idApp).ToList();

            if (perfiles != null && perfiles.Count() > 0)
            {
                return perfiles.ToModel();
            }

            return new List<Perfil>();
        }

        public List<Perfil> GetAllxUsuarioApp(short idUsuario, string idAplicacion)
        {
            var aux = _unitOfWorkOfAccesosDB.ACC_rdUsuarios_dPerfiles_dAccionesRepository
                .Get(x => x.idUsuario == idUsuario && (string.Empty == idAplicacion
                || x.ACC_rdPerfil_dAcciones.ACC_dPerfiles.idAplicacion == idAplicacion),
                includeProperties: "ACC_rdPerfil_dAcciones, ACC_rdPerfil_dAcciones.ACC_dAcciones, ACC_rdPerfil_dAcciones.ACC_dPerfiles")
                .AsEnumerable()
                .Select(x => x.ACC_rdPerfil_dAcciones).ToList();
            var perfilesAcccionesxUsuario = aux.ToModel();

            var perfiles = perfilesAcccionesxUsuario.Select(x => x.Perfil).Distinct().ToList();
            foreach (Perfil pe in perfiles)
            {
                pe.Acciones = new List<Accion>();
                pe.Acciones.AddRange(perfilesAcccionesxUsuario.Where(x => x.idPerfil == pe.id).Select(y => y.Accion).ToList());
            }

            return perfiles;
        }


        public string Delete(short id, string usuarioAD)
        {
            _seguridadBiz.ValidatePermissions();
            var perfilEntity = GetxId(id);

            var usuarioPerfilAccion = _unitOfWorkOfAccesosDB.ACC_rdUsuarios_dPerfiles_dAccionesRepository.Get(
                x => x.ACC_rdPerfil_dAcciones.idPerfil == id).ToList();

            usuarioPerfilAccion.ForEach(x =>
                _unitOfWorkOfAccesosDB.ACC_rdUsuarios_dPerfiles_dAccionesRepository.Delete(x));

            var perfilAccion = _unitOfWorkOfAccesosDB.ACC_rdPerfil_dAccionesRepository.Get(
             x => x.idPerfil == id).ToList();

            perfilAccion.ForEach(x =>
            _unitOfWorkOfAccesosDB.ACC_rdPerfil_dAccionesRepository.Delete(x));

            _unitOfWorkOfAccesosDB.ACC_dPerfilesRepository
                .Delete(perfilEntity);
            _unitOfWorkOfAccesosDB.Save();

            return "Ok";
        }

        public Perfil Update(Perfil perfil)
        {
            _seguridadBiz.ValidatePermissions();
            var perf = _unitOfWorkOfAccesosDB.ACC_dPerfilesRepository
                        .Get(x => x.id == perfil.id).First();

            perf.idAplicacion = perfil.idAplicacion;
            perf.idEstado = perfil.idEstado;
            perf.idRegion = perfil.idRegion;
            perf.ts = perfil.ts;
            perf.usuario = perfil.usuario;

            _unitOfWorkOfAccesosDB.ACC_dPerfilesRepository.Update(perf);
            _unitOfWorkOfAccesosDB.Save();

            return perfil;
        }

        public Perfil Create(Perfil perfil)
        {
            _seguridadBiz.ValidatePermissions();
            var entity = perfil.ToEntity();

            _unitOfWorkOfAccesosDB.ACC_dPerfilesRepository
                    .Insert(entity);

            perfil.Acciones.ForEach(x =>
            _unitOfWorkOfAccesosDB.ACC_rdPerfil_dAccionesRepository.Insert(
                new ACC_rdPerfil_dAcciones()
                {
                    id = 0,
                    idAccion = x.id,
                    idPerfil = entity.id,
                    ts = perfil.ts,
                    usuario = perfil.usuario
                }));
            _unitOfWorkOfAccesosDB.Save();

            return entity.ToModel();
        }
    }
}
