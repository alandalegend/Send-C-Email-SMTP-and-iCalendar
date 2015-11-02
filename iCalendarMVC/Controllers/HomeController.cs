using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCalendarMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var modelo = new Models.vmEnvioMail();

            return View(modelo);
        }

        public ActionResult partialEnvioMail(Models.vmEnvioMail modelo)
        {
            if (ModelState.IsValid)
            {
                modelo.Transaccion = new Servicios.Mails.EnvioEmail().envioMail(modelo.EnvioMail);
            }
            return PartialView("Partials/partialEnvioMail", modelo);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}