using Bussines_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcessAppWebMvc.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        [HttpPost]
        public ActionResult Insert(PERFIL dto)
        {
            if (Session["Perfil"] != null)
            {
                NegocioPerfil obj = new NegocioPerfil();
                obj.Insert(dto);
                return RedirectToAction("Read");
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }

        }
        [HttpPost]
        public ActionResult Update(PERFIL dto)
        {
            if (Session["Perfil"] != null)
            {
                NegocioPerfil obj = new NegocioPerfil();
                obj.Update(dto);
                return RedirectToAction("Read");
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
          
        }
        public ActionResult Delete(string ID_PERFIL)
        {
            if (Session["Perfil"] != null)
            {
                NegocioPerfil obj = new NegocioPerfil();
                obj.Delete(ID_PERFIL);
                return RedirectToAction("Read");
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
        }
        public ActionResult Read()
        {
            if (Session["Perfil"] != null)
            {
                NegocioPerfil obj = new NegocioPerfil();
                return View(obj.Read());
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
           
        }
        public ActionResult Update(int ID_PERFIL)
        {
            if (Session["Perfil"] != null)
            {
                NegocioPerfil obj = new NegocioPerfil();
                PERFIL dto = obj.Read().FirstOrDefault(a => a.ID_PERFIL == ID_PERFIL);
                return View("Update", dto);
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
           
        }

        public ActionResult Insert()
        {
            if (Session["Perfil"] != null)
            {
                return View("Insert", new PERFIL());
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
          
        }
    }
}