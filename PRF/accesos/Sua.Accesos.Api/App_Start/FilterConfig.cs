using System.Web.Mvc;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Api.App_Start
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}