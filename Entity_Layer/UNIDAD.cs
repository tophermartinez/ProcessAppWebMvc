using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class UNIDAD
    {
        public int ID_UNIDAD { get; set; }

        public string NOMBRE { get; set; }

        public string DETALLE { get; set; }

        public string FECHA_TERMINO { get; set; }

        public DateTime FECHACREACION { get; set; }

        public string FECHA_ACTUAL { get; set; }

        public int ESTADO { get; set;  }

        public string nombre_usuario { get; set; }

        public int RUT_EM { get; set; }
        public int RUT_USU { get; set; }
        public string FechaEstimada { get; set; }
    }
}
