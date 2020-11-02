using Bussines_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcessAppWebMvc.Controllers
{
    public class UnidadesController : Controller
    {
        // GET: Unidades}
        [HttpPost]
        public ActionResult Insert(UNIDAD dto)
        {
            NegocioUnidad obj = new NegocioUnidad();
            obj.Insert(dto);
            return RedirectToAction("Read");
        }
        [HttpPost]
        public ActionResult Update(UNIDAD dto)
        {
            NegocioUnidad obj = new NegocioUnidad();
            obj.Update(dto);
            return RedirectToAction("Read");
        }
        public ActionResult Delete(string IDTAREA)
        {
            NegocioUnidad obj = new NegocioUnidad();
            obj.Delete(IDTAREA);
            return RedirectToAction("Read");
        }
        public ActionResult Read()
        {
            NegocioUnidad obj = new NegocioUnidad();
            return View(obj.Read());
        }
        public ActionResult Update(int ID_UNIDAD)
        {
            NegocioUnidad obj = new NegocioUnidad();
            UNIDAD dto = obj.Read().FirstOrDefault(a => a.ID_UNIDAD == ID_UNIDAD);
            return View("Update", dto);
        }

        public ActionResult Insert()
        {
            return View("Insert", new UNIDAD());
        }
    }
}