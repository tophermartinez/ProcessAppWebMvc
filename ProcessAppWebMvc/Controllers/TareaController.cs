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
            DataAcces.DaoEmpresa de = new DataAcces.DaoEmpresa();
            try
            {
                List<estado> list = de.ObtenerEstadoUsuario();
                ViewBag.EstadosUsuario = list;
            } 
            catch (Exception ex)
            {
                new Exception("ERROR EN METODO LISTAR" + ex.Message);
            }
            return View("Insert", new TAREA());
        }



        // GET: TareaF
        [HttpPost]
        public ActionResult InsertF(TAREA dto)
        {
            NegocioTarea obj = new NegocioTarea();
           
            obj.InsertF(dto);
            return RedirectToAction("ReadF");
        }
        [HttpPost]
        public ActionResult UpdateF(TAREA dto)
        {
            NegocioTarea obj = new NegocioTarea();
            obj.UpdateF(dto);
            return RedirectToAction("ReadF");
        }
        public ActionResult DeleteF(string IDTAREA)
        {
            NegocioTarea obj = new NegocioTarea();
            obj.DeleteF(IDTAREA);
            return RedirectToAction("ReadF");
        }
        public ActionResult ReadF()
        {
            NegocioTarea obj = new NegocioTarea();
            return View(obj.ReadF());
        }
        public ActionResult UpdateF(int IDTAREA)
        {
            NegocioTarea obj = new NegocioTarea();
            TAREA dto = obj.ReadF().FirstOrDefault(a => a.IDTAREA == IDTAREA);
            return View("UpdateF", dto);
        }

        public ActionResult InsertF()
        {
            return View("InsertF", new TAREA());
        }
    }
}