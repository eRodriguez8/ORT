//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Corp.Cencosud.Supermercados.Sua_Accesos.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class ACC_dPerfiles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACC_dPerfiles()
        {
            this.ACC_rdPerfil_dAcciones = new HashSet<ACC_rdPerfil_dAcciones>();
        }
    
        public short id { get; set; }
        public short idRegion { get; set; }
        public string idAplicacion { get; set; }
        public string descripcion { get; set; }
        public string idEstado { get; set; }
        public string usuario { get; set; }
        public System.DateTime ts { get; set; }
    
        public virtual ACC_dAplicaciones ACC_dAplicaciones { get; set; }
        public virtual ACC_sEstados ACC_sEstados { get; set; }
        public virtual ACC_sRegiones ACC_sRegiones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACC_rdPerfil_dAcciones> ACC_rdPerfil_dAcciones { get; set; }
    }
}
