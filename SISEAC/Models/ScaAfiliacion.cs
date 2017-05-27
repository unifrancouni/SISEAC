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
    
    public partial class ScaAfiliacion
    {
        public int nScaAfiliacionID { get; set; }
        public int nStbPersonaID { get; set; }
        public int nStbProfesionID { get; set; }
        public int nStbEstadoCivilID { get; set; }
        public int nStbCategoriaDocenteID { get; set; }
        public int nStbGradoSuperiorID { get; set; }
        public int nStbFacultadID { get; set; }
        public int nStbCarreraID { get; set; }
        public int nStbDepartamentoID { get; set; }
        public int nStbEstadoAfiliacionID { get; set; }
        public int nInss { get; set; }
        public int nNoEmpleado { get; set; }
        public int nAnioIngresoUNI { get; set; }
        public System.DateTime dFechaSolicitud { get; set; }
        public int nActaFacultad { get; set; }
        public Nullable<int> nActaConsejoUniversitario { get; set; }
        public string sActaConsejoUniversitario { get; set; }
        public Nullable<System.DateTime> dFechaActaConsejoUniversitario { get; set; }
        public Nullable<int> nNumeroAfiliado { get; set; }
        public string sLugarReunionAprobacion { get; set; }
        public Nullable<System.DateTime> dFechaReunionAprobacion { get; set; }
        public string sUsuarioCreacion { get; set; }
        public System.DateTime dFechaCreacion { get; set; }
        public string sUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> dFechaModificacion { get; set; }
    
        public virtual StbPersona StbPersona { get; set; }
        public virtual StbValorCatalogo StbValorCatalogo { get; set; }
        public virtual StbValorCatalogo StbValorCatalogo1 { get; set; }
        public virtual StbValorCatalogo StbValorCatalogo2 { get; set; }
        public virtual StbValorCatalogo StbValorCatalogo3 { get; set; }
        public virtual StbValorCatalogo StbValorCatalogo4 { get; set; }
        public virtual StbCarrera StbCarrera { get; set; }
        public virtual StbFacultad StbFacultad { get; set; }
        public virtual StbDepartamento StbDepartamento { get; set; }
    }
}
