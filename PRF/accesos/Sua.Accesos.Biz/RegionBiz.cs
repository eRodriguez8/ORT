using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using System.Collections.Generic;
using System.Linq;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz
{
    public class RegionBiz : BaseBiz, IRegionBiz
    {
        public RegionBiz(IUOW_AccesosDB unitOfWorkOfAccesosDB) : base(unitOfWorkOfAccesosDB)
        {
        }

        public List<Region> GetAll()
        {
            var region = _unitOfWorkOfAccesosDB.ACC_sRegionesRepository.Get().ToList();

            if (region == null)
                throw new NotFoundException();

            return region.ToModel();

        }
    }
}
