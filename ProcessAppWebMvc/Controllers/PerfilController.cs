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
            NegocioPerfil obj = new NegocioPerfil();
            obj.Insert(dto);
            return RedirectToAction("Read");
        }
        [HttpPost]
        public ActionResult Update(PERFIL dto)
        {
            NegocioPerfil obj = new NegocioPerfil();
            obj.Update(dto);
            return RedirectToAction("Read");
        }
        public ActionResult Delete(string ID_PERFIL)
        {

            NegocioPerfil obj = new NegocioPerfil();
            obj.Delete(ID_PERFIL);
            return RedirectToAction("Read");
        }
        public ActionResult Read()
        {
        NegocioPerfil obj = new NegocioPerfil();
            return View(obj.Read());
        }
        public ActionResult Update(int ID_PERFIL)
        {
            NegocioPerfil obj = new NegocioPerfil();
            PERFIL dto = obj.Read().FirstOrDefault(a => a.ID_PERFIL == ID_PERFIL);
            return View("Update", dto);
        }

        public ActionResult Insert()
        {
            return View("Insert", new PERFIL());
        }
    }
}