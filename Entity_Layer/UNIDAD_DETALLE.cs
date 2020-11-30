using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class UNIDAD_DETALLE
    {
        public int id { get; set; }
        [Display(Name = "Flujo Asignado")]
        public int ID_UNIDAD { get; set; }
        [Display(Name = "Flujo")]
        public string NOMBRE_UNIDAD { get; set; }
        [Display(Name = "Tarea asignada")]
        public int   ID_TAREA { get; set; }
        [Display(Name = "Nombre Tarea")]
        public string NOMBRE_TAREA { get; set; }
        [Display(Name = "Fecha Termino")]
        public string FECHA_TERMINO { get; set; }
        [Display(Name = "Fecha Creación")]
        public DateTime FECHACREACION { get; set; }

        public string FECHA_ACTUAL { get; set; }
        [Display(Name = "Fecha Estimada")]
        public string FECHA_ESTIMADA { get; set; }
        [Display(Name = "Estado")]
        public int ESTADO { get; set; }
        [Display(Name = "Usuario Asignado")]
        public int Rut_Usu { get; set; }
        [Display(Name = "Usuario Asginado")]
        public string NOMBRE_USUARIO{ get; set; }
        [Display(Name = "Estado")]
        public string NOMBRE_ESTADO{ get; set; }
        public int ATRASO{ get; set; }
        [Display(Name = "Días restantes")]
        public int DIAS_DIF{ get; set; }



    }
}
