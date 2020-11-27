using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class UNIDAD_DETALLE
    {
        public int id { get; set; }

        public int ID_UNIDAD { get; set; }

        public string NOMBRE_UNIDAD { get; set; }
        public int   ID_TAREA { get; set; }

        public string NOMBRE_TAREA { get; set; }

        public string FECHA_TERMINO { get; set; }

        public DateTime FECHACREACION { get; set; }

        public string FECHA_ACTUAL { get; set; }

        public string FECHA_ESTIMADA { get; set; }

        public int ESTADO { get; set; }

        public int Rut_Usu { get; set; }
        public string NOMBRE_USUARIO{ get; set; }



    }
}
