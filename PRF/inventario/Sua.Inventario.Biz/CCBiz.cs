using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using Corp.Cencosud.Supermercados.Sua_Inventario.Dal;
using System.Collections.Generic;
using System.Linq;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz
{
    public class CCBiz : BaseBiz, ICCBiz
    {
        protected IUOW_CDsDB _unitOfWorkOfCDsDB { get; }
        public CCBiz(IUOW_CDsDB unitOfWorkOfCDsDB) : base(unitOfWorkOfCDsDB)
        {
            _unitOfWorkOfCDsDB = unitOfWorkOfCDsDB;
        }

        public List<CC> GetxIdRegion(short idRegion)
        {
            var ccs = _unitOfWorkOfCDsDB.INV_dCCsActivosRepository.Get(x =>
            x.idRegion == idRegion && x.estado == "A").ToList();
            
            var d = ccs.ToModel();
            return d;
        }
    }
}
