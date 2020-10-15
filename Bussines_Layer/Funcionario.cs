using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussines_Layer;

namespace Entity_Layer
{
    public class Funcionario
    {
       

        //public int RUT { get; set; }
        //public char DIGITOV { get; set; }
        //public string NOMBRE { get; set; }
        //public string NOMBRE2 { get; set; }
        //public string APELLIDO { get; set; }
        //public string APELLIDO2 { get; set; }
        //public int TELEFONO { get; set; }
        //public string EMAIL { get; set; }
        //public string ID_USUARIO { get; set; }
        //public string ID_ROL { get; set; }
        //public string ID_UNIDAD { get; set; }

        //public string P_RESULT { get; set; }
        public short Idfuncionario { get; set; }
        public long Rut { get; set; }
        public string Dv { get; set; }
        public string Pnombre { get; set; }
        public string Snombre { get; set; }
        public string Apaterno { get; set; }
        public string Amaterno { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public short Unidad_Idunidad { get; set; }

        public Funcionario()
        {

        }
        public Funcionario(short idfuncionario, long rut, string dv, string pnombre, string snombre, string apaterno, string amaterno, int telefono, string correo, string direccion, short unidad_Idunidad)
        {
            Idfuncionario = idfuncionario;
            Rut = rut;
            Dv = dv;
            Pnombre = pnombre;
            Snombre = snombre;
            Apaterno = apaterno;
            Amaterno = amaterno;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            Unidad_Idunidad = unidad_Idunidad;
        }

        public bool IngresaFuncionario()
        {
            // ejemplo variable salida
            var salida = new System.Data.Objects.ObjectParameter("var_salida", typeof(decimal));
            ConexionEntity.ProcessModelo.FUNCIONARIO_INS(Idfuncionario, Rut, Dv, Pnombre, Snombre, Apaterno, Amaterno, Telefono, Correo, Direccion, Unidad_Idunidad);
            

            return false;
        }
    }
}