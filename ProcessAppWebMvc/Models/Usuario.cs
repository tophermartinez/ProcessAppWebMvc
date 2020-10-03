using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessAppWebMvc.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string apellido { get; set; }
        public string rut { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public string usuario { get; set; }
        public string pass { get; set; }
        public Rol rol { get; set; }
        public Unidad unidad { get; set; }




    }
}