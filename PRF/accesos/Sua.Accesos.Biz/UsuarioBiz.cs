using System;
using System.Collections.Generic;
using System.Linq;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;
using System.Threading;
using System.Security.Principal;
using Ninject;
using System.Runtime.Caching;
using log4net;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz
{
    public class UsuarioBiz : BaseBiz, IUsuarioBiz
    {
        private readonly ISeguridadBiz _seguridadBiz;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(UsuarioBiz));

        public UsuarioBiz(IUOW_AccesosDB unitOfWorkOfAccesosDB) : base(unitOfWorkOfAccesosDB)
        {
        }

        public UsuarioBiz(IUOW_AccesosDB unitOfWorkOfAccesosDB, ISeguridadBiz seguridadBiz) : base(unitOfWorkOfAccesosDB)
        {
            _seguridadBiz = seguridadBiz;
            log4net.Config.XmlConfigurator.Configure();

        }

        public Usuario Get(short id)
        {
            var usuario = _unitOfWorkOfAccesosDB.ACC_dUsuariosRepository
                .Get(x => x.id == id)
                .SingleOrDefault();

            if (usuario == null)
            {
                throw new NotFoundException();
            }

            return usuario.ToModel();
        }

        public Usuario GetxUsuarioAD(string usuarioAD)
        {
            var usuario = Get(usuarioAD, 'U');

            if (usuario == null)
            {
                throw new NotFoundException();
            }

            return usuario.ToModel();
        }

        private Usuario GetxLegajo(string legajo)
        {
            var usuario = Get(legajo, 'L');

            if (usuario == null)
            {
                throw new NotFoundException();
            }

            return usuario.ToModel();

        }

        private ACC_dUsuarios Get(string valor, char tipoDeBusqueda)
        {
            var usuario = _unitOfWorkOfAccesosDB.ACC_dUsuariosRepository
                .Get(x => x.idEstado == "A" && (tipoDeBusqueda == 'L' ? x.legajo == valor :
                     x.usuarioAD == valor))
                .SingleOrDefault();

            return usuario;
        }

        public string Delete(string legajo, string usuario)
        {
            _seguridadBiz.ValidatePermissions();
            
            var usuarioEntity = Get(legajo, 'L');
            usuarioEntity.fhBaja = DateTime.Now;
            usuarioEntity.ts = DateTime.Now;
            usuarioEntity.idEstado = Estado.I.ToString();
            usuarioEntity.usuario = usuario;

            _unitOfWorkOfAccesosDB.ACC_dUsuariosRepository
                .Update(usuarioEntity);
            _unitOfWorkOfAccesosDB.Save();

            return "Ok";
        }

        public Usuario Update(Usuario usuario)
        {
            try
            {
                _seguridadBiz.ValidatePermissions();
                var us = _unitOfWorkOfAccesosDB.ACC_dUsuariosRepository
                    .Get(x => x.id == usuario.id).First();

                us.nombre = usuario.nombre;
                us.apellido = usuario.apellido;
                us.usuarioAD = usuario.usuarioAD;
                us.usuario = usuario.usuario;
                us.ts = DateTime.Now;
                us.email = usuario.email;
                _unitOfWorkOfAccesosDB.ACC_dUsuariosRepository
                    .Update(us);

                _unitOfWorkOfAccesosDB.Save();

                return usuario;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                throw new Exception();
            }
            
        }

        public Usuario CopiarUsuarioPerfil(string legajoOrigen, string legajoDestino, string usuarioAD)
        {
            try
            {
                _seguridadBiz.ValidatePermissions();
                var usuarioEntity = Get(legajoDestino, 'L');

                var usuarioOrigenEntity = Get(legajoOrigen, 'L');

                var perfilesACopiar = _unitOfWorkOfAccesosDB.ACC_rdUsuarios_dPerfiles_dAccionesRepository.Get(
                    x => x.idUsuario == usuarioOrigenEntity.id).ToList();

                var perfilesABorrar = _unitOfWorkOfAccesosDB.ACC_rdUsuarios_dPerfiles_dAccionesRepository.Get(
                    x => x.idUsuario == usuarioEntity.id).ToList();

                perfilesABorrar.ForEach(x => _unitOfWorkOfAccesosDB.ACC_rdUsuarios_dPerfiles_dAccionesRepository.Delete(x));

                foreach (ACC_rdUsuarios_dPerfiles_dAcciones pe in perfilesACopiar)
                {
                    _unitOfWorkOfAccesosDB.ACC_rdUsuarios_dPerfiles_dAccionesRepository
                        .Insert(new ACC_rdUsuarios_dPerfiles_dAcciones()
                        {
                            idPerfilAccion = pe.idPerfilAccion,
                            idUsuario = usuarioEntity.id,
                            ts = System.DateTime.Now,
                            usuario = usuarioAD
                        });
                }

                _unitOfWorkOfAccesosDB.Save();

                return GetxLegajo(legajoDestino);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                throw new Exception();
            }

        }

        public Usuario Create(Usuario user)
        {
            _seguridadBiz.ValidatePermissions();
            try
            {
                GetxLegajo(user.legajo);
                throw new ConflictException("El legajo ya existe");
            }
            catch (NotFoundException)
            {
                var entity = user.ToEntity();

                _unitOfWorkOfAccesosDB.ACC_dUsuariosRepository
                    .Insert(entity);
                _unitOfWorkOfAccesosDB.Save();

                return GetxLegajo(user.legajo);
            }
        }

        public Usuario GetByIdUsuarioAplicacion(string usuarioAD, string idAplicacion)
        {
            var usuario = GetxUsuarioAD(usuarioAD);

            if (idAplicacion == "DIS") {
                usuario = GetxLegajoConPerfiles(usuario.legajo);
            }
            else {
                usuario.Perfiles = new PerfilBiz(_unitOfWorkOfAccesosDB, _seguridadBiz)
                    .GetAllxUsuarioApp(usuario.id, idAplicacion.ToUpperInvariant());
            }
            return usuario;
        }

        public Usuario GetByLegajoIdAplicacion(string legajo, string idAplicacion)
        {
            var usuario = GetxLegajo(legajo);

            usuario.Perfiles = new PerfilBiz(_unitOfWorkOfAccesosDB, _seguridadBiz)
                .GetAllxUsuarioApp(usuario.id, idAplicacion.ToUpperInvariant());

            return usuario;
        }

        public Usuario AsociarPerfil(string legajo, List<short> idPerfiles, string usuarioAD)
        {
            try
            {
                _seguridadBiz.ValidatePermissions();
                var usuario = GetxLegajo(legajo);

                var perfilesacciones = new List<ACC_rdPerfil_dAcciones>();
                idPerfiles.ForEach(y =>
                    perfilesacciones.AddRange(_unitOfWorkOfAccesosDB.ACC_rdPerfil_dAccionesRepository.Get(x => x.idPerfil == y).ToList()));

                var perfilaccionesActuales = _unitOfWorkOfAccesosDB.ACC_rdUsuarios_dPerfiles_dAccionesRepository.Get(x=> x.idUsuario == usuario.id).ToList();

                var usuarioPerfilAccion = new List<ACC_rdUsuarios_dPerfiles_dAcciones>();
                int agregoAlguno = 0;
                foreach (var perfilA in perfilesacciones)
                {
                    if (perfilaccionesActuales == null || perfilaccionesActuales.Count == 0 ||
                    perfilaccionesActuales.FirstOrDefault(y => y.idPerfilAccion == perfilA.id) == null)
                    {
                        agregoAlguno++;
                        _unitOfWorkOfAccesosDB.ACC_rdUsuarios_dPerfiles_dAccionesRepository.Insert(new ACC_rdUsuarios_dPerfiles_dAcciones()
                        {
                            idPerfilAccion = perfilA.id,
                            idUsuario = usuario.id,
                            ts = DateTime.Now,
                            usuario = usuarioAD
                        });
                    }
                }
                if (agregoAlguno > 0)
                {
                    _unitOfWorkOfAccesosDB.Save();
                }

                return usuario;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                throw new Exception();
            }
           
        }

        public Usuario GetxLegajoConPerfiles(string legajo)
        {
            var _servicioApp = new AplicacionBiz(_unitOfWorkOfAccesosDB);
            var usuario = GetxLegajo(legajo);

            usuario.Perfiles = new PerfilBiz(_unitOfWorkOfAccesosDB, _seguridadBiz)
                .GetAllxUsuarioApp(usuario.id, "");

            var auxApp = new List<Aplicacion>();
            usuario.Perfiles.ForEach(x =>
                x.Acciones.ForEach(y => auxApp.Add(_servicioApp.GetxId(y.idAplicacion))));

            usuario.Aplicaciones = new List<Aplicacion>();
            usuario.Aplicaciones.AddRange(auxApp.Distinct());


            return usuario;
        }
    }
}