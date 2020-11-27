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
        //[Display(Name = "RUT")]
        //[Required(ErrorMessage = "Este campo es requerido.")]
        //[StringLength(9,ErrorMessage ="Rut inválido")]
        //[MinLength(8,ErrorMessage ="Rut inválido")]
        [DataType(DataType.Text)]
        public String RUT { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        
        public string NOMBRE { get; set; }
        [Display(Name = "Dirección")]
        public string DIRECCION { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
            [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [DataType(DataType.EmailAddress)]
        public string CORREO_CONTACTO { get; set; }
        [Display(Name = "Telefono Contacto")]
        //[StringLength(8, ErrorMessage = "Numero no puede contener mas de 8 digitos")]
        //[MinLength(8, ErrorMessage = "Numero no puede contener menos de 8 digitos")]
        public long  TELEFONO_CONTACTO { get; set; }
        [Display(Name = "Estado")]
        public int ESTADO { get; set; }
        public string NOMBRE_ESTADO { get; set; }

    }
}
