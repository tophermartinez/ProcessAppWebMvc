using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussines_Layer;
using Entity_Layer;

namespace ProcessAppWebMvc.Controllers
{
    public class UNIDADDETALLEController : Controller
    {
        // GET: UNIDADDETALLE
        [HttpPost]
        public ActionResult Insert(UNIDAD_DETALLE dto)
        {
            if (Session["Perfil"] != null)
            {
                NegocioUNIDADDET obj = new NegocioUNIDADDET();
                obj.Insert(dto);
                return RedirectToAction("Read");
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
        }
        [HttpPost]
        public ActionResult Update(UNIDAD_DETALLE dto)
        {
            if (Session["Perfil"] != null)
            {
                NegocioUNIDADDET obj = new NegocioUNIDADDET();
                obj.Update(dto);
                return RedirectToAction("Read");
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
            
        }
        public ActionResult Delete(string ID)
        {
            if (Session["Perfil"] != null)
            {
                NegocioUNIDADDET obj = new NegocioUNIDADDET();
                obj.Delete(ID);
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
                NegocioUNIDADDET obj = new NegocioUNIDADDET();
                return View(obj.Read());
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
          
        }
        public ActionResult Update(int id)
        {
            if (Session["Perfil"] != null)
            {
                NegocioUNIDADDET obj = new NegocioUNIDADDET();
                UNIDAD_DETALLE dto = obj.Read().FirstOrDefault(a => a.id == id);
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
                return View("Insert", new UNIDAD_DETALLE());
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
           
        }
    }
}