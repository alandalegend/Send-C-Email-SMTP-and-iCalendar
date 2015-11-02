using DDay.iCal;
using DDay.iCal.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCalendarMVC.Servicios.iCal
{
    public class iCalendarGeneracion
    {
        public String Titulo { get; set; }
        public String NombreCalendar { get; set; }
        public System.IO.MemoryStream iCalendar { get; set; }

        public iCalendarGeneracion(string Titulo, DateTime fechayHoraInicio)
        {
            String nombreCalendario = ConfigurationManager.AppSettings["nombreCalendario"];
            Int32 duracionEnMinutos = Convert.ToInt32(ConfigurationManager.AppSettings["duracionEnMinutos"]);
            String ubicacion = ConfigurationManager.AppSettings["ubicacion"];
            this.Titulo = Titulo;
            this.NombreCalendar = nombreCalendario;
            this.iCalendar = Generacion(Titulo, nombreCalendario, fechayHoraInicio, duracionEnMinutos, ubicacion);
        }

        private System.IO.MemoryStream Generacion(string Titulo, String nombreCalendario, DateTime fechayHoraInicio,Int32 duracionEnMinutos ,  string ubicacion)
        {
            DDay.iCal.iCalendar iCal = new DDay.iCal.iCalendar();
            // Create the event, and add it to the iCalendar
            Event evt = iCal.Create<Event>();
            // Set information about the event
            evt.Start = new iCalDateTime(fechayHoraInicio);
            evt.End = evt.Start.AddMinutes(duracionEnMinutos); // This also sets the duration
            evt.Description = String.Format("Agenda del día {0} a las {1}",
                fechayHoraInicio.ToString("dd 'de' MMM 'de' yyyy"),
                fechayHoraInicio.ToString("HH:MM")
                );
            evt.Location = ubicacion;
            evt.Summary = Titulo;
            ISerializationContext ctx = new SerializationContext();
            ISerializerFactory factory = new DDay.iCal.Serialization.iCalendar.SerializerFactory();
            // Get a serializer for our object
            IStringSerializer serializer = factory.Build(iCal.GetType(), ctx) as IStringSerializer;
            string output = serializer.SerializeToString(iCal);
            var bytes = Encoding.UTF8.GetBytes(output);
            //return File(bytes, contentType, DownloadFileName);
            System.IO.MemoryStream data = new System.IO.MemoryStream(bytes);
            return data;
        }
    }
}
