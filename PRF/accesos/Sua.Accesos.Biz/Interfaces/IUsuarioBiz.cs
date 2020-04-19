using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces
{
    public interface IUsuarioBiz
    {
        Usuario Get(short id);
        Usuario GetByIdUsuarioAplicacion(string usuarioAD, string idAplicacion);
        Usuario GetByLegajoIdAplicacion(string legajo, string idAplicacion);
        Usuario GetxUsuarioAD(string usuarioAD);
        Usuario GetxLegajoConPerfiles(string legajo);
        string Delete(string legajo, string usuario);
        Usuario Create(Usuario user);
        Usuario Update(Usuario usuario);
        Usuario CopiarUsuarioPerfil(string legajoOrigen , string legajoDestino, string usuarioAD);
        Usuario AsociarPerfil(string legajo, List<short> idPerfiles, string usuarioAD);
    }
}
