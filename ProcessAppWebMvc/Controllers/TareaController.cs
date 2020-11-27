using Bussines_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAcces;
using System.Web.Security;
using System.Web.UI;


namespace ProcessAppWebMvc.Controllers
{
    public class TareaController : Controller
    {
        
        // GET: Tarea
        [HttpPost]
        public ActionResult Insert(FormCollection fc)
        {
            TAREA dto = new TAREA();
            dto.NOMBRETAREA = fc["NOMBRETAREA"];
            dto.RUT_USU = Convert.ToInt32(fc["RUT_USU"]);
            dto.FechaEstimada = fc["FechaEstimada"];
            dto.ESTADO_TAREA = Convert.ToInt32(fc["ESTADO_TAREA"]);
            dto.RUT_EM = Convert.ToInt32(Session["rutempresa"]);

            NegocioTarea tar = new NegocioTarea();
            tar.Insert(dto);
            // return View("Insert", obj);
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
            dto.RUT_USU = (int)Session["rut"];
            return View("Update", dto);
        }

        public ActionResult Insert()
        {
            DataAcces.DaoCliente dc = new DataAcces.DaoCliente();
            DataAcces.DaoTarea dt = new DataAcces.DaoTarea();
            try
            {
                int rut_empresa = Convert.ToInt32(Session["rutempresa"]);
                List<estado> list = dt.ObtenerEstadoTarea();
                List<USUARIO> list2 = dc.ObtenerListaUsuarios(0, rut_empresa, 1);
                ViewBag.EstadosTarea = list;
                ViewBag.ListaUsuarios = list2;
            }
            catch (Exception ex)
            {
                new Exception("ERROR EN METODO LISTAR" + ex.Message);
            }
            return View("Insert", new TAREA());
        }
    }
}