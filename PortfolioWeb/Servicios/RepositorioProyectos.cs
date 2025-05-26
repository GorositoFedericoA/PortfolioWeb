using PortfolioWeb.Models;

namespace PortfolioWeb.Servicios
{

    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyectos();
    }


    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto
                {
                ImgURL ="/assets/project-1.png",
                Titulo="Proyecto Ecommerce React",
                Descripcion="Proyecto hecho con React, js, html, css conectada con firebase para carrito de compras. Proximo a mejorar el frontend y agregar API .NET para back",
                Link="https://wonderful-stone-089b2841e.6.azurestaticapps.net"
                },

                new Proyecto
                {
                ImgURL ="/assets/project-2.png",
                Titulo="Proyecto Portfolio Web",
                Descripcion="Proyecto realizado con ASP .NET Core MVC, usando http post para el envío de mails e inyeccion de dependencias",
                Link="https://portfolioweb-fjbqehhsc9hwe5a2.brazilsouth-01.azurewebsites.net/"
                },
                new Proyecto
                {
                ImgURL ="/assets/project-3.png",
                Titulo="Proyecto Manejo de Presupuestos",
                Descripcion="Próximo proyecto a realizar, web de manejo de presupuestos!",
                Link="https://github.com/GorositoFedericoA"
                }
            };
        }
    }
}
