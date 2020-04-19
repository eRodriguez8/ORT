using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using System.Collections.Generic;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces
{
    public interface IPerfilBiz
    {
        List<Perfil> GetAllxUsuarioApp(short idUsuario, string idAplicacion);
        List<Perfil> GetAll();
        List<Perfil> GetAll(short idRegion, string idApp);
        Perfil Get(short id);
        Perfil Update(Perfil perfil);
        Perfil Create(Perfil perfil);
        string Delete(short id, string usuarioAD);
    }
}
