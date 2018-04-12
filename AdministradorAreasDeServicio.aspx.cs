using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class AdministradorAreasDeServicio : System.Web.UI.Page
{
    List<string> listaSession;
    List<string> listaSel=new List<string>();
    BDUsuarios usuarios = new BDUsuarios();
    BDAreasDeServicios areas = new BDAreasDeServicios();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ListarAdministradores();
            mvAdministradoresAS.SetActiveView(vAdministradoresAS);
            Session["listaSel"] = null;

        }

        listaSession = (List<string>)Session["listaSession"];
    }

    protected void btnAgregarAdministrador_Click(object sender, EventArgs e)
    {

        txtUsuario.Text = "";
        ddlAdministradorNombre.Items.Clear();
        ddlAreaServicio.Items.Clear();
        
        mvAdministradoresAS.SetActiveView(vAgregarAdministradoresAS);
        

        List <ClsAreaDeServicio> ar= areas.ListaAS();

        if (ar.Count!=0)
        {
            foreach (ClsAreaDeServicio a in ar)
            {

                ListItem l = new ListItem(a.descripcionAS, a.idAreaServicio, true);

                ddlAreaServicio.Items.Add(l);

            }
        }
        else {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Para poder agregar un Administrador deve agregar Areas de Servicio.', 'Administrador de Areas de Servicio');", true);
            ListarAdministradores();
            mvAdministradoresAS.SetActiveView(vAdministradoresAS);
        }

    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        mvAdministradoresAS.SetActiveView(vAdministradoresAS);
    }

    protected void ListarAdministradores() {

        BDUsuarios bdUsuarios = new BDUsuarios();
        DataTable tabla = bdUsuarios.ListaAdministradores();

        gridAdministradorAS.DataSource = tabla;
        gridAdministradorAS.DataBind();
    
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (txtUsuario.Text != "")
        {
            ddlAdministradorNombre.Items.Clear();
            List<Usuario> u = usuarios.ListaUsuarios(txtUsuario.Text);

            foreach (Usuario usu in u)
            {

                ListItem l = new ListItem(usu.Nombre, usu.Emplid, true);

                ddlAdministradorNombre.Items.Add(l);

            }

        }
        else {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Escribe un nombre para buscarlo.', 'Administrador de Areas de Servicio');", true);
        
        }
    }

    protected void guardarAdministrador(object sender, EventArgs e)
    {
        if (usuarios.AgregarAdministradorAS(ddlAdministradorNombre.Text, ddlAreaServicio.Text) == 1)
        {


            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('El Administrador se ha registrado correctamente.', 'Administrador de Areas de Servicio');", true);
            ListarAdministradores();
            mvAdministradoresAS.SetActiveView(vAdministradoresAS);
        }
        else
        {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Error al registrar al Administrador.', 'Administrador de Areas de Servicio');", true);

        }
    }

    protected void EliminarAdmin(object sender, EventArgs e) {

        listaSel = (List<string>)Session["listaSel"];

        if (gridAdministradorAS.Rows.Count > 0)
        {
            if (listaSel != null)
            {
                string ar="";

                ar = gridAdministradorAS.SelectedRow.Cells[4].Text;

                if (usuarios.EliminarAdministrador(Int32.Parse(listaSel[0].ToString()), ar) == 1)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Administrador Eliminado.', 'Administradores de Area de Servicios');", true);
                }
                else {

                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('No se ha Podido Eliminar al Administrador.', 'Administradores de Area de Servicios');", true);
                
                }
            }
            else
            {

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Selecciona un Administrador de Area de Servicio.', 'Administradores de Area de Servicios');", true);

            }

            listaSel = null;
            Session["listaSel"] = null;
            ListarAdministradores();
            mvAdministradoresAS.SetActiveView(vAdministradoresAS);
        }
        else {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('No existe ningun Administrador de Area de Servicio.', 'Administradores de Area de Servicios');", true);

        }

    }

    protected void ActualizarAdmin(object sender, EventArgs e) {

        listaSel = (List<string>)Session["listaSel"];
        ddlAreasAdminAct.Items.Clear();

        if (gridAdministradorAS.Rows.Count > 0)
        {
            if (listaSel != null)
            {
                txtAdministradoAct.Text = usuarios.getNombreUsuarioID(listaSel[0]);

                if (usuarios.GetnivelAcceso(listaSel[0].ToString()) == 1)
                {

                    cbxAdminAct.Checked = true;

                }
                else { cbxAdminAct.Checked = false; }

                List<ClsAreaDeServicio> ar = areas.ListaAS();


                if (ar.Count != 0)
                {
                    foreach (ClsAreaDeServicio a in ar)
                    {

                        ListItem l = new ListItem(a.descripcionAS, a.idAreaServicio, true);

                        ddlAreasAdminAct.Items.Add(l);


                    }

                    foreach (ListItem l in ddlAreasAdminAct.Items)
                    {

                            if (l.Text == listaSel[1].ToString())
                            {
                                    l.Selected = true;
                            }
                      
                    }


                   

                }

                txtAdministradoAct.Attributes.Add("readonly", "readonly");
                mvAdministradoresAS.SetActiveView(vActualizarAdministrador);
            }
            else
            {

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Selecciona un Administrador de Area de Servicio.', 'Administradores de Area de Servicios');", true);

            }

            
        }
        else {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('No existe ningun Administrador de Area de Servicio.', 'Administradores de Area de Servicios');", true);
        }

    }

    protected void GuardarAdminAct(object sender, EventArgs e) {

        listaSel = (List<string>)Session["listaSel"];

        int acceso=0;

        if(cbxAdminAct.Checked==true){acceso=1;}else{acceso=0;}

        if (usuarios.ActualizarAdministrador(listaSel[0].ToString(), acceso, ddlAreasAdminAct.SelectedItem.Text, listaSel[1]) == 1)
        {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('El administrador ha sido Actualizado.', 'Administradores de Area de Servicios');", true);

            

        }
        else {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('No se ha Podido Actualizar el Administrador.', 'Administradores de Area de Servicios');", true);
        
        }

        listaSel = null;
        Session["listaSel"] = null;
        ListarAdministradores();
        mvAdministradoresAS.SetActiveView(vAdministradoresAS);
    
    }

    protected void CancelarAdminAct(object sender, EventArgs e) {

        
        listaSel = null;
        Session["listaSel"] = null;
        ListarAdministradores();
        mvAdministradoresAS.SetActiveView(vAdministradoresAS);
    
    }

    protected void gridAdministradorAS_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridAdministradorAS.SelectedRow.ForeColor = Color.FromName("#d95959");

        listaSel.Add(gridAdministradorAS.SelectedRow.Cells[1].Text);
        listaSel.Add(gridAdministradorAS.SelectedRow.Cells[4].Text);

       
        Session["listaSel"] = listaSel;
    }
    protected void gridAdministradorAS_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void gridAdministradorAS_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}