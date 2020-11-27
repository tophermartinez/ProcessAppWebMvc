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
        //public int IdLibro { get; set; }
        //[Column("Titulo")]
        //public String Titulo { get; set; }
        //[Column("Autor")]
        //public String Autor { get; set; }

        public int ID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public String RUT { get; set; }
        public char DV { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nombres")]
        public string NOMBRES { get; set; }
        [Display(Name = "Apellido paterno")]
        public string APELLIDO_PATERNO { get; set; }
        [Display(Name = "Apellido Materno")]
        public string APELIIDO_MATERNO { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [DataType(DataType.EmailAddress)]
        public string CORREO { get; set; }
        [Display(Name = "Teléfono Contacto")]
        //[StringLength(8, ErrorMessage = "Numero no puede contener mas de 8 digitos")]
        //[MinLength(8, ErrorMessage = "Numero no puede contener menos de 8 digitos")]
        public int NUMERO { get; set; }
        [Display(Name = "Dirección")]
        public string DIRECCION { get; set; }
        [Display(Name = "Usuario")]
        public string NOMBRE_USUARIO { get; set; }
        [Display(Name = "Contraseña")]
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
