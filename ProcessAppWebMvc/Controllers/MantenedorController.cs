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
        public ActionResult Insert(USUARIO dto)
        {
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
                return View();
            }
            else
            {
                return View("LoginProcess");
            }
        }

    }


}
