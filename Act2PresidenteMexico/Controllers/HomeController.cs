using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Act2PresidenteMexico.Models;
using Microsoft.EntityFrameworkCore;


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

        public IActionResult Biografia(int id)
        {
            presidentesContext context = new presidentesContext();
            var presidente = context.Presidentes
                .Include(x => x.IdEstadoRepublicaNavigation)
                .Include(x => x.IdPartidoPoliticoNavigation)
                .FirstOrDefault(x => x.Id == id);

            if (presidente == null)
            {
                return RedirectToAction("Index");
            }
            return View(presidente);    
        }
    }
}
