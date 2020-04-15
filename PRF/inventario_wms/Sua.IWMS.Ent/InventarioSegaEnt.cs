using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corp.Cencosud.Supermercados.Sua.IWMS.Ent
{
    public class InventarioSegaEnt
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Sector { get; set; }
        public string PASILLO { get; set; }
        public double? COLUMNA { get; set; }
        public double? NIVEL { get; set; }
        public double? COMPART { get; set; }
        public string ETIQUETA { get; set; }
        public string ean13 { get; set; }
        public string DESCRIPCION { get; set; }
        public string Proveedor { get; set; }
        public string ID_ORDEN_COMPRA { get; set; }
        public DateTime? Fecha_hora_recepcion { get; set; }
        public DateTime? Vencimiento { get; set; }
        public double? VidaUtil { get; set; }
        public string DiasVencer { get; set; }
        public double? CxH { get; set; }
        public double? HxP { get; set; }
        public double? UxB { get; set; }
        public double? UxPack { get; set; }
        public double? Bultos { get; set; }
        public double? Packs { get; set; }
        public double? Unidades { get; set; }
        public string Recepcionista { get; set; }
        public string Almacenador { get; set; }
        public string EstadoCalidad { get; set; }
        public double? CARA { get; set; }
        public string Usuario { get; set; }
        public string Digito { get; set; }
        public double? BultosInv { get; set; }
        public DateTime? Ts { get; set; }
        public DateTime? FechaAct { get; set; }
        public string UsuarioInventario { get; set; }
        public TipoInventarios TipoInventario { get; set; }
        public int? HxPInv { get; set; }
        public int? CajasSueltasInv { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public string CodigoArticulo { get; set; }
    }

    public enum TipoInventarios
    {
        Bultos = 1,
        Camadas = 2,
        Vacio = 3
    }
}
