using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class EMPRESA
    {
        public int ID { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "RUT Inválido")]
        [MinLength(11, ErrorMessage ="RUT Inválido")]
        [MaxLength(12, ErrorMessage = "RUT Inválido")]
        public String RUT { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre requerido.")]
        public string NOMBRE { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Dirección requerido.")]
        public string DIRECCION { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Correo requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        public string CORREO_CONTACTO { get; set; }
        [Display(Name = "Telefono Contacto")]
        [Range(10000000, 99999999, ErrorMessage = "Debe tener 8 dígitos")]
        public long  TELEFONO_CONTACTO { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Estado requerido.")]
        public int ESTADO { get; set; }
        public string NOMBRE_ESTADO { get; set; }

    }
}
