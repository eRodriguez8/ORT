using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Entities
{
    public class Posicion
    {
        public int id { get; set; }
        public int idDocumento { get; set; }
        public string documento { get; set; }
        public string sector { get; set; }
        public string pasillo { get; set; }
        public string columna { get; set; }
        public string nivel { get; set; }
        public string compart { get; set; }
        public string etiqueta { get; set; }
        public string dun14 { get; set; }
        public string descripcion { get; set; }
        public string proveedor { get; set; }
        public string id_orden_compra { get; set; }
        public string fecha_hora_recepcion { get; set; }
        public string vencimiento { get; set; }
        public string vidautil { get; set; }
        public string diasvencer { get; set; }
        public string cxh { get; set; }
        public string hxp { get; set; }
        public string uxb { get; set; }
        public string uxpack { get; set; }
        public string bultos { get; set; }
        public string packs { get; set; }
        public string unidades { get; set; }
        public string recepcionista { get; set; }
        public string almacenador { get; set; }
        public string estadocalidad { get; set; }
        public string cara { get; set; }
        public string metodo { get; set; }


        public string usuario { get; set; }
        public string digito { get; set; }
        public double? bultosinv { get; set; }
        public DateTime? ts { get; set; }
        public string fechaact { get; set; }
        public string usuarioinventario { get; set; }
        public string tipoinventario { get; set; }
        public int? hxpinv { get; set; }
        public int? cajassueltasinv { get; set; }
        public string estado { get; set; }
        public string observaciones { get; set; }

        public string ean13 { get; set; }
        public string codigoarticulo { get; set; }
        public string tipolectura { get; set; }
        public string documentoasociado { get; set; }
        public int idInventario { get; set; }
    }
}
