using System.ComponentModel.DataAnnotations;

namespace PortfolioWeb.Models
{
    public class ContactoViewModel
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El mail es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del email es incorrecto.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El mensaje es obligatorio.")]
        public string Mensaje { get; set; }
    }
}
