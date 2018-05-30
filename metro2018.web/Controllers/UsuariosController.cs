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

    public class UsuariosController : Controller
    {
        IUsuariosProcessor uP;

        public UsuariosController()
        {
            uP = new UsuariosProcessor(new UsuariosRepository());
        }

        // Get: Usuarios
        public ActionResult Index()
        {
            return RedirectToAction("Lista");
        }

        [HttpGet]
        public ActionResult NewUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewUsuario(Usuario usuario)
        {
            uP.Create(usuario);

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
            Usuario u = uP.ReadById(id).GetAwaiter().GetResult() ;
            return View(u);
        }

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            uP.Update(usuario);

            return RedirectToAction("lista");
        }

        public ActionResult Details(int id)
        {
            Usuario usr = uP.ReadById(id).GetAwaiter().GetResult();
            return View(usr);
        }

        public ActionResult Delete(int id)
        {
            uP.DeleteById(id);

            return RedirectToAction("lista");
        }

    }
}