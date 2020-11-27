using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class TAREA
    {
       public int IDTAREA { get; set; }
        [Display(Name = "Tarea")]
        public string NOMBRETAREA { get; set; }
        [Display(Name = "Creación")]
        public DateTime FECHACREACION { get; set; }
        [Display(Name = "Estado")]
        public int ESTADO_TAREA { get; set; }

        public string FECHA_ACTUAL { get; set; }
        [Display(Name = "Fecha termino")]
        public string FECHA_TERMINO { get; set; }
        [Display(Name = "Empresa")]
        public int  ID_EMPRESA { get; set; }
        [Display(Name = "Asignado a")]
        public string nombre_usuario { get; set; }

        public int RUT_EM { get; set; }
        [Display(Name = "Asignado a")]
        public int RUT_USU { get; set; }
        [Display(Name = "Fecha estimada")]
        public string FechaEstimada { get; set; }



    }
}
