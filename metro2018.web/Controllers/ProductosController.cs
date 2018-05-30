using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metro2018.Web.Controllers
{
    using Metro2018.BusinessInterfaces;
    using Metro2018.BusinessLayer;
    using Metro2018.DataLayer;
    using System.Web.Mvc;
    using Types;

    public class ProductosController : Controller
    {
        IProductosProcessor uP;

        public ProductosController()
        {
            uP = new ProductosProcessor(new ProductosRepository());
        }

        // Get: Usuarios
        public ActionResult Index()
        {
            return RedirectToAction("Lista");
        }

        [HttpGet]
        public ActionResult NewProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProducto(Producto producto)
        {
            uP.Create(producto);

            return RedirectToAction("Lista");
        }

        public ActionResult Lista()
        {
            var lista = uP.ReadAll();

            lista.Wait();
            var b = lista.Result;
            return View(b);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Producto u = uP.ReadById(id).GetAwaiter().GetResult();
            return View(u);
        }

        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            uP.Update(producto);

            return RedirectToAction("lista");
        }

        public ActionResult Details(int id)
        {
            Producto usr = uP.ReadById(id).GetAwaiter().GetResult();
            return View(usr);
        }

        public ActionResult Delete(int id)
        {
            uP.DeleteById(id);

            return RedirectToAction("lista");
        }

    }
}