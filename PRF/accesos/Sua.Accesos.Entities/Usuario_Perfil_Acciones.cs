namespace Corp.Cencosud.Supermercados.Sua.Accesos.Entities
{
    public class Usuario_Perfil_Acciones
    {
        public short idUsuario { get; set; }

        public decimal idPerfilAccion { get; set; }

        public string usuario { get; set; }

        public System.DateTime ts { get; set; }

        public Usuario Usuario { get; set; }

        public Perfil_Accion Perfil_Accion { get; set; }
    }
}