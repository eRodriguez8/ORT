using System;
using System.Collections.Generic;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using System;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz
{
    public class AppContextBiz : BaseBiz, IAppContextBiz
    {
        public AppContextBiz(IUOW_AccesosDB unitOfWorkOfAccesosDB) : base(unitOfWorkOfAccesosDB)
        {

        }
        public AppContext GetContext(string usuarioAD, string idAplicacion)
        {
            var _appContext = new AppContext();
            try
            {
                _appContext.usuario = new UsuarioBiz(_unitOfWorkOfAccesosDB)
                    .GetByIdUsuarioAplicacion(usuarioAD, idAplicacion);
            }
            catch(Exception ex)
            {
                throw new NotAllowedException(ex.Message);
            }

            _appContext.menu = new MenuBiz(_unitOfWorkOfAccesosDB)
                .GetMenu(idAplicacion);

            return _appContext;
        }
    }
}
