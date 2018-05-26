using Metro2018.BusinessInterfaces;
using Metro2018.BusinessLayer;
using Metro2018.DataLayer;
using Metro2018.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro2018.Web.Controllers
{
    public class ProveedoresController : Controller
    {
        IProveedoresProcessor iP;

        public ProveedoresController()
        {
            iP = new ProveedoresProcessor(new ProveedoresRepository());
        }

        // Get: Proveedores
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Proveedor proveedor)
        {
            iP.Create(proveedor);

            return RedirectToAction("Lista");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            var lista = iP.ReadAll();

            /*var a = lista.GetAwaiter();
            var b = a.GetResult();*/

            lista.Wait();
            var b = lista.Result;
            return View(b);
        }

        public ActionResult Id(int id)
        {
            Proveedor proveedor = iP.ReadById(id).GetAwaiter().GetResult();
            return View(proveedor);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Proveedor i = iP.ReadById(id).GetAwaiter().GetResult();
            return View(i);
        }

        [HttpPost]
        public ActionResult Edit(Proveedor editado)
        {
            iP.Update(editado).GetAwaiter().GetResult();
            return RedirectToAction("Lista");
        }


        public ActionResult Delete(int id)
        {

            iP.DeleteById(id);

            return RedirectToAction("Lista");
        }
    }
}