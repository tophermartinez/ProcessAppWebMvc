using Bussines_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcessAppWebMvc.Controllers
{
    public class EmpresaController : Controller
    {
        [HttpPost]
        public ActionResult Insert(EMPRESA dto)
        {
            NegocioEmpresa emp = new NegocioEmpresa();
            emp.Insert(dto);
            return RedirectToAction("Read");
        }
        [HttpPost]
        public ActionResult Update(EMPRESA dto)
        {
            NegocioEmpresa emp = new NegocioEmpresa();
            emp.Update(dto);
            return RedirectToAction("Read");
        }

        public ActionResult Delete(string id)
        {
            NegocioEmpresa emp = new NegocioEmpresa();
            emp.Delete(id);
            return RedirectToAction("Read");
        }
        public ActionResult Read()
        {
            NegocioEmpresa emp = new NegocioEmpresa();
            return View(emp.Read());
        }
        [HttpGet]
        public ActionResult Update(string ID)
        {
            NegocioEmpresa emp = new NegocioEmpresa();
            EMPRESA aux = emp.Read().FirstOrDefault(a => a.ID == int.Parse(ID));
            return View("Update", aux);
        }
        public ActionResult Insert()
        {
            return View("Insert",new EMPRESA());
        }
    }
}