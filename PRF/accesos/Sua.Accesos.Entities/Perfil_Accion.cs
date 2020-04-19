
namespace Corp.Cencosud.Supermercados.Sua.Accesos.Entities
{
    public class Perfil_Accion
    {
        public short idPerfil { get; set; }

        public short idAccion { get; set; }

        public string usuario { get; set; }

        public System.DateTime ts { get; set; }

        public decimal id { get; set; }

        public Accion Accion { get; set; }

        public Perfil Perfil { get; set; }
    }
}
