using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class PERFIL
    {

        public int ID_PERFIL { get; set; }
        [Display(Name = "Nombre Rol")]
        public string NOMBRE { get; set; }
        [Display(Name = "Descripción")]
        public string DESCRIPCION { get; set; }

    }
}
