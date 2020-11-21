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
        public int RUT { get; set; }
        public char DV { get; set; }
        public string NOMBRES { get; set; }
        [Column("NOMBRES")]
        public string APELLIDO_PATERNO { get; set; }
        public string APELIIDO_MATERNO { get; set; }
        public string CORREO { get; set; }
        public int NUMERO { get; set; }
        public string DIRECCION { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        [Column("NOMBRE_USUARIO")]
        public string CONTRASENA { get; set; }
        [Column("NOMBRE_USUARIO")]
        public int ID_PERFIL { get; set; }
        [Column("ID_PERFIL")]
        public int ESTADO { get; set; }
        public int EMPRESA { get; set; }

        




    }
}
