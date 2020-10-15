using ProcessAppWebMvc.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;


namespace ProcessAppWebMvc.ProcesService
{
    public class UsuariosService
    {
        public Usuario ObtenerUser()
        {
            return new Usuario()
            {
                Nombre = "cristopher",
                //apellido = "Martínez",
                //rut = "17638455-7",
                //email = "edad21@gmail.com",
                //telefono = 445454545,
                //usuario = "Topher",
                pass = "12345"
            };

        }
        public List<Usuario> ObtenerUsers()
        {
            var usu1 = new Usuario()
            {
                Nombre = "cristopher",
                //apellido = "Martínez",
                //rut = "17638455-7",
                //email = "edad21@gmail.com",
                //telefono = 445454545,
                //usuario = "Topher",
                pass = "12345"
            };
            var usu2 = new Usuario()
            {
                Nombre = "Ruben",
                //apellido = "Alamos",
                //rut = "17638455-7",
                //email = "edad21@gmail.com",
                //telefono = 445454545,
                //usuario = "Topher",
                pass = "12345"
            };
            var usu3 = new Usuario()
            {
                Nombre = "Alex",
                //apellido = "bd",
                //rut = "17638455-7",
                //email = "edad21@gmail.com",
                //telefono = 445454545,
                //usuario = "Topher",
                pass = "12345"
            };
            var usu4 = new Usuario()
            {
                Nombre = "ignacio",
                //apellido = "jp",
                //rut = "17638455-7",
                //email = "edad21@gmail.com",
                //telefono = 445454545,
                //usuario = "Topher",
                pass = "12345"
            };

            return new List<Usuario> { usu1, usu2, usu3, usu4 };
        }

    }
}