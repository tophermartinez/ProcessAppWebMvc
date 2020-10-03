using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace ProcessAppWebMvc.Models
{
    public class Tarea
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public int estado { get; set; }
        public Usuario usuario { get; set; }
        public Flujo flujo { get; set; }
    }
}