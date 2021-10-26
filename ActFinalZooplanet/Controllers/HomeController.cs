using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActFinalZooplanet.Models;
using Microsoft.EntityFrameworkCore;


namespace ActFinalZooplanet.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {

            animalesContext context = new animalesContext();
            var clases = context.Clases.OrderBy(x => x.Nombre);
            return View(clases);
        }

        [Route("especies/{nombre}")]
        public IActionResult Especies(string nombre)
        {
            nombre = nombre.Replace("-", " ");
            animalesContext context = new animalesContext();
            var especies = context.Clases.Include(x => x.Especies).FirstOrDefault(x => x.Nombre == nombre);

            if (especies == null)
            {
                return RedirectToAction("Index");
            }
            return View(especies);
        }

        [Route("especie/{nombre}")]
        public IActionResult Especie(string nombre) {

            nombre = nombre.Replace("-", " ");
            animalesContext context = new animalesContext();
            var especie = context.Especies.Include(x => x.IdClaseNavigation).FirstOrDefault(x => x.Especie == nombre);
            if (especie == null)
            {
                return RedirectToAction("Especies");
            }
            return View(especie);
        }
    }
}
