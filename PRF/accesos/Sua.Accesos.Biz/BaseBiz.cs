using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz
{
    public class BaseBiz
    {
        protected IUOW_AccesosDB _unitOfWorkOfAccesosDB { get; }

        public BaseBiz(IUOW_AccesosDB unitOfWorkOfAccesosDB)
        {
            _unitOfWorkOfAccesosDB = unitOfWorkOfAccesosDB;
        }
    }
}
