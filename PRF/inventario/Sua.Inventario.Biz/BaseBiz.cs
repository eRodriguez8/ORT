using Corp.Cencosud.Supermercados.Sua_Inventario.Dal;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz
{
    public class BaseBiz
    {
        protected IUOW_CDsDB _unitOfWorkOfCDsDB { get; }

        public BaseBiz(IUOW_CDsDB unitOfWorkOfCDsDB)
        {
            _unitOfWorkOfCDsDB = unitOfWorkOfCDsDB;
        }
    }
}
