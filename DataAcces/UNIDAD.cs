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
    
    public partial class UNIDAD
    {
        public UNIDAD()
        {
            this.FUNCIONARIO = new HashSet<FUNCIONARIO>();
        }
    
        public short IDUNIDAD { get; set; }
        public string NOMBREUNIDAD { get; set; }
        public short EMPRESA_IDEMPRESA { get; set; }
        public int EMPRESA_RUTEMPRESA { get; set; }
    
        public virtual EMPRESA EMPRESA { get; set; }
        public virtual ICollection<FUNCIONARIO> FUNCIONARIO { get; set; }
    }
}
