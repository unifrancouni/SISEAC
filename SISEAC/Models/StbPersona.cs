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
    
    public partial class StbPersona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StbPersona()
        {
            this.ScaAfiliacion = new HashSet<ScaAfiliacion>();
            this.SsgUsuario = new HashSet<SsgUsuario>();
            this.StbContactoPersona = new HashSet<StbContactoPersona>();
        }
    
        public int nStbPersonaID { get; set; }
        public string sNombre { get; set; }
        public string sApellido1 { get; set; }
        public string sApellido2 { get; set; }
        public string sCedula { get; set; }
        public string sDomicilio { get; set; }
        public string sUsuarioCreacion { get; set; }
        public System.DateTime dFechaCreacion { get; set; }
        public string sUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> dFechaModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScaAfiliacion> ScaAfiliacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SsgUsuario> SsgUsuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StbContactoPersona> StbContactoPersona { get; set; }
    }
}