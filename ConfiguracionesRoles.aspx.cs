using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class ConfiguracionesRoles : System.Web.UI.Page
{

    BDRoles roles = new BDRoles();
    List<string> listaRoles = new List<string>();
    

    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        

        if (!IsPostBack) {

            mvConfigRoles.SetActiveView(vRoles);

            ListarRoles();

            Session["listaRolSel"] = null;
        }

    }

    //Lista todos los roles
    public void ListarRoles() {
        

        gridRoles.DataSource = roles.ListarRoles();
        gridRoles.DataBind();

        gridRoles.HeaderRow.Cells[1].Text = "ID";
        gridRoles.HeaderRow.Cells[2].Text = "DESCRIPCION";
        gridRoles.HeaderRow.Cells[3].Text = "ACTIVO";

    
    }

    protected void AgregarRol(object sender, EventArgs e)
    {
        mvConfigRoles.SetActiveView(vAgregarRoles);


        List<string > sesion = (List<string>)Session["listaSession"];


        List<ClsAreaDeServicio> r = roles.listaAreasDelRol(sesion[0]);


        foreach (ClsAreaDeServicio a in r)
        {

            ListItem l = new ListItem(a.idAreaServicio, a.descripcionAS);

            ddlAS.Items.Add(l);

        }
    }
  
    protected void btnCancelarAgregarRol(object sender, EventArgs e)
    {
        mvConfigRoles.SetActiveView(vRoles);
    }
    
    protected void gridRoles_RowCommand(object sender, GridViewCommandEventArgs e)
    {

       // Response.Write("<script>alert('"+e.CommandName.ToString()+"')</script>");
       


    }
    
    protected void gridRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        

        gridRoles.SelectedRow.ForeColor = Color.FromName("#d95959");


        listaRoles.Add(gridRoles.SelectedRow.Cells[1].Text);

        Session["listaRolSel"] = listaRoles;
        
    }
    
    protected void gridRoles_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
         
    }

    protected void ConfigurarRol(object sender, EventArgs e)
    {
        listaRoles = (List<string>)Session["listaRolSel"];

        if (listaRoles != null)
        {

            mvConfigRoles.SetActiveView(vConfigurarRol);

            listaRoles = null;
            Session["listaRolSel"] = null;

        }
        else
        {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Selecciona un Rol para Configurarlo.', 'Configuracion de Roles');", true);

        }
    }

    protected void EliminarRol(object sender, EventArgs e)
    {
        listaRoles = (List<string>)Session["listaRolSel"];

        if (listaRoles != null)
        {

            //ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('¿Quieres Eliminar el Rol', 'Configuracion de Roles');", true);

            if (roles.EliminarRol(gridRoles.SelectedRow.Cells[1].Text) == 1)
            {

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Se Elimino el Rol con Exito', 'Configuracion de Roles');", true);
                ListarRoles();
                mvConfigRoles.SetActiveView(vRoles);
            }
            else {

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('El Rol no Existe', 'Configuracion de Roles');", true);
            
            }

            

            listaRoles = null;
            Session["listaRolSel"] = null;
            
        }
        else {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Selecciona un Rol para eliminarlo.', 'Configuracion de Roles');", true);
        
        }
    }

    protected void btnGuardarRol(object sender, EventArgs e)
    {
        int activo=0, apartadoArea=0, apartadoRecurso=0, confArea=0, ConfRecurso=0, confUsuarios=0, confRoles=0, reportes=0, estadisticas=0;

        if (txtNombreRol.Text != "")
        {

            if (cbxRolActivo.Checked)
            {

                activo = 1;

            }

            if (cbxApartadoAreas.Checked)
            {

                apartadoArea = 3;

            }

            if (cbxApartadoRecursos.Checked)
            {

                apartadoRecurso = 6;

            }

            if (cbxConfAreas.Checked)
            {

                confArea = 9;
            }

            if (cbxConfRecursos.Checked)
            {

                ConfRecurso = 10;

            }

            if (cbxConfUsuarios.Checked)
            {

                confUsuarios = 11;

            }

            if (cbxConfRoles.Checked)
            {

                confRoles = 12;

            }

            if (cbxConfReportes.Checked)
            {

                reportes = 13;

            }

            if (cbxConfEstadisticas.Checked)
            {

                estadisticas = 14;

            }

            

            if (roles.AgregarRol(txtNombreRol.Text, activo, apartadoArea, apartadoRecurso, confArea, ConfRecurso, confUsuarios, confRoles, reportes, estadisticas) == 1)
            {

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Rol Agregado Correctamente.', 'Configuracion de Roles');", true);
                ListarRoles();
                mvConfigRoles.SetActiveView(vRoles);
            }
            else {

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Este rol ya existe.', 'Configuracion de Roles');", true);
            
            }
        }
        else {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Inserta un nombre al rol.', 'Configuracion de Roles');", true);

        
        }
    }

    protected void btnGuardarConfiguracion(object sender, EventArgs e)
    {

    }
}