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
            if (Session["Perfil"] != null)
            {
                NegocioUnidad obj = new NegocioUnidad();
                obj.Insert(dto);
                return RedirectToAction("Read");
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
        
        }
        [HttpPost]
        public ActionResult Update(UNIDAD dto)
        {
            if (Session["Perfil"] != null)
            {
                NegocioUnidad obj = new NegocioUnidad();
                obj.Update(dto);
                return RedirectToAction("Read");
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
        }
        public ActionResult Delete(string ID_UNIDAD)
        {
            if (Session["Perfil"] != null)
            {
                NegocioUnidad obj = new NegocioUnidad();
                obj.Delete(ID_UNIDAD);
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
                NegocioUnidad obj = new NegocioUnidad();
                return View(obj.Read());
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
        }
        public ActionResult Update(int ID_UNIDAD)
        {
            if (Session["Perfil"] != null)
            {
                NegocioUnidad obj = new NegocioUnidad();
                UNIDAD dto = obj.Read().FirstOrDefault(a => a.ID_UNIDAD == ID_UNIDAD);
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
                return View("Insert", new UNIDAD());
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
            
        }



        /*
        // GET: UnidadesF}
        [HttpPost]
        public ActionResult InsertF(UNIDAD dto)
        {
            NegocioUnidad obj = new NegocioUnidad();
            obj.InsertF(dto);
            return RedirectToAction("ReadF");
        }
        [HttpPost]
        public ActionResult UpdateF(UNIDAD dto)
        {
            NegocioUnidad obj = new NegocioUnidad();
            obj.UpdateF(dto);
            return RedirectToAction("ReadF");
        }
        public ActionResult DeleteF(string ID_UNIDAD)
        {
            NegocioUnidad obj = new NegocioUnidad();
            obj.DeleteF(ID_UNIDAD);
            return RedirectToAction("ReadF");
        }
        public ActionResult ReadF()
        {
            NegocioUnidad obj = new NegocioUnidad();
            return View(obj.ReadF());
        }
        public ActionResult UpdateF(int ID_UNIDAD)
        {
            NegocioUnidad obj = new NegocioUnidad();
            UNIDAD dto = obj.ReadF().FirstOrDefault(a => a.ID_UNIDAD == ID_UNIDAD);
            return View("UpdateF", dto);
        }
        */
        public ActionResult InsertF()
        {
            return View("InsertF", new UNIDAD());
        }
    }
}