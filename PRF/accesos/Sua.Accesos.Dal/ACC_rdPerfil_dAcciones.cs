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
    
    public partial class ACC_rdPerfil_dAcciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACC_rdPerfil_dAcciones()
        {
            this.ACC_rdUsuarios_dPerfiles_dAcciones = new HashSet<ACC_rdUsuarios_dPerfiles_dAcciones>();
        }
    
        public short idPerfil { get; set; }
        public short idAccion { get; set; }
        public string usuario { get; set; }
        public System.DateTime ts { get; set; }
        public decimal id { get; set; }
    
        public virtual ACC_dAcciones ACC_dAcciones { get; set; }
        public virtual ACC_dPerfiles ACC_dPerfiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACC_rdUsuarios_dPerfiles_dAcciones> ACC_rdUsuarios_dPerfiles_dAcciones { get; set; }
    }
}
