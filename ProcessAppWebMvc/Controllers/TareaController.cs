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
            dto.RUT_USU = Convert.ToInt32(Session["rut"]);
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

        [HttpGet]
        public ActionResult Update(int IDTAREA)
        {
            NegocioTarea obj = new NegocioTarea();
            TAREA aux = obj.Read().FirstOrDefault(a => a.IDTAREA == IDTAREA);
        
            ViewBag.Estado = aux.ESTADO_TAREA;
            ViewBag.Usuario = aux.RUT_USU;
            DataAcces.DaoEmpresa de = new DataAcces.DaoEmpresa();
            DataAcces.DaoTarea dt = new DataAcces.DaoTarea();
            try
            {
                int rut_empresa = Convert.ToInt32(Session["rutempresa"]);
                 List<estado> list = de.ObtenerEstadoUsuario();
                   
                List<TAREA> list3 = dt.ObtenerPosts(aux.IDTAREA);
                ViewBag.EstadosTarea = list;
                ViewBag.ListaPosts = list3;
            }
            catch (Exception ex)
            {
                new Exception("ERROR EN METODO LISTAR" + ex.Message);
            }
            return View("Update", aux);
        }

        public ActionResult Insert()
        {
            DataAcces.DaoEmpresa de = new DataAcces.DaoEmpresa();
        
            try
            {
                int rut_empresa = Convert.ToInt32(Session["rutempresa"]);
                List<estado> list = de.ObtenerEstadoUsuario();
     
                ViewBag.EstadosTarea = list;

            }
            catch (Exception ex)
            {
                new Exception("ERROR EN METODO LISTAR" + ex.Message);
            }
            return View("Insert", new TAREA());
        }

        [HttpPost]
        public ActionResult Comentar(FormCollection fc)
        {
            TAREA dto = new TAREA();
            dto.IDTAREA = Convert.ToInt32(fc["IDTAREA"]);
            dto.RUT_USU = Convert.ToInt32(Session["rut"]);
            dto.RUT_EM = Convert.ToInt32(Session["rutempresa"]);
            dto.MENSAJE = Convert.ToString(fc["MENSAJE"]);
            DaoTarea dt = new DaoTarea();
            try
            {
                dt.InsertMessage(dto);
            }
            catch (Exception ex)
            {
                new Exception("ERROR EN COMENTAR" + ex.Message);
            }


            // return View("Insert", obj);
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }
    }
}