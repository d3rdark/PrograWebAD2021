using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Act2PresidenteMexico.Models;

namespace Act2PresidenteMexico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            presidentesContext context = new presidentesContext();
            IEnumerable<Presidente> presidentes = context.Presidentes.OrderByDescending(X => X.InicioGobierno);
            return View(presidentes);
        }

        public IActionResult Biografia()
        {
            return View();
        }
    }
}
