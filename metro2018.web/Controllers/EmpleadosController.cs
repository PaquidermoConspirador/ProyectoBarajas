using Metro2018.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro2018.Web.Controllers
{
    using Metro2018.BusinessLayer;
    using Metro2018.DataLayer;
    using Metro2018.Types;

    public class EmpleadosController : Controller
    {
        IEmpleadosProcessor eP;
        
        public EmpleadosController()
        {
            eP = new EmpleadosProcessor(new EmpleadosRepository());
            
        }

        // Get: Empleados
        [HttpGet]
        public ActionResult NewEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewEmpleado(Empleado empleado)
        {
            eP.Create(empleado);
            return RedirectToAction("Lista");
        }

        public ActionResult Index()
        {
            return RedirectToAction("Lista");
        }

        public ActionResult Lista()
        {
            var lista = eP.ReadAll();

            /*var a = lista.GetAwaiter();
            var b = a.GetResult();*/

            lista.Wait();
            var b = lista.Result;
            return View(b);
        }

        public ActionResult Id(int id)
        {
            Empleado empleado = eP.ReadById(id).GetAwaiter().GetResult();
            return View(empleado);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Empleado i = eP.ReadById(id).GetAwaiter().GetResult();
            return View(i);
        }

        [HttpPost]
        public ActionResult Edit(Empleado editado)
        {
            eP.Update(editado).GetAwaiter().GetResult();
            return RedirectToAction("Lista");
        }


        public ActionResult Delete(int id)
        {

            eP.DeleteById(id);

            return RedirectToAction("Lista");
        }

    }
}