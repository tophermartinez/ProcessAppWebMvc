//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAcces
{
    using System;
    using System.Collections.Generic;
    
    public partial class FUNCIONARIO_TAREA
    {
        public FUNCIONARIO_TAREA()
        {
            this.JUSTIFICACION_TAREA = new HashSet<JUSTIFICACION_TAREA>();
        }
    
        public short IDFUTAREA { get; set; }
        public System.DateTime FECHAPLAZO { get; set; }
        public short FUNCIONARIO_IDFUNCIONARIO { get; set; }
        public int TAREA_IDTAREA { get; set; }
    
        public virtual FUNCIONARIO FUNCIONARIO { get; set; }
        public virtual TAREA TAREA { get; set; }
        public virtual ICollection<JUSTIFICACION_TAREA> JUSTIFICACION_TAREA { get; set; }
    }
}
