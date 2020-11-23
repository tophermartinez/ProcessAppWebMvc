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
       public string NOMBRETAREA { get; set; }
       public DateTime FECHACREACION { get; set; }
       public int ESTADO_TAREA { get; set; }

        public DateTime FECHA_ACTUAL { get; set; }

        public DateTime FECHA_TERMINO { get; set; }

        public int  ID_EMPRESA { get; set; }
        public int  ID_USUARIO { get; set; }

        public int RUT_EM { get; set; }
        public int RUT_USU { get; set; }



    }
}
