using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Act4Disneypixar.Models;
using Microsoft.EntityFrameworkCore;

namespace Act4Disneypixar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("peliculas")]
        public IActionResult Peliculas()
        {
            pixarContext context = new pixarContext();
            var peliculas = context.Peliculas.OrderBy(x => x.Nombre);
            return View(peliculas);
        }

        [Route("pelicula/{nombre}")]
        public IActionResult InformacionPelicual(string nombre)
        {
            string nombre2 = nombre == null ? "" : nombre.Replace("-"," ");
            pixarContext context = new pixarContext();
            var pelicula = context.Peliculas.Include(x => x.Apariciones).ThenInclude(x => x.IdPersonajeNavigation)
                .FirstOrDefault(x => x.Nombre == nombre2 || x.Nombre == nombre);
            if (pelicula == null)
            {
                return RedirectToAction("peliculas");
            }
            return View(pelicula);
        }
        [Route("cortos", Name ="cortos")]
        public IActionResult Cortos()
        {
            pixarContext context = new pixarContext();
            var cortos = context.Categoria.Include(x => x.Cortometrajes).OrderBy(x => x.Nombre);
            return View(cortos);
        }

        [Route("corto/{nombre}")]
        public IActionResult InfoCortos(string nombre)
        {
            string nombre2 = nombre == null ? "" : nombre.Replace("-", " ");
            string nom = nombre2 == "Jack Jack ataca" ?  nombre2 = "Jack-Jack ataca" : "";

            pixarContext context = new pixarContext();

            /*var infocortos = context.Cortometrajes.Include(x => x.IdCategoriaNavigation)
                .FirstOrDefault(x => x.Nombre == nombre2 || x.Nombre == nombre || x.Nombre == nom);*/
            var infocortos = context.Cortometrajes.FirstOrDefault(x => x.Nombre == nombre2 || x.Nombre == nombre || x.Nombre == nom);
            if (infocortos == null)
            {
                return RedirectToRoute("cortos");
            }
            return View(infocortos);
        }
    }
}
