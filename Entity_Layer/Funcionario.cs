using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Funcionario
    {

        public int RUT { get; set; }
        public char DIGITOV { get; set; }
        public string NOMBRE { get; set; }
        public string NOMBRE2 { get; set; }
        public string APELLIDO { get; set; }
        public string APELLIDO2 { get; set; }
        public int TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public string ID_USUARIO { get; set; }
        public string ID_ROL { get; set; }
        public string ID_UNIDAD { get; set; }

        public string P_RESULT { get; set; }
    }
}