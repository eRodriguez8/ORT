using System.Security.Principal;
using System.Threading;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Helpers
{
    public static class Security
    {
        public static string GetUser()
        {
            return ((Thread.CurrentPrincipal is WindowsPrincipal
                    || Thread.CurrentPrincipal is GenericPrincipal)
                    && Thread.CurrentPrincipal.Identity.IsAuthenticated
                    && Thread.CurrentPrincipal.Identity.Name.Contains(@"\"))
                ? Thread.CurrentPrincipal.Identity.Name.ToUpperInvariant()
                : WindowsIdentity.GetCurrent().Name.ToUpperInvariant();
        }
    }
}
