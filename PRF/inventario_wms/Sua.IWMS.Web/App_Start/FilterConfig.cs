using System.Web;
using System.Web.Mvc;

namespace Corp.Cencosud.Supermercados.Sua.IWMS.Web
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}