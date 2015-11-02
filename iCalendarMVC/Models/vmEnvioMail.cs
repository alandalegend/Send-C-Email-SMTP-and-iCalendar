using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCalendarMVC.Models
{
    public class vmEnvioMail
    {
        public vmEnvioMail()
        {
            this.EnvioMail = new EnvioCorreo();
        }
        public virtual Models.EnvioCorreo EnvioMail{ get; set; }
        public virtual Models.Resultado Transaccion { get; set; }
    }
}
