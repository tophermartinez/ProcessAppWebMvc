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

        public ActionResult Index()
        {

            
            //using (NegocioEmpresa DB = new NegocioEmpresa())
            //{
            //    public ActionResult ListNameEmp()
            //    {
            //        NegocioEmpresa emp = new NegocioEmpresa();
            //        return View(emp.ListNameEmp());
            //    }
            //}

            return View();
        }


        [HttpPost]
        public ActionResult Insert(EMPRESA dto)
        {
            if (Session["Perfil"] != null)
            {
                NegocioEmpresa emp = new NegocioEmpresa();
                emp.Insert(dto);
                return RedirectToAction("Read");
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
        }
        [HttpPost]
        public ActionResult Update(EMPRESA dto)
        {
            if (Session["Perfil"] != null)
            {
                NegocioEmpresa emp = new NegocioEmpresa();
                emp.Update(dto);
                return RedirectToAction("Read");
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
           
        }

        public ActionResult Delete(string id)
        {
            if (Session["Perfil"] != null)
            {
                NegocioEmpresa emp = new NegocioEmpresa();
                emp.Delete(id);
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
                NegocioEmpresa emp = new NegocioEmpresa();
                return View(emp.Read());
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
          
        }
        [HttpGet]
        public ActionResult Update(string ID)
        {
            if (Session["Perfil"] != null)
            {
                NegocioEmpresa emp = new NegocioEmpresa();
                EMPRESA aux = emp.Read().FirstOrDefault(a => a.ID == int.Parse(ID));
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
                return View("Insert", new EMPRESA());
            }
            else
            {
                return View("../Mantenedor/LoginProcess");
            }
         
        }


     
      
     
    }
}