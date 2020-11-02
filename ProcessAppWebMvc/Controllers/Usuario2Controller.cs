using Bussines_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcessAppWebMvc.Controllers
{
    public class Usuario2Controller : Controller
    {
        
        // GET: Tarea
        [HttpPost]
        public ActionResult Insert(Usuario2 dto)
        {
            NegocioCliente2 obj = new NegocioCliente2();
            obj.Insert(dto);
            return RedirectToAction("Read");
        }
        [HttpPost]
        public ActionResult Update(Usuario2 dto)
        {
            NegocioCliente2 obj = new NegocioCliente2();
            obj.Update(dto);
            return RedirectToAction("Read");
        }
        public ActionResult Delete(string ID_USUARIO)
        {
            NegocioCliente2 obj = new NegocioCliente2();
            obj.Delete(ID_USUARIO);
            return RedirectToAction("Read");
        }
        public ActionResult Read()
        {
            NegocioCliente2 obj = new NegocioCliente2();
            return View(obj.Read());
        }
        public ActionResult Update(int ID_USUARIO)
        {
            NegocioCliente2 obj = new NegocioCliente2();
            Usuario2 dto = obj.Read().FirstOrDefault(a => a.ID_USUARIO == ID_USUARIO);
            return View("Update", dto);
        }

        public ActionResult Insert()
        {
            return View("Insert", new Usuario2());
        }
    }
}