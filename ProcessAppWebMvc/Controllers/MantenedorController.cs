using Bussines_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAcces;
using System.Web.Security;
using System.Web.UI;

namespace ProcessAppWebMvc.Controllers
{
    
    public class MantenedorController : Controller
    {
        DaoCliente dao;

        public MantenedorController()
        {
            this.dao = new DaoCliente();
        }

        [HttpPost]
        public ActionResult Insert(FormCollection fc)
        {
            USUARIO dto = new USUARIO();
            dto.RUT = fc["RUT"];
            dto.NOMBRES = fc["NOMBRES"];
            dto.APELLIDO_PATERNO = fc["APELLIDO_PATERNO"];
            dto.APELIIDO_MATERNO = fc["APELIIDO_MATERNO"];
            dto.CORREO = fc["CORREO"];
            dto.NUMERO = Convert.ToInt32(fc["NUMERO"]);
            dto.DIRECCION = fc["DIRECCION"];
            dto.NOMBRE_USUARIO = fc["NOMBRE_USUARIO"];
            dto.CONTRASENA = fc["CONTRASENA"];
            dto.ID_PERFIL = Convert.ToInt32(fc["PERFIL"]);
            dto.ESTADO = Convert.ToInt32(fc["ESTADO"]);
            dto.EMPRESA = Convert.ToInt32(fc["EMPRESA"]);
            NegocioCliente neg = new NegocioCliente();
            neg.Insert(dto);
            return RedirectToAction("Read");
        }

        [HttpPost]
        public ActionResult Update(USUARIO dto)
        {
            NegocioCliente neg = new NegocioCliente();
            neg.Update(dto);
            return RedirectToAction("Read"); ;


        }

        public ActionResult Delete(int ID)
        {
            NegocioCliente neg = new NegocioCliente();
            neg.Delete(ID);
            return RedirectToAction("Read"); ;
        }

        public ActionResult Read()
        {
            if(Session["Perfil"] != null)
            {
                NegocioCliente neg = new NegocioCliente();
                return View(neg.Read());
            }
            else
            {
                return View("LoginProcess");
            }
           
        }


        [HttpGet]
        public ActionResult Update(int ID)
        {
            if (Session["Perfil"] != null)
            {
                NegocioCliente neg = new NegocioCliente();
                USUARIO usu = neg.Read().FirstOrDefault(a => a.ID == ID);
                ViewBag.estado = usu.ESTADO;
                ViewBag.perfil = usu.ID_PERFIL;
                DataAcces.DaoEmpresa de = new DataAcces.DaoEmpresa();
                DataAcces.DaoCliente dc = new DataAcces.DaoCliente();
                try
                {
                    List<estado> list = de.ObtenerEstadoUsuario();
                    List<PERFIL> list3 = dc.ObtenerListaPerfiles();
                    ViewBag.EstadosUsuario = list;
                    ViewBag.ListaPerfiles = list3;
                }
                catch (Exception ex)
                {
                    new Exception("ERROR EN METODO LISTAR" + ex.Message);
                }
                return View("Update", usu);
            }
            else
            {
                return View("LoginProcess");
            }
        }

        public ActionResult Insert()
        {
            if (Session["Perfil"] != null)
            {
                DataAcces.DaoEmpresa de = new DataAcces.DaoEmpresa();
                DataAcces.DaoCliente dc = new DataAcces.DaoCliente();
                try
                {
                    List<estado> list = de.ObtenerEstadoUsuario();
                    List<EMPRESA> list2 = de.ObtenerListaEmpresas();
                    List<PERFIL> list3 = dc.ObtenerListaPerfiles();
                    ViewBag.EstadosUsuario = list;
                    ViewBag.ListaEmpresas = list2;
                    ViewBag.ListaPerfiles = list3;
                }
                catch (Exception ex)
                {
                    new Exception("ERROR EN METODO LISTAR" + ex.Message);
                }

                return View("Insert", new USUARIO());
            }
            else
            {
                return View("LoginProcess");
            }
            
        }




        public ActionResult Login()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (Session["Perfil"] != null)
            {
                return View("LoginProcess");// deberia redirigir a una mantenedor
            }
            else
            {
                return View("LoginProcess");
            }
        

        }

        [HttpPost]
        public ActionResult LoginPost(FormCollection fc)
        {
            ViewBag.error = null;
            string nombre = fc["usu"];
            Session["usu"] = nombre;
            string pass = fc["pass"];
            //Session["pass"] = pass;
            //string Rol = fc["Rol"];
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            DaoCliente dao = new DaoCliente();
            USER_INFO result = dao.Login(nombre, pass);

            if (result != null)
            {
                Session["nombre"] = result.NOMBRE;
                Session["apellido"] = result.APELLIDO;
                Session["rut"] = result.RUT;
                Session["rutempresa"] = result.RUT_EMPRESA;
                Session["perfil"] = result.PERFIL;
                Session["nombreemp"] = result.NOMBRE_EMPRESA;
                Session["nombreper"] = result.NOMBRE_PERFIL;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.error = "Usuario o contraseña incorrecto(s)";
                return View("LoginProcess");
            }


            /*
            if (result.Equals("Administrador"))
            {
                return RedirectToAction("Dashboard");
            }
            else if (result.Equals("Funcionario"))
            {

                return RedirectToAction("Tareas");
            }
            else if (result.Equals("Diseñador"))
            {
                return RedirectToAction("Flujos");
            }
            else
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                return View("LoginProcess");// deberia redirigir a una mantenedor
            }
            */
        }

        [HttpPost]
        
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult Logout()
        {
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
           //Session.Abandon(); 
            Session.Clear();
            //FormsAuthentication.SignOut();
            FormsAuthentication.SignOut();
            //Session["usu"] = null;
            Session.Abandon();
            //Response.Redirect("LoginProcess", false);
            //if (Session["usu"] != null)
            //{
            //    return RedirectToAction("LoginPost");
            //}
            //else {
            return View("LoginProcess");
            //}
            //
            //
          //  Redir
        }


        public ActionResult Dashboard()
        {
            if (Session["Perfil"] != null)
            {
                DataAcces.DaoDashboard ds = new DaoDashboard();

                List<Dashboard_Gen> dsGen = ds.DashBoard(Convert.ToInt32(Session["rut"]) , Convert.ToString(Session["rutempresa"]));

                ViewBag.Daslist = dsGen;
                return View(dsGen);
            }
            else
            {
                return View("LoginProcess");
            }
        }

    
    }


}
