using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Models;

namespace PortfolioWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var proyectosIndex = ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectosIndex};
            return View(modelo);
        }

        private List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto
                {
                ImgURL ="/assets/project-1.png",
                Titulo="Proyecto",
                Descripcion="Proyecto realizado con .NET",
                Link="https://github.com/GorositoFedericoA"
                },
                
                new Proyecto 
                {
                ImgURL ="/assets/project-2.png",
                Titulo="Proyecto 2",
                Descripcion="Proyecto realizado con .NET",
                Link="https://github.com/GorositoFedericoA"
                },
                new Proyecto
                {
                ImgURL ="/assets/project-3.png",
                Titulo="Proyecto 3",
                Descripcion="Proyecto realizado con .NET",
                Link="https://github.com/GorositoFedericoA"
                }
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
