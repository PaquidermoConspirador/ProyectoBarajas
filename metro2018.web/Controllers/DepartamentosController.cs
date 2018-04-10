using System;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace Metro2018.Web.Controllers
{
    using BusinessInterfaces;
    using PagedList;

    public class DepartamentosController : Controller
    {
        private readonly IDepartamentosProcessor _departamentosProcessor;

        public DepartamentosController(IDepartamentosProcessor departamentosProcessor)
        {
            _departamentosProcessor = departamentosProcessor;
        }

        // GET: Departamentos
        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";

            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var departamentos = await _departamentosProcessor.ReadAll();
            
            if(!String.IsNullOrEmpty(searchString))
            {
                departamentos = departamentos.Where(d => d.Nombre.ToUpper().Contains(searchString.ToUpper()));
            }

            switch(sortOrder)
            {
                case "nombre_desc":
                    departamentos = departamentos.OrderByDescending(d => d.Nombre);
                    break;
                default:
                    departamentos = departamentos.OrderBy(d => d.Nombre);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(departamentos.ToPagedList(pageNumber, pageSize));
        }
    }
}