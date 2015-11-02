using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace iCalendarMVC.Servicios.Mails
{
    public class Configuracion
    {
        //private Configuracion _configuracion;
        private Configuracion _Configuracion { get; set; }

        public Configuracion()
        {

        }
        public Configuracion(Boolean llenarSesion)
        {
            if (llenarSesion)
            {
                if (_Configuracion == null)
                {
                    _Configuracion = llenar();
                }
            }
        }
        public Configuracion llenar()
        {
            Configuracion resultado = new Configuracion();
            String username = String.Empty, password = String.Empty;
            username = ConfigurationManager.AppSettings["UsernameContacto"];
            password = ConfigurationManager.AppSettings["PasswordContacto"];

            String nombreAMostrarEnMail = ConfigurationManager.AppSettings["nombreAMostrarEnMail"];

            Int32 puerto = Convert.ToInt32(ConfigurationManager.AppSettings["Puerto"].ToString());
            Boolean EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            String direccionSMTP = ConfigurationManager.AppSettings["DireccionSMTP"];

            this.Emisor = new MailAddress(username, nombreAMostrarEnMail);
            this.Cliente = new SmtpClient(direccionSMTP, puerto);
            this.Cliente.EnableSsl = EnableSsl;
            this.Cliente.UseDefaultCredentials = false;
            this.Cliente.Credentials = new System.Net.NetworkCredential(username, password);
            this.Cliente.DeliveryMethod = SmtpDeliveryMethod.Network;

            return resultado;
        }

        public MailAddress Emisor { get; set; }
        public MailAddress Receptor { get; set; }
        public SmtpClient Cliente { get; set; }
        public MailMessage Mensaje { get; set; }
    }
}