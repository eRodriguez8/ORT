using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces
{
    public interface IAppContextBiz
    {
        AppContext GetContext(string usuarioAD, string idAplicacion);
    }
}
