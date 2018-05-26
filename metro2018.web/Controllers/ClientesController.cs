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
    public class ClientesController : Controller
    {
        IClientesProcessor iP;

        public ClientesController()
        {
            iP = new ClienteProcessor(new ClientesRepository());
        }

        // Get: Clientes
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            iP.Create(cliente);

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
            Cliente cliente = iP.ReadById(id).GetAwaiter().GetResult();
            return View(cliente);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Cliente i = iP.ReadById(id).GetAwaiter().GetResult();
            return View(i);
        }

        [HttpPost]
        public ActionResult Edit(Cliente editado)
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