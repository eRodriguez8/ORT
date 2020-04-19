using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz
{
    public class AplicacionBiz : BaseBiz, IAplicacionBiz
    {
        public AplicacionBiz(IUOW_AccesosDB unitOfWorkOfAccesosDB) : base(unitOfWorkOfAccesosDB)
        {
        }

        public Aplicacion GetxId(string id)
        {
            var app = _unitOfWorkOfAccesosDB.ACC_dAplicacionesRepository
            .Get(x => x.id == id)
            .SingleOrDefault();

            if (app == null)
            {
                throw new NotFoundException();
            }

            return app.ToModel();
        }

        public List<Aplicacion> GetAll()
        {
            var app = _unitOfWorkOfAccesosDB.ACC_dAplicacionesRepository
            .Get(includeProperties: "ACC_dAcciones").ToList();

            if (app == null)
                throw new NotFoundException();

            return app.ToModel();
        }
    }
}