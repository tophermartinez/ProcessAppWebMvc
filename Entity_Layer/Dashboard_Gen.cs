using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Dashboard_Gen
    {
        public string NOMBRE_UNIDAD { get; set; }
        public int ID_TAREA { get; set; }

        public string NOMBRE_TAREA { get; set; }

        public string FECHA_TERMINO { get; set; }

        public DateTime FECHACREACION { get; set; }

        public string FECHA_ACTUAL { get; set; }

        public string FECHA_ESTIMADA { get; set; }

        public string ESTADO { get; set; }

        public int Rut_Usu { get; set; }

        public int Tareas_ter { get; set; }
        public int Cant_tareas_tot { get; set; }

        public int procentaje { get; set; }
        public string nombre_usurio { get; set; }
        public int ATRASO { get; set; }
        public List<Dashboard_Gen> listgen {get;set;}
    }
}
