using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro2018.Web.Controllers
{
    using Metro2018.BusinessInterfaces;
    using Metro2018.BusinessLayer;
    using Metro2018.DataLayer;
    using Types;

    public class DepartamentosController : Controller
    {
        IDepartamentosProcessor iD;

        public DepartamentosController()
        {
            iD = new DepartamentosProcessor(new DepartamentosRepository());
        }

        // Get: Insumos
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Departamento departamento)
        {
            iD.Create(departamento);

            return RedirectToAction("Create");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            var lista = iD.ReadAll();

            /*var a = lista.GetAwaiter();
            var b = a.GetResult();*/

            lista.Wait();
            var b = lista.Result;
            return View(b);
        }

        public ActionResult Id(int id)
        {
            Departamento departamento = iD.ReadById(id).GetAwaiter().GetResult();
            return View(departamento);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Departamento i = iD.ReadById(id).GetAwaiter().GetResult();
            return View(i);
        }

        [HttpPost]
        public ActionResult Edit(Departamento editado)
        {
            iD.Update(editado).GetAwaiter().GetResult();
            return RedirectToAction("Lista");
        }


        public ActionResult Delete(int id)
        {

            iD.DeleteById(id);

            return RedirectToAction("Lista");
        }
    }
}