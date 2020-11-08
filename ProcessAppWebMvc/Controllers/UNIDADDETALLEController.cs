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
            NegocioUNIDADDET obj = new NegocioUNIDADDET();
            obj.Insert(dto);
            return RedirectToAction("Read");
        }
        [HttpPost]
        public ActionResult Update(UNIDAD_DETALLE dto)
        {
            NegocioUNIDADDET obj = new NegocioUNIDADDET();
            obj.Update(dto);
            return RedirectToAction("Read");
        }
        public ActionResult Delete(string ID)
        {
            NegocioUNIDADDET obj = new NegocioUNIDADDET();
            obj.Delete(ID);
            return RedirectToAction("Read");
        }
        public ActionResult Read()
        {
            NegocioUNIDADDET obj = new NegocioUNIDADDET();
            return View(obj.Read());
        }
        public ActionResult Update(int id)
        {
            NegocioUNIDADDET obj = new NegocioUNIDADDET();
            UNIDAD_DETALLE dto = obj.Read().FirstOrDefault(a => a.id == id);
            return View("Update", dto);
        }

        public ActionResult Insert()
        {
            return View("Insert", new UNIDAD_DETALLE());
        }
    }
}