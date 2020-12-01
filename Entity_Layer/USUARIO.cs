using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    [Table("Usuarios")]
    public class USUARIO
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int ID { get; set; }
        [Required(ErrorMessage = "RUT Inválido")]
        [MinLength(11, ErrorMessage = "RUT Inválido")]
        [MaxLength(12, ErrorMessage = "RUT Inválido")]
        public String RUT { get; set; }
        public char DV { get; set; }
        [Required(ErrorMessage = "Nombre requerido.")]
        [Display(Name = "Nombres")]
        public string NOMBRES { get; set; }
        [Display(Name = "Apellido paterno")]
        [Required(ErrorMessage = "Apellido paterno requerido.")]
        public string APELLIDO_PATERNO { get; set; }
        [Display(Name = "Apellido materno")]
        [Required(ErrorMessage = "Apellido materno requerido.")]
        public string APELIIDO_MATERNO { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Correo requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
        ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        public string CORREO { get; set; }
        [Display(Name = "Telefono Contacto")]
        [Range(10000000, 99999999, ErrorMessage = "Debe tener 8 dígitos")]
        public long NUMERO { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Dirección requerido.")]
        public string DIRECCION { get; set; }
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Usuario requerido.")]
        public string NOMBRE_USUARIO { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Contraseña requerido.")]
        [DataType("Password")]
        public string CONTRASENA { get; set; }
        [Display(Name = "Perfil")]
        public int ID_PERFIL { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Estado")]
        public int ESTADO { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Empresa")]
        public int EMPRESA { get; set; }

        public string NOMBRE_PERFIL { get; set; }
        public string NOMBRE_ESTADO { get; set; }
        public string NOMBRE_EMPRESA { get; set; }




    }
}
