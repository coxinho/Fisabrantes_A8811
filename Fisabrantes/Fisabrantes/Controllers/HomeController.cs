using Fisabrantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fisabrantes.Controllers
{
    public class HomeController : Controller
{
        // referencia a BD
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A fisioterapia atua em três bases principais:";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacto da clínica";

            return View();
        }


        public ActionResult ListaMedicos()
        {
            // pesquisar a lista de médicos que exixtem na BD
            var listaDeMedicos = db.Funcionarios
                                    .Where(f => f.CatProfissional.Contains("Médic"))
                                    .OrderBy(f => f.Nome)
                                    .ToList();

            return View(listaDeMedicos);
        }





    }
}
