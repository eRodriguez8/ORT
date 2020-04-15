using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Entities
{
    public class Inventario
    {
        public string nombre { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Estado estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime? fechaFinalizacion { get; set; }
        public string usuario { get; set; }
        public short cc { get; set; }
        public int id { get; set; }
        public List<Documento> documento { get; set; }
        public List<string> acciones { get; set; }
    }
}
