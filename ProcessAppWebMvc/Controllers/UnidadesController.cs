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
        public ActionResult Insert(FormCollection fc)
        {
            UNIDAD dto = new UNIDAD();
            dto.NOMBRE = fc["NOMBRE"];
            dto.DETALLE = fc["DETALLE"];  
            dto.RUT_USU = Convert.ToInt32(fc["RUT_USU"]);  
            dto.FechaEstimada = fc["FechaEstimada"];

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
                UNIDAD aux = obj.Read().FirstOrDefault(a => a.ID_UNIDAD == ID_UNIDAD);
                ViewBag.Usuario = aux.RUT_USU;
                DataAcces.DaoCliente dc = new DataAcces.DaoCliente();
                try
                {
                    int rut_empresa = Convert.ToInt32(Session["rutempresa"]);
                    List<USUARIO> list = dc.ObtenerListaUsuarios(0, rut_empresa, 1);

                    ViewBag.ListaUsuarios = list;
                }
                catch (Exception ex)
                {
                    new Exception("ERROR EN METODO LISTAR" + ex.Message);
                }
                return View("Update", aux);
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
                DataAcces.DaoCliente dc = new DataAcces.DaoCliente();
                try
                {
                    int rut_empresa = Convert.ToInt32(Session["rutempresa"]);
                    List<USUARIO> list = dc.ObtenerListaUsuarios(0, rut_empresa, 1);

                    ViewBag.ListaUsuarios = list;
                }
                catch (Exception ex)
                {
                    new Exception("ERROR EN METODO LISTAR" + ex.Message);
                }
                return View("Insert", new UNIDAD());
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
            
        }
        [HttpGet]
        public ActionResult Replicar(int ID_UNIDAD)
        {
            if (Session["Perfil"] != null)
            {
                NegocioUnidad obj = new NegocioUnidad();
                UNIDAD aux = obj.Read().FirstOrDefault(a => a.ID_UNIDAD == ID_UNIDAD);
                DataAcces.DaoUnidad du = new DataAcces.DaoUnidad();
                try
                {
                    du.Replicar(aux.ID_UNIDAD);
                }
                catch (Exception ex)
                {
                    new Exception("ERROR EN METODO LISTAR" + ex.Message);
                }
                return RedirectToAction("Read");
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
        }

    }

}