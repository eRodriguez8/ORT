namespace Corp.Cencosud.Supermercados.Sua.Accesos.Entities
{
    public class Menu_Acciones
    {
        public string idAplicacion { get; set; }

        public short idMenu { get; set; }

        public short idAccion { get; set; }

        public string usuario { get; set; }

        public System.DateTime ts { get; set; }

        public Accion Accion { get; set; }

        public Aplicacion Aplicacion { get; set; }

        public Menu Menu { get; set; }
    }
}