using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessAppWebMvc.Models
{
    public class Rol
    {
        public Usuario user { get; set; }
        public int identificador { get; set; }
        public string jerarquia { get; set; }
        public string  descripcion { get; set; }
    }
}