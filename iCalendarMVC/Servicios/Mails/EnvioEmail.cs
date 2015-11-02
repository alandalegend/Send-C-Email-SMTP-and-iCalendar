using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace iCalendarMVC.Servicios.Mails
{
    public class EnvioEmail
    {
        

        public Models.Resultado envioMail(Models.EnvioCorreo modelo)
        {
            Models.Resultado resultado = new Models.Resultado();
            try
            {
                Servicios.Mails.Configuracion configuracion = new Servicios.Mails.Configuracion(true);
                configuracion.Receptor = new System.Net.Mail.MailAddress(modelo.CorreoDestino, modelo.UsuarioDestino);
                configuracion.Mensaje = new MailMessage(configuracion.Emisor, configuracion.Receptor);

                configuracion.Mensaje.Subject = modelo.TituloMail;
                configuracion.Mensaje.Body = new Servicios.Mails.ascaron().tipoMail(modelo);
                configuracion.Mensaje.IsBodyHtml = true;

                var icalendar = new Servicios.iCal.iCalendarGeneracion(modelo.TituloMail, modelo.HoraYFechaCalendario);
                Attachment atachado = new Attachment(icalendar.iCalendar, icalendar.NombreCalendar);
                configuracion.Mensaje.Attachments.Add(atachado);

                configuracion.Cliente.Send(configuracion.Mensaje);
                resultado.Exitoso = true;
                resultado.Mensaje = String.Format("Se ha enviado un mensaje al correo {0}, por favor, valida tu correo", modelo.CorreoDestino);
            }
            catch (Exception error)
            {
                resultado.Mensaje = "Ha ocurrido un error: " + error.Message + Environment.NewLine + error.StackTrace;
                resultado.Exitoso = false;
            }
            return resultado;
        }

        


    }
}
