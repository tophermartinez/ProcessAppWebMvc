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
            NegocioCliente neg = new NegocioCliente();
            return View(neg.Read());
        }


        [HttpGet]
        public ActionResult Update(int ID)
        {
            NegocioCliente neg = new NegocioCliente();
            USUARIO usu = neg.Read().FirstOrDefault(a => a.ID == ID);
            return View("Update", usu);

        }

        public ActionResult Insert()
        {
            return View("Insert", new USUARIO());
        }




        public ActionResult Login()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            return View("LoginProcess");// deberia redirigir a una mantenedor

        }

        [HttpPost]
        public ActionResult LoginPost(FormCollection fc)
        {
            string nombre = fc["usu"];
            Session["usu"] = nombre;

            string pass =   fc["pass"];

            Session["pass"] = pass;

            //string Rol = fc["Rol"];
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            DaoCliente dao = new DaoCliente();
           string result = dao.Login(nombre, pass);

            Session["Perfil"] = result;

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
             Session.Abandon(); 
            Session.Clear();
            //FormsAuthentication.SignOut();
            FormsAuthentication.SignOut();
            Session["usu"] = null;
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


        public ActionResult Tareas()
        {
            return View();
        }

        public ActionResult Flujos()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

    }


}
