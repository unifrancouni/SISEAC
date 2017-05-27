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
    
    public partial class SsgCuenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SsgCuenta()
        {
            this.SsgCuentaPermiso = new HashSet<SsgCuentaPermiso>();
            this.SsgUsuario = new HashSet<SsgUsuario>();
        }
    
        public int nSsgCuentaID { get; set; }
        public string sNombreUsuario { get; set; }
        public string sClave { get; set; }
        public string sDireccionImagenPerfil { get; set; }
        public Nullable<byte> nActivo { get; set; }
        public string sUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> dFechaCreacion { get; set; }
        public string sUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> dFechaModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SsgCuentaPermiso> SsgCuentaPermiso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SsgUsuario> SsgUsuario { get; set; }
    }
}