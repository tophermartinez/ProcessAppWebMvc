using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussines_Layer;
using DataAcces;
using Entity_Layer;

namespace ProcessAppWebMvc.Controllers
{
    public class UNIDADDETALLEController : Controller
    {
        // GET: UNIDADDETALLE
        [HttpPost]
        public ActionResult Insert(FormCollection fc)
        {
            UNIDAD_DETALLE dto = new UNIDAD_DETALLE();
            dto.ID_UNIDAD = Convert.ToInt32(fc["ID_UNIDAD"]);
            dto.ID_TAREA = Convert.ToInt32(fc["ID_TAREA"]);
            dto.ESTADO = Convert.ToInt32(fc["ESTADO"]);
            dto.FECHA_ESTIMADA = fc["FECHA_ESTIMADA"];
            dto.Rut_Usu = Convert.ToInt32(fc["Rut_Usu"]);
            if (Session["Perfil"] != null)
            {
                NegocioUNIDADDET obj = new NegocioUNIDADDET();
                obj.Insert(dto);
                return RedirectToAction("Read");
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
        }
        [HttpPost]
        public ActionResult Update(UNIDAD_DETALLE dto)
        {
            if (Session["Perfil"] != null)
            {
                NegocioUNIDADDET obj = new NegocioUNIDADDET();
                obj.Update(dto);
                return RedirectToAction("Read");
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
            
        }

        [HttpPost]
        public ActionResult Update2(FormCollection fc)
        {
            if (Session["Perfil"] != null)
            {
                UNIDAD_DETALLE dto = new UNIDAD_DETALLE();
                dto.id = Convert.ToInt32(fc["id"]);
                dto.ID_UNIDAD = Convert.ToInt32(fc["ID_UNIDAD"]);
                dto.ID_TAREA = Convert.ToInt32(fc["ID_TAREA"]);
                dto.ESTADO = Convert.ToInt32(fc["ESTADO"]);
                dto.Rut_Usu = Convert.ToInt32(fc["Rut_Usu"]);
                dto.FECHA_ESTIMADA = Convert.ToString(fc["FECHA_ESTIMADA"]);
             
                NegocioUNIDADDET obj = new NegocioUNIDADDET();
                obj.Update(dto);
       
                return RedirectToAction("Read2", "UNIDADDETALLE"  , new { ID_UNIDAD = dto.ID_UNIDAD });
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }

        }
        public ActionResult Delete(string ID)
        {
            if (Session["Perfil"] != null)
            {
                NegocioUNIDADDET obj = new NegocioUNIDADDET();
                obj.Delete(ID);
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
                NegocioUNIDADDET obj = new NegocioUNIDADDET();
                return View(obj.Read());
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
          
        }
        public ActionResult Update(int id)
        {
            if (Session["Perfil"] != null)
            {
                NegocioUNIDADDET obj = new NegocioUNIDADDET();
                UNIDAD_DETALLE aux = obj.Read().FirstOrDefault(a => a.id == id);
                ViewBag.Unidad = aux.ID_UNIDAD;
                ViewBag.Tarea = aux.ID_TAREA;
                ViewBag.Estado = aux.ESTADO;
                ViewBag.Usuario = aux.Rut_Usu;
                DataAcces.DaoUnidad du = new DataAcces.DaoUnidad();
                DataAcces.DaoTarea dt = new DataAcces.DaoTarea();
                DataAcces.DaoCliente dc = new DataAcces.DaoCliente();
                try
                {
                    int rut_empresa = Convert.ToInt32(Session["rutempresa"]);
                    List<UNIDAD> list = du.ListarUnidades(rut_empresa);
                    List<TAREA> list2 = dt.ObtenerTareas(0, rut_empresa, 0);
                    List<estado> list3 = dt.ObtenerEstadoTarea();
                    List<USUARIO> list4 = dc.ObtenerListaUsuarios(0, rut_empresa, 1);
                    List<TAREA> list5 = dt.ObtenerPosts(aux.ID_TAREA);
                  
                    ViewBag.ListaUnidades = list;
                    ViewBag.ListaTareas = list2;
                    ViewBag.ListaEstados = list3;
                    ViewBag.ListaUsuarios = list4;
                    ViewBag.ListaPosts = list5;
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

        public ActionResult Update2(int id)
        {
            if (Session["Perfil"] != null)
            {
                NegocioUNIDADDET obj = new NegocioUNIDADDET();
                UNIDAD_DETALLE aux = obj.Read().FirstOrDefault(a => a.id == id);
                ViewBag.Unidad = aux.ID_UNIDAD;
                ViewBag.Tarea = aux.ID_TAREA;
                ViewBag.Estado = aux.ESTADO;
                ViewBag.Usuario = aux.Rut_Usu;
                DataAcces.DaoUnidad du = new DataAcces.DaoUnidad();
                DataAcces.DaoTarea dt = new DataAcces.DaoTarea();
                DataAcces.DaoCliente dc = new DataAcces.DaoCliente();
                try
                {
                    int rut_empresa = Convert.ToInt32(Session["rutempresa"]);
                    List<UNIDAD> list = du.ListarUnidades(rut_empresa);
                    List<TAREA> list2 = dt.ObtenerTareas(0, rut_empresa, 0);
                    List<estado> list3 = dt.ObtenerEstadoTarea();
                    List<USUARIO> list4 = dc.ObtenerListaUsuarios(0, rut_empresa, 1);
                    List<TAREA> list5 = dt.ObtenerPosts(aux.ID_TAREA);

                    ViewBag.ListaUnidades = list;
                    ViewBag.ListaTareas = list2;
                    ViewBag.ListaEstados = list3;
                    ViewBag.ListaUsuarios = list4;
                    ViewBag.ListaPosts = list5;
                }
                catch (Exception ex)
                {
                    new Exception("ERROR EN METODO LISTAR" + ex.Message);
                }
                return View("Update2", aux);
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
                DataAcces.DaoUnidad du = new DataAcces.DaoUnidad();
                DataAcces.DaoTarea dt = new DataAcces.DaoTarea();
                DataAcces.DaoCliente dc = new DataAcces.DaoCliente();
                try
                {
                    int rut_empresa = Convert.ToInt32(Session["rutempresa"]);
                    List<UNIDAD> list = du.ListarUnidades(rut_empresa);
                    List<TAREA> list2= dt.ObtenerTareas(0, rut_empresa, 0);
                    List<estado> list3 = dt.ObtenerEstadoTarea();
                    List<USUARIO> list4 = dc.ObtenerListaUsuarios(0, rut_empresa, 1);
                    ViewBag.ListaUnidades = list;
                    ViewBag.ListaTareas = list2;
                    ViewBag.ListaEstados = list3;
                    ViewBag.ListaUsuarios = list4;
                }
                catch (Exception ex)
                {
                    new Exception("ERROR EN METODO LISTAR" + ex.Message);
                }
                return View("Insert", new UNIDAD_DETALLE());
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
           
        }

        [HttpPost]
        public ActionResult Comentar(FormCollection fc)
        {
            TAREA dto = new TAREA();
            dto.IDTAREA = Convert.ToInt32(fc["ID_TAREA"]);
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

        public ActionResult Read2(int id_unidad)
        {
            if (Session["Perfil"] != null)
            {
                NegocioUNIDADDET obj = new NegocioUNIDADDET();
                return View(obj.Read2(id_unidad));
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }

        }
    }
}