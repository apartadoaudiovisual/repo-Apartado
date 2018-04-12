using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class usuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            llenagrid();
            MultiView1.SetActiveView(ViewUsuariosRegistrados);
        }

        if (Request.Params["_parametro"] != null)
        {

            string Parametro = Request.Params["_parametro"];

            if (Parametro != "")
            {
                string[] ParametroArray = Parametro.Split('_');

                if (ParametroArray[0] == "AddUser" && ParametroArray[1] == "Y")
                {
                    registrarUsuario();
                }
                else if (ParametroArray[0] == "AddUser" && ParametroArray[1] == "C")
                {
                    MultiView1.SetActiveView(ViewUsuariosRegistrados);
                }

                if (ParametroArray[0] == "DeleteUser" && ParametroArray[1] == "Y")
                {
                    borrarUsuario();
                }
                else if (ParametroArray[0] == "DeleteUser" && ParametroArray[1] == "N")
                {
                    lblUsuarioeliminar.Text = "";
                }
                else if (ParametroArray[0] == "DeleteUser" && ParametroArray[1] == "C")
                {
                    lblUsuarioeliminar.Text = "";
                    MultiView1.SetActiveView(ViewUsuariosRegistrados);
                }
            }
        }


    }

    void registrarUsuario()
    {
        BDUsuarios OBJUsuarios = new BDUsuarios();
        bool correcto = OBJUsuarios.RegistrarUsuario(DropEmpleados.SelectedItem.Value);

        if (correcto == true)
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_info('Se registro correctamente el usuario, puede continuar asignandole los permisos de acceso','Titulo de mensaje','AddUser');", true);        
        }

    }

    void borrarUsuario()
    {
        BDUsuarios OBJUsuarios = new BDUsuarios();
        bool correcto = OBJUsuarios.EliminarUsuarioByEmplid(lblUsuarioeliminar.Text);

        lblUsuarioeliminar.Text = "";

        if (correcto == true)
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_info('Se elimino correctamente el usuario','Usuarios','');", true);        
        }
        llenagrid();
    }

    void llenagrid()
    {
        BDUsuarios OBJUsuarios = new BDUsuarios();
        GridUsuarios.DataSource = OBJUsuarios.getUsuarios();
        GridUsuarios.DataBind();
    }
    void Carga_Empleados()
    {
        BDEmpleados ObjEmpleados = new BDEmpleados();
        DropEmpleados.DataSource = ObjEmpleados.ConsultarEmpleadosActivos();

        DropEmpleados.DataTextField = "Name";
        DropEmpleados.DataValueField = "Emplid";
        DropEmpleados.DataBind();
    }
  
    protected void btnexporToexcel_Click(object sender, EventArgs e)
    {       
        ((MasterPage)(this.Master)).ExportarExcel2(GridUsuarios);
    }
    protected void GridUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = GridUsuarios.Rows[index];
        lblUsuarioeliminar.Text = row.Cells[0].Text;
        if (e.CommandName == "borrar")
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_YesNoCancel('Se eliminara el usuario "+row.Cells[1].Text + " de la lista de usuarios del sistema. ¿Deseas continuar?','Usuarios','DeleteUser');", true);        
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(ViewAgregarUsuario);
        Carga_Empleados();
    }
    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_YesNoCancel('Se agregara al empleado " + DropEmpleados.SelectedItem.Text + " como usuario del sistema. ¿Deseas continuar?','Usuarios','AddUser');", true);        
    }
    protected void GridUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}