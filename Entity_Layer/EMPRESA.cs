using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
  public  class EMPRESA
    {
        public int ID { get; set; }
        public int RUT { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public string CORREO_CONTACTO { get; set; }
        public int TELEFONO_CONTACTO { get; set; }
        public int ESTADO { get; set; }

    }
}
