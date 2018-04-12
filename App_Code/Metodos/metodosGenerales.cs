using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Text;

/// <summary>
/// Descripción breve de metodosGenerales
/// </summary>
public class metodosGenerales 
{
	public metodosGenerales()
	{	
	}

    /// <summary>
    /// metodo para enviar correos
    /// </summary>
    /// <param name="para"></param>
    /// <param name="asunto"></param>
    /// <param name="mensaje"></param>
    /// <returns></returns>
    public string Enviar_Email(string para, string asunto, string mensaje)
    {
        try
        {
            MailMessage Mmsg;
            Mmsg = new MailMessage();
            Mmsg.To.Add(para);
            Mmsg.Subject = asunto;
            Mmsg.SubjectEncoding = Encoding.UTF8;




            Mmsg.Body = mensaje;
            Mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            Mmsg.IsBodyHtml = true;
            Mmsg.From = new MailAddress(ConfigurationManager.AppSettings["Nombre_Sistema_Correo"]);



            SmtpClient cliente = new SmtpClient();
            cliente.Host = ConfigurationManager.AppSettings["Servidor_Correo"];


            cliente.Send(Mmsg);

            return "";
        }
        catch (SmtpException ex)
        {
            return ex.Message;
        }

    }


    /// <summary>
    /// metodo para enviar correo electronico con el servidor institucional email-nai.itson.edu.mx
    /// </summary>
    /// <param name="para"></param>
    /// <param name="copia"></param>
    /// <param name="QuienEnvia"></param>
    /// <param name="CuerpoCorreo"></param>
    /// <param name="tituloCorreo"></param>
    /// <returns></returns>
    public bool SendMail(string para, string copia, string CorreoQuienEnvia, string NombreQuienEnvia, string CuerpoCorreo, string tituloCorreo)
    {
        bool correcto = false;
        try
        {
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress(CorreoQuienEnvia, NombreQuienEnvia);
            correo.To.Add(para);
            if (copia != "")
            {
                correo.CC.Add(copia);
            }

            correo.Subject = tituloCorreo;
            correo.Body = CuerpoCorreo;
            correo.IsBodyHtml = true;
            correo.Priority = System.Net.Mail.MailPriority.Normal;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["Servidor_Correo"];
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = true;

            smtp.Send(correo);
            correcto = true;
        }
        catch (Exception er)
        {
            correcto = false;
        }

        return correcto;
    }

   
}