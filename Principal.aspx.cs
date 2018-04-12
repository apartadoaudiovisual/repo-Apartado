using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principal : System.Web.UI.Page
{
    List<string> listaSession;

    protected void Page_Load(object sender, EventArgs e)
    {

        listaSession=(List<string>)Session["listaSession"];

        string lista="<strong>ID</strong><p>"+listaSession[0].ToString()+"<p><hr/> <strong>Nivel de Acceso</strong><p>"+listaSession[1].ToString()+"</p><hr/>"+
                     "<strong>Nombre</strong><p>"+listaSession[2].ToString()+"</p><hr/> <strong>NIP</strong><p>"+listaSession[3].ToString()+"</p><hr/>"+
                     " <strong>Departamento</strong><p>" + listaSession[4].ToString() + "</p><hr/><strong>Campus</strong><p>" + listaSession[5].ToString() + "</p><hr/><strong>Perfil</strong><p>" + listaSession[6].ToString()
                     + "</p><hr/><strong>Da Clases</strong><p>" + listaSession[7].ToString();

        for (int x = 8; x < listaSession.Count; x++)
        {
            lista += "<hr/><strong>Rol</strong><p>"+listaSession[x].ToString()+"</p>";
        }

        Literal1.Text = lista;

    }
}