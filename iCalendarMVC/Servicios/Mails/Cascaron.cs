using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCalendarMVC.Servicios.Mails
{
    public class ascaron
    {
        public String tipoMail(Models.EnvioCorreo modelo)
        {
            #region Contenido
            String resultado = String.Empty;
            resultado += Encabezado("", 0) +
                        "<tr>" +
  "					    	<td style=\"height: 40px; width: 800px; margin: 0 auto;\" valign=\"top\"></td>" +
  "					    </tr>" +
  "						<tr style=\"background-color:#f7f8f8;\">" +
  "					   		<td style=\"height: 20px; width:800px; margin 0 auto; text-align: center; color:#505050; font-weight: 400; font-size: 22px; font-family: 'Arial', sans-serif;\" valign=\"top\" border=\"0\">" +
  "					    	</td>" +
  "					    </tr>" +
  "						 <tr>" +
  "					    	<td align=\"center\" style=\"height: 40px; width:800px; margin 0 auto; text-align: center; color:#505050; font-weight: 400; font-size: 22px; font-family: 'Arial', sans-serif;\" valign=\"top\" border=\"0\">" +
  "                             <span style=\"color:#505050; font-weight: 400; font-size: 22px; font-family: 'Arial', sans-serif;\"> tu usario es " + modelo.UsuarioDestino + " ha elegido la fecha "+ modelo.HoraYFechaCalendario+ ".</span>" +
  "					    	</td>" +
  "					    </tr>" +
  
  PieDePagina(false);

            return resultado;
            #endregion
        }

        public String Encabezado(String urlImagen, Int32 heightBanner)
        {
            String resultado =
                "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">" +
                "<html>" +
                "   <head>" +
                "       <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">" +
                "       <title>Untitled Document</title>" +
                "   </head>" +
                "   <body style=\"padding:0; margin:0; outline:0;\">" +
                "       <table width=\"100%\" style=\"background-color:#f7f8f8; font-family:arial;\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">" +
                "           <tr>" +
                "               <td>" +
                "                   <table width=\"800\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"background-color:#f7f8f8;\">" +
              
                "                       <tr>" +
                "                           <td style=\"height: " + heightBanner + "px; width:800px; margin: 0 auto;\" border=\"0\" valign=\"top\">" +
                "                               <img src=\"" + urlImagen + "\" width=\"800\" height=\"" + heightBanner + "\" valign=\"top\" style=\"display:block; border:0px;\">" +
                "                           </td>" +
                "                       </tr>";
            return resultado;
        }

        public String PieDePagina(Boolean unicamenteAlertaInferior)
        {
            String resultado = @"                   </table>" +
                "               </td>" +
                "           </tr>";
            if (unicamenteAlertaInferior)
            {
                resultado += "           <tr>" +
                "               <td align=\"center\" style=\"color: #FFFFFF; font-weight: 100; font-size: 10px; font-family: 'Arial', sans-serif; width: 800px;\" bgcolor=\"#d91c5c\" height=\"30px;\">" +
                "                               <span style=\"color: #FFFFFF;font-size: 10px;font-family: 'Arial', sans-serif;\"> No respondas este correo electrónico, ya que no estamos controlando esta bandeja de entrada. Para comunicarte con nosotros contáctanos.</span>" +
                "                           </td>" +
                "           </tr>";
            }
            resultado += "      </table>" +
                "   </body>" +
                "</html>";
            return resultado;
        }
    }
}
