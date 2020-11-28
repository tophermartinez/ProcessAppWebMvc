using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class UNIDAD
    {
        public int ID_UNIDAD { get; set; }
        [Display(Name = "Nombre")]
        public string NOMBRE { get; set; }
        [Display(Name = "Detalle")]
        public string DETALLE { get; set; }
        [Display(Name = "Fecha Termino")]
        public string FECHA_TERMINO { get; set; }
        [Display(Name = "Fecha Creación")]
        public DateTime FECHACREACION { get; set; }

        public string FECHA_ACTUAL { get; set; }
        [Display(Name = "Estado")]
        public int ESTADO { get; set;  }
        public string nombre_usuario { get; set; }

        public int RUT_EM { get; set; }
        [Display(Name = "Asignado a")]
        public int RUT_USU { get; set; }
        [Display(Name = "Fecha Estimada")]
        public string FechaEstimada { get; set; }
    }
}
