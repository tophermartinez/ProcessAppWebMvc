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
        [Required(ErrorMessage = "Nombre Rol requerido.")]
        public string NOMBRE { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Descripción requerido.")]
        public string DESCRIPCION { get; set; }

    }
}
