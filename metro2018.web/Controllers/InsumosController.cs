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
        // Get: Insumos
        [HttpGet]
        public ActionResult NewInsumo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewInsumo(Insumo producto)
        {
            IInsumosProcessor iP = new InsumosProcessor(new InsumosRepository());

            iP.Create(producto);
            
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}