//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SISEAC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StbCatalogo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StbCatalogo()
        {
            this.StbValorCatalogo = new HashSet<StbValorCatalogo>();
        }
    
        public int nStbCatalogoID { get; set; }
        public string sCodigoInterno { get; set; }
        public string sDescripcion { get; set; }
        public Nullable<int> nActivo { get; set; }
        public string sUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> dFechaCreacion { get; set; }
        public string sUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> dFechaModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StbValorCatalogo> StbValorCatalogo { get; set; }
    }
}
