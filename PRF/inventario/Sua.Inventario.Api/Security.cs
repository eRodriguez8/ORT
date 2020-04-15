using System.Security.Principal;
using System.ServiceModel;
using System.Threading;
using System.Web;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Helpers
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

        public static string GetTerminal()
        {
            return HttpContext.Current == null
                ? (OperationContext.Current == null
                        ? System.Net.Dns.GetHostName()
                        : (OperationContext.Current.IncomingMessageProperties.ContainsKey("Terminal")
                                ? (string)OperationContext.Current.IncomingMessageProperties["Terminal"]
                                : System.Net.Dns.GetHostName()))
                : HttpContext.Current.Items.Contains("Terminal")
                    ? (string)HttpContext.Current.Items["Terminal"]
                    : System.Net.Dns.GetHostName();
        }
    }
}
