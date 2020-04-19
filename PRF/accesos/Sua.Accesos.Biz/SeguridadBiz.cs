using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using Ninject;
using System;
using System.Linq;
using System.Runtime.Caching;
using System.Security.Principal;
using System.Threading;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz
{
    public class SeguridadBiz : BaseBiz, ISeguridadBiz
    {
        [Inject]
        private readonly MemoryCache _Usuarios;
        private readonly int _MinutesForUserInMemoryCacheExpire = 10;
        public readonly UsuarioBiz _usuarioBiz;

        public SeguridadBiz(IUOW_AccesosDB unitOfWorkOfAccesosDB) : base(unitOfWorkOfAccesosDB)
        {
            _Usuarios = _Usuarios ?? MemoryCache.Default;
            _usuarioBiz = new UsuarioBiz(unitOfWorkOfAccesosDB);
        }

        public Usuario GetUsuario()
        {
            var usuarioAD = ((Thread.CurrentPrincipal is WindowsPrincipal
                        || Thread.CurrentPrincipal is GenericPrincipal)
                        && Thread.CurrentPrincipal.Identity.IsAuthenticated
                        && Thread.CurrentPrincipal.Identity.Name.Contains(@"\"))
                    ? Thread.CurrentPrincipal.Identity.Name.ToUpperInvariant()
                    : WindowsIdentity.GetCurrent().Name.ToUpperInvariant();
            if (!_Usuarios.Any(x => x.Key == $"{usuarioAD}"))
            {
                var user = _usuarioBiz.GetByIdUsuarioAplicacion(usuarioAD, "ACC");
                _Usuarios.Add($"{usuarioAD}", user, new System.DateTimeOffset(DateTime.Now.AddMinutes(10)));
                return user;
            }
            else
            {
                return (Usuario)_Usuarios.Single(x => x.Key == $"{usuarioAD}").Value;
            }
        }

        public void ValidatePermissions()
        {
            var usuario = GetUsuario();

            if(!validUser(usuario))
            {
                throw new NotAllowedException();
            }
        }

        private bool validUser(Usuario usuario)
        {
            bool valido = false;

            foreach (var per in usuario.Perfiles)
            {
                if (per.Acciones != null && per.Acciones.Count > 0)
                {
                    foreach (var acc in per.Acciones)
                    {
                        if (acc.descripcion == "Administrador")
                            return valido = true;
                    }
                }
            }
            return valido;
        }
        
    }
}