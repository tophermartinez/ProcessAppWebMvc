﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Dashboard_Gen
    {
        [Display(Name = "Flujo")]
        public string NOMBRE_UNIDAD { get; set; }
        public int ID_TAREA { get; set; }
        
        public int ID_UNIDAD { get; set; }
        public string NOMBRE_TAREA { get; set; }
        [Display(Name = "Fecha termino")]
        public string FECHA_TERMINO { get; set; }
        [Display(Name = "Fecha creación")]
        public DateTime FECHACREACION { get; set; }

        public string FECHA_ACTUAL { get; set; }
        [Display(Name = "Fecha estimada")]
        public string FECHA_ESTIMADA { get; set; }
        [Display(Name = "Estado")]
        public string ESTADO { get; set; }

        public int Rut_Usu { get; set; }
        [Display(Name = "Tareas terminadas")]
        public int Tareas_ter { get; set; }
        [Display(Name = "Total tareas")]
        public int Cant_tareas_tot { get; set; }
        [Display(Name = "Progreso")]
        public int procentaje { get; set; }
        [Display(Name = "Responsable")]
        public string nombre_usurio { get; set; }
        public int ATRASO { get; set; }
        [Display(Name = "Días restantes")]
        public int DIAS_DIF { get; set; }
        public List<Dashboard_Gen> listgen {get;set;}
    }
}
