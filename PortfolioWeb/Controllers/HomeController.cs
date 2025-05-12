using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Models;
using PortfolioWeb.Servicios;


namespace PortfolioWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        // Campo privado de solo lectura que guarda la instancia de RepositorioProyectos.
        // Se inicializa a través del constructor y se usa dentro del controlador para acceder a los datos de los proyectos.
        private readonly IRepositorioProyectos _repositorioProyectos;
        private readonly IServicioEmail _servicioEmail;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos,IServicioEmail servicioEmail)//Le pasamos la instancia que viene desde Servicios
        {
            _logger = logger;
            this._repositorioProyectos = repositorioProyectos; //Guarda la instancia del repositorio en un campo privado para usarla en métodos como Index().
            this._servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {


            var repositorioProyectos = _repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modeloDeVista = new HomeIndexViewModel()
            {
                Proyectos = repositorioProyectos,

            };

            return View(modeloDeVista);
        }

        public IActionResult Proyectos()
        {
            var listadoProyectos = _repositorioProyectos.ObtenerProyectos();
            return View(listadoProyectos);
        }


        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Contacto(ContactoViewModel contactoViewModel) 
        {
            await _servicioEmail.EnviarEmail(contactoViewModel);
            return RedirectToAction("Contacto");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
