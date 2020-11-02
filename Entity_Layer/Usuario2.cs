using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
   public  class Usuario2
    {
        public int ID_USUARIO { get; set; }
        public  int RUT { get; set; }
        public  char DV { get; set; }
        public string NOMBRES { get; set; }

        public string APELLIDO_PATERNO { get; set; }
        public string APELIIDO_MATERNO { get; set; }
        public string CORREO { get; set; }
        public int NUMERO { get; set; }
        public string DIRECCION  { get; set; }
        public string NOMBRE_USUARIO  { get; set; }
        public string CONTRASENA  { get; set; }
        public int ID_PERFIL  { get; set; }
        public int ESTADO  { get; set; }
        public int EMPRESA  { get; set; }
    }
}
