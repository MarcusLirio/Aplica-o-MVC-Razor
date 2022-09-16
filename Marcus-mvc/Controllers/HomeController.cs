using Marcus_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcus_mvc.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Veiculo()
        {
            ViewBag.Title = "Vende-se";
            ViewBag.Message = "Relação de carros";

            var lista = Veiculos.GetVeiculos();
            ViewBag.Lista = lista;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Titulo da página Contato";
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}