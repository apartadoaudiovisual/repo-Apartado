using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Enviar_Email : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
       
        string correos = txtCorreo.Text.Trim();
        correos = correos.Replace(" ", ",");

        metodosGenerales ObjCorreo = new metodosGenerales();
     
        string mensaje = ObjCorreo.Enviar_Email(correos.ToString(), "Prueba", editor.Value);

        if (mensaje != "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Error al enviar el correo, favor de intentarlo de nuevo."+mensaje+"','Error');", true);
        }
        else
        {
            editor.Value = "";
        }
    }
}