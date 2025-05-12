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
    }
}
