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
    
    public partial class StiNoticia
    {
        public int nStiNoticiaID { get; set; }
        public string sTituloNotica { get; set; }
        public string sCuerpoNoticia { get; set; }
        public Nullable<System.DateTime> dFechaPublicacion { get; set; }
        public Nullable<int> sUsuarioPublica { get; set; }
        public Nullable<byte> nNoticiaImportante { get; set; }
        public Nullable<byte> nVisible { get; set; }
        public string sUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> dFechaCreacion { get; set; }
        public string sUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> dFechaModificacion { get; set; }
    }
}