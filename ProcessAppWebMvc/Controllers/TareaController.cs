using Bussines_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcessAppWebMvc.Controllers
{
    public class TareaController : Controller
    {
        

        // GET: Tarea
        [HttpPost]
        public ActionResult Insert(TAREA dto)
        {
            NegocioTarea obj = new NegocioTarea();
            obj.Insert(dto);
            return RedirectToAction("Read");
        }
        [HttpPost]
        public ActionResult Update(TAREA dto)
        {
            NegocioTarea obj = new NegocioTarea();
            obj.Update(dto);
            return RedirectToAction("Read");
        }
        public ActionResult Delete(string IDTAREA)
        {
            NegocioTarea obj = new NegocioTarea();
            obj.Delete(IDTAREA);
            return RedirectToAction("Read");
        }
        public ActionResult Read()
        {
            NegocioTarea obj = new NegocioTarea();
            return View(obj.Read());
        }
        public ActionResult Update(int IDTAREA)
        {
            NegocioTarea obj = new NegocioTarea();
            TAREA dto = obj.Read().FirstOrDefault(a => a.IDTAREA == IDTAREA);
            return View("Update", dto);
        }

        public ActionResult Insert()
        {
            return View("Insert", new TAREA());
        }
    }
}