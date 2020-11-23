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

        public DateTime FECHA_TERMINO { get; set; }

        public DateTime FECHACREACION { get; set; }

        public DateTime FECHA_ACTUAL { get; set; }

        public int ID_EMPRESAU { get; set;  }

        public int ID_USUARIOU { get; set; }

        public int RUT_EM { get; set; }
        public int RUT_USU { get; set; }
    }
}
