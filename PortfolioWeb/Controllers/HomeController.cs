using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Models;
using PortfolioWeb.Servicios;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;


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

        public IActionResult AcercaDeMi() 
        {
            return View();
        }


        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Contacto(ContactoViewModel contactoViewModel) 
        {

            if (!ModelState.IsValid) 
            {
                return View(contactoViewModel);
            }

            await _servicioEmail.EnviarEmail(contactoViewModel);

            TempData["Mensaje"] = "El mensaje fue enviado correctamente. Te responderé a la brevedad.";    
            return RedirectToAction("Contacto");
        }

        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
