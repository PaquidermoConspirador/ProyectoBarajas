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

    public class InsumosController : Controller
    {
        IInsumosProcessor iP;

        public InsumosController()
        {
            iP = new InsumosProcessor(new InsumosRepository());
        }

        // Get: Insumos
        [HttpGet]
        public ActionResult NewInsumo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewInsumo(Insumo producto)
        {
            iP.Create(producto);

            return RedirectToAction("Lista");
        }

        public ActionResult Index()
        {   
            return RedirectToAction("Lista");
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
            Insumo insumo = iP.ReadById(id).GetAwaiter().GetResult();
            return View(insumo);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Insumo i = iP.ReadById(id).GetAwaiter().GetResult();
            return View(i);
        }

        [HttpPost]
        public ActionResult Edit(Insumo editado)
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