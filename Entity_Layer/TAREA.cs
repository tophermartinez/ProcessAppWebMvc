using System;
using System.Collections.Generic;
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


    }
}
