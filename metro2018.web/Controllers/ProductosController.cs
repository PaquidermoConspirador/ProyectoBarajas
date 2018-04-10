using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro2018.Web.Controllers
{
    using Types;

    public class ProductosController : Controller
    {
        // GET: Productos
        [HttpGet]
        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Producto producto)
        {
            //ProductosProcessor processor = new ProductosProcessor();
            //processor.NewProduct(producto);
            return View();
        }
    }
}