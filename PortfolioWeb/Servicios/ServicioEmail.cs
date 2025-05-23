using PortfolioWeb.Models;
using System.Net.Mail;
using System.Net;
using static PortfolioWeb.Servicios.ServicioEmail;

namespace PortfolioWeb.Servicios
{
    public interface IServicioEmail
    {
        Task EnviarEmail(ContactoViewModel contacto);
    }

    public class ServicioEmail(IConfiguration configuration) : IServicioEmail
    {


        public async Task EnviarEmail(ContactoViewModel contacto)
        {
            try
            {
                var emailEmisor = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
                var password = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
                var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
                var puerto = configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

                var smtpCliente = new SmtpClient(host, puerto);
                smtpCliente.EnableSsl = true;
                smtpCliente.UseDefaultCredentials = false;


                smtpCliente.Credentials = new NetworkCredential(emailEmisor, password);
                var mensaje = new MailMessage(emailEmisor, emailEmisor, $"Nombre: {contacto.Nombre} Email:{contacto.Email}", contacto.Mensaje);


                await smtpCliente.SendMailAsync(mensaje);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }




}

