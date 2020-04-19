using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz
{
    public class AccionBiz : BaseBiz, IAccionBiz
    {
        public AccionBiz(IUOW_AccesosDB unitOfWorkOfAccesosDB) : base(unitOfWorkOfAccesosDB)
        {
        }

        public List<Accion> GetByIdApp(string idApp)
        {
            var acc = _unitOfWorkOfAccesosDB.ACCdAccionesRepository
            .Get(x => x.idAplicacion == idApp && x.idEstado == "A").ToList();

            if (acc == null)
                throw new NotFoundException();

            return acc.ToModel();
        }

        public List<Accion> GetAll()
        {
            var acc = _unitOfWorkOfAccesosDB.ACCdAccionesRepository
            .Get(x => x.idEstado == "A").ToList();

            if (acc == null)
                throw new NotFoundException();

            return acc.ToModel();
        }
    }
}