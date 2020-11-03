using Bussines_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAcces;

namespace ProcessAppWebMvc.Controllers
{
    public class MantenedorController : Controller
    {
        [HttpPost]
        public ActionResult Insert(USUARIO dto)
        {
            NegocioCliente neg = new NegocioCliente();
            neg.Insert(dto);
            return RedirectToAction("Read");
        }

        [HttpPost]
        public ActionResult Update(USUARIO dto)
        {
            NegocioCliente neg = new NegocioCliente();
            neg.Update(dto);
            return RedirectToAction("Read"); ;


        }

        public ActionResult Delete(int ID)
        {
            NegocioCliente neg = new NegocioCliente();
            neg.Delete(ID);
            return RedirectToAction("Read"); ;
        }

        public ActionResult Read()
        {
            NegocioCliente neg = new NegocioCliente();
            return View(neg.Read());
        }


        [HttpGet]
        public ActionResult Update(int ID)
        {
            NegocioCliente neg = new NegocioCliente();
            USUARIO usu = neg.Read().FirstOrDefault(a => a.ID == ID);
            return View("Update", usu);

        }

        public ActionResult Insert()
        {
            return View("Insert", new USUARIO());
        }




        public ActionResult Login()
        {
            
            
            return View("LoginProcess");// deberia redirigir a una mantenedor

        }

        [HttpPost]
        public ActionResult LoginPost(FormCollection fc)
        {
            string nombre = fc["usu"];

            string pass =   fc["pass"];

            //string Rol = fc["Rol"];

            DaoCliente dao = new DaoCliente();
           string result = dao.Login(nombre, pass);

            if (result.Equals("Administrador"))
            {
                return RedirectToAction("Read");
            }
            else if (result.Equals("Funcionario"))
            {

                return RedirectToAction("Tareas");
            }
            else if (result.Equals("Diseñador"))
            {
                return RedirectToAction("Flujos");
            }
            else
            {

                return View("LoginProcess");// deberia redirigir a una mantenedor
            }

        }



        // GET: Mantenedor
        //public ActionResult Usuarios()
        //{
        //    return View();
        //}

        //public ActionResult Roles()
        //{
        //    return View();
        //}

        public ActionResult Tareas()
        {
            return View();
        }

        //public ActionResult TareasSubordinadas()
        //{
        //    return View();
        //}

        //public ActionResult AsignarTareas()
        //{
        //    return View();
        //}

        public ActionResult Flujos()
        {
            return View();
        }

        //public ActionResult Conexion()
        //{
        //    return View();
        //}

        //// GET: Mantenedor/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Mantenedor/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Mantenedor/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Mantenedor/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Mantenedor/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Mantenedor/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Mantenedor/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


    }
}
