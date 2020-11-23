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
        public int RUT { get; set; }
        public char DV { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string NOMBRES { get; set; }
        [Column("NOMBRES")]
        public string APELLIDO_PATERNO { get; set; }
        public string APELIIDO_MATERNO { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [DataType(DataType.EmailAddress)]
        public string CORREO { get; set; }
        [Display(Name = "Telefono Contacto")]
        [StringLength(8, ErrorMessage = "Numero no puede contener mas de 8 digitos")]
        [MinLength(8, ErrorMessage = "Numero no puede contener menos de 8 digitos")]
        public int NUMERO { get; set; }
        public string DIRECCION { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        [Column("NOMBRE_USUARIO")]
        public string CONTRASENA { get; set; }
        [Column("NOMBRE_USUARIO")]
        public int ID_PERFIL { get; set; }
        [Column("ID_PERFIL")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int ESTADO { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int EMPRESA { get; set; }

        




    }
}
