using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PermisosPerfilUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["_parametro"] != null)
        {

            string Parametro = Request.Params["_parametro"];

            if (Parametro != "")
            {
                string[] ParametroArray = Parametro.Split('_');

                if (ParametroArray[0] == "InsertUpdate" && ParametroArray[1] == "Y")
                {
                    registrarPermisos();
                }
                else if (ParametroArray[0] == "InsertUpdate" && ParametroArray[1] == "C")
                {
                    //limpiar();
                }
            }
        }



        if (!Page.IsPostBack)
        {
            Getperfilesusuarios();
        }
    }

    void Getperfilesusuarios()
    {
        BDMenu BDMENU = new BDMenu();


        DropPerfiles.DataSource = BDMENU.GetPerfilesUsuarios();
        DropPerfiles.DataTextField = "nombreRol";
        DropPerfiles.DataValueField = "idRol";
        DropPerfiles.DataBind();
    }

    void registrarPermisos()
    {
        BDMenu OBJMenu = new BDMenu();
        bool correcto = true;
        int item = 0;
        for (int c = 0; c <= GridView1.Rows.Count - 1; c++)
        {
            CheckBox chkbox1 = (CheckBox)GridView1.Rows[c].FindControl("chkpermiso") as CheckBox;
            item = int.Parse(GridView1.Rows[c].Cells[1].Text);
            correcto = OBJMenu.ActivaDesactivaPerimsosPerfiles(lblidrol.Text, item, chkbox1.Checked == true ? 1 : 0);
            if (correcto == false)
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Ocurrio un error al registrar los permisos.','Permisos');", true);
            }            
        }

        //actualizar los permisos a los usuarios que cuenten con el rol seleccionado

        //obtener a los usuarios
        DataTable tabla = OBJMenu.getUsuariosByperfil(lblidrol.Text);
        if (tabla != null && tabla.Rows.Count > 0)
        {
           
            for (int c = 0; c <= tabla.Rows.Count - 1; c++)
            {
                OBJMenu.eliminarpermisosyrol(tabla.Rows[c].ItemArray[1].ToString());
                OBJMenu.RegistraRolAlUsuario(tabla.Rows[c].ItemArray[1].ToString(), lblidrol.Text);
            }
        }
    }


    void RecolectarPermisos(string idrol)
    {
        BDMenu OBJMenu = new BDMenu();
        DataTable tabla = OBJMenu.GetlistadoDePermisosPerfiles(idrol);

        GridView1.DataSource = tabla;
        GridView1.DataBind();

        for (int c = 0; c <= GridView1.Rows.Count - 1; c++)
        {
            CheckBox chkbox1 = (CheckBox)GridView1.Rows[c].FindControl("chkpermiso") as CheckBox;
            if (tabla.Rows[c].ItemArray[3].ToString() == "1" || tabla.Rows[c].ItemArray[3].ToString() == "True")
            {
                chkbox1.Checked = true;
            }
        }
    }

    

    protected void btnbuscarEmpleado_Click(object sender, EventArgs e)
    {
        lblidrol.Text = DropPerfiles.SelectedItem.Value;
        lblNombre.Text = DropPerfiles.SelectedItem.Text;
        RecolectarPermisos(DropPerfiles.SelectedItem.Value);
        btncancelar.Visible = true;
        btnregistrar.Visible = true;
        tablaPermisos.Visible = true;
    }
    protected void btncancelar_Click(object sender, EventArgs e)
    {

    }
    protected void btnregistrar_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_YesNoCancel('Se ingresaran los permisos al Perfil indicado. ¿Deseas continuar?','Titulo de mensaje','InsertUpdate');", true);
    }
}