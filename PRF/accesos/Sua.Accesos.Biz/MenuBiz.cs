using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using System.Collections.Generic;
using System.Linq;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz
{
    public class MenuBiz : BaseBiz, IMenuBiz
    {
        List<Menu> listaMenuOrdenada;

        public MenuBiz(IUOW_AccesosDB unitOfWorkOfAccesosDB) : base(unitOfWorkOfAccesosDB)
        {
        }

        public List<Menu> GetMenu (string idAplicacion)
        {
            var menu = _unitOfWorkOfAccesosDB.ACC_dMenuRepository.Get(x =>
                x.idAplicacion == idAplicacion && x.idEstado == "A").AsEnumerable()
                .Select(x => x.ToModel()).ToList();
            listaMenuOrdenada = new List<Menu>();
            listaMenuOrdenada.AddRange(menu);

            int numMenus = calculateTree();

            while(numMenus != 0)
            {
                numMenus = calculateTree();
            }

            return listaMenuOrdenada;

        }

        private int calculateTree()
        {
            List<Menu> menus = new List<Menu>();
            int response = 0;

            foreach (Menu _m in listaMenuOrdenada)
            {
                var submenus = listaMenuOrdenada.Where(s => s.idMenu_Precede == _m.id).ToList();
                if (submenus != null && submenus.Any())
                {
                    _m.SubMenu = submenus;
                    menus.Add(_m);
                }
            }

            response = menus.Count();

            if(response > 0)
            {
                listaMenuOrdenada = menus;
            }

            return response;
        }
    }
}
