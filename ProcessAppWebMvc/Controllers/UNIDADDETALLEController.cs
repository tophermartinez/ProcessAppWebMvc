﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussines_Layer;
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
                UNIDAD_DETALLE dto = obj.Read().FirstOrDefault(a => a.id == id);
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
                DataAcces.DaoUnidad du = new DataAcces.DaoUnidad();
                DataAcces.DaoTarea dt = new DataAcces.DaoTarea();
                try
                {
                    int rut_empresa = Convert.ToInt32(Session["rutempresa"]);
                    List<UNIDAD> list = du.ListarUnidades(rut_empresa);
                    List<TAREA> list2= dt.ObtenerTareas(0, rut_empresa, 0);
                    List<estado> list3 = dt.ObtenerEstadoTarea();

                    ViewBag.ListaUnidades = list;
                    ViewBag.ListaTareas = list2;
                    ViewBag.ListaEstados = list3;
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
    }
}