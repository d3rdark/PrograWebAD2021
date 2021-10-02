using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Act3MapCurricular.Models;

namespace Act3MapCurricular.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            mapa_curricularContext context = new mapa_curricularContext();
            var carreras = context.Carreras.OrderBy(x => x.Nombre);
            return View(carreras);
        }

        public IActionResult Info(string id)
        {
        
             id = id.Replace("-", " ");
            mapa_curricularContext context = new mapa_curricularContext();
            var carrera = context.Carreras.FirstOrDefault(x => x.Nombre == id);

            if (carrera == null)
            {
                return RedirectToAction("Index");
            }
            return View(carrera);
        }
    }
}
