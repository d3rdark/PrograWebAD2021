using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Act5SweetBakery.Models;
using Act5SweetBakery.Models.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace Act5SweetBakery.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [Route("productos")]
        public IActionResult Productos()
        {
            sweetbakeryContext context = new sweetbakeryContext();
            var productos = context.Categorias.Include(x => x.Productos).OrderBy(x => x.Nombre);
            return View(productos);
        }

        [Route("recetas")]
        public IActionResult Recetas()
        {
            sweetbakeryContext context = new sweetbakeryContext();
            var recetas = context.Categorias.Include(x => x.Receta).Where(x => x.Receta.Any()).OrderBy(c => c.Nombre);
            return View(recetas);
        }

        [Route("Receta/{nombre}")]
        public IActionResult Receta(string nombre)
        {
            nombre = nombre.Replace("-", " ");
            sweetbakeryContext context = new sweetbakeryContext();
            var r = context.Recetas.FirstOrDefault(x => x.Nombre == nombre);
            if (r == null)
            {
                return RedirectToAction("Recetas");
            }
            else
            {
                RecetaViewModel vm = new RecetaViewModel();
                vm.Receta = r;

                Random rnd = new Random();

                vm.TresRecetas = context.Recetas
                    .Where(x => x.Id != r.Id).ToList()
                    .OrderBy(x => rnd.Next())
                    .Take(3).Select(x => new Receta { Id = x.Id, Nombre = x.Nombre });
                return View(vm);
            }

        }
    }
}
