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
    
    public partial class SplActividad
    {
        public int nSplActividadID { get; set; }
        public string sTitulo { get; set; }
        public string sCuerpo { get; set; }
        public Nullable<System.DateTime> dFechaHoraInicio { get; set; }
        public Nullable<System.DateTime> dFechaHoraFin { get; set; }
        public Nullable<int> nTipoActividadID { get; set; }
        public Nullable<int> nEstadoActividadID { get; set; }
        public string sUbicacionActividad { get; set; }
        public string sUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> dFechaCrecion { get; set; }
        public string sUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> dFechaModificacion { get; set; }
    
        public virtual StbValorCatalogo StbValorCatalogo { get; set; }
        public virtual StbValorCatalogo StbValorCatalogo1 { get; set; }
    }
}
