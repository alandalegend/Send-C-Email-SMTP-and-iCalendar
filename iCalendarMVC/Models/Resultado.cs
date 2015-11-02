using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCalendarMVC.Models
{
    public class Resultado
    {
        public Boolean Exitoso { get; set; }
        public String Mensaje { get; set; }
    }

    public class EnvioCorreo
    {
        [Display(Name ="Correo destinatario"), Required(ErrorMessage ="Debes de ingresar un email"), DataType(DataType.EmailAddress, ErrorMessage = "Correo Inválido")]
        public String CorreoDestino { get; set; }

        [Display(Name = "Nombre del destinatario"), Required(ErrorMessage = "Debes de ingresar un nombre")]
        public String UsuarioDestino { get; set; }

        [Display(Name = "Titulo del Email"), Required(ErrorMessage = "Debes de ingresar un titulo")]
        public String TituloMail { get; set; }

        [Display(Name = "Fecha y Hora a Calendarizar"), Required(ErrorMessage = "Debes de ingresar una fecha")]
        public DateTime HoraYFechaCalendario { get; set; }
    }
}
