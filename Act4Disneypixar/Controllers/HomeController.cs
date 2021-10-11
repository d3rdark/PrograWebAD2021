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
        
       

    }
}
