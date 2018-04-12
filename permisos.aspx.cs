using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class permisos : System.Web.UI.Page
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
                    limpiar();
                }
            }
        }

        if (!Page.IsPostBack)
        {
            llenaCombousuarios();
            //llenarPerfilesUsuario();
        }

    }

    void llenaCombousuarios()
    {
        BDUsuarios OBJUsuarios = new BDUsuarios();
        DropUsuarios.DataSource = OBJUsuarios.getUsuarios();

        DropUsuarios.DataTextField = "Nombre";
        DropUsuarios.DataValueField = "Emplid";
        DropUsuarios.DataBind();
    }

    void llenarPerfilesUsuario()
    {
        BDMenu menu = new BDMenu();

        DataTable tabla = menu.getPerfilesUsuarioasignados(lblemplid.Text);
        GridView2.DataSource = tabla;
        GridView2.DataBind();

        lblperfil.Text = "";

        for (int c = 0; c <= GridView2.Rows.Count - 1; c++)
        {            

            CheckBox chkbox1 = (CheckBox)GridView2.Rows[c].FindControl("chkactivo") as CheckBox;
            if (tabla.Rows[c].ItemArray[3].ToString() != "0" )
            {
                chkbox1.Checked = true;
                lblperfil.Text ="perfil "+ tabla.Rows[c].ItemArray[1].ToString();
            }
        }
    }

    void RecolectarPermisos(string emplid)
    {
        BDMenu OBJMenu = new BDMenu();
        DataTable tabla = OBJMenu.GetlistadoDePermisos(emplid);

        DataTable tablaperfil = OBJMenu.getPerfilesUsuarioasignados(emplid);
        for (int c = 0; c <= tablaperfil.Rows.Count - 1; c++)
        {
            if (tablaperfil.Rows[c].ItemArray[3].ToString() != "0")
            {
                lblperfil.Text = "perfil " + tablaperfil.Rows[c].ItemArray[1].ToString();
            }
        }


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

    void limpiar()
    {
        GridView1.DataSource = null;
        GridView1.DataBind();
        lblNombre.Text = "";
        lblemplid.Text = "";

        btncancelar.Visible = false;
        btnregistrar.Visible = false;
        tablaPermisos.Visible = false;

    }

    void registrarPermisos()
    {
        BDMenu OBJMenu = new BDMenu();
        bool correcto = true;
        int item = 0;

        bool encontroRol = false;
        int seleccionados = 0;
        for (int c = 0; c <= GridView2.Rows.Count - 1; c++)
        {
            CheckBox chkbox1 = (CheckBox)GridView2.Rows[c].FindControl("chkactivo") as CheckBox;
            if (chkbox1.Checked == true)
            {
                encontroRol = true;
                seleccionados = seleccionados + 1;
            }
        }

        if (encontroRol == false)
        {
            for (int c = 0; c <= GridView1.Rows.Count - 1; c++)
            {
                CheckBox chkbox1 = (CheckBox)GridView1.Rows[c].FindControl("chkpermiso") as CheckBox;
                item = int.Parse(GridView1.Rows[c].Cells[1].Text);
                correcto = OBJMenu.ActivaDesactivaPerimsos(lblemplid.Text, item, chkbox1.Checked == true ? 1 : 0);
                if (correcto == false)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Ocurrio un error al registrar los permisos.','Permisos');", true);
                }              
            }
        }
        else
        {
            if (seleccionados == 1)
            {
                //registrar el rol del usuario
                BDMenu menu = new BDMenu();
                menu.eliminarpermisosyrol(lblemplid.Text);


                //registrar permisos del rol
                for (int c = 0; c <= GridView2.Rows.Count - 1; c++)
                {
                    CheckBox chkbox1 = (CheckBox)GridView2.Rows[c].FindControl("chkactivo") as CheckBox;
                    if (chkbox1.Checked == true)
                    {
                        menu.RegistraRolAlUsuario(lblemplid.Text, GridView2.Rows[c].Cells[0].Text);
                    }
                }
            }
            else if (seleccionados > 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Solo se permite tener seleccionado un perfil de usuario.','Permisos');", true);
            }           
        }
    }



    protected void btnbuscarEmpleado_Click(object sender, EventArgs e)
    {

        lblemplid.Text = DropUsuarios.SelectedItem.Value;
        lblNombre.Text = DropUsuarios.SelectedItem.Text;
        RecolectarPermisos(DropUsuarios.SelectedItem.Value);
        btncancelar.Visible = false;
        btnregistrar.Visible = false;
        tablaPermisos.Visible = true;

        MultiView1.SetActiveView(View_permisosDeUsuario);
       
    }

    protected void btnregistrar_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_YesNoCancel('Se ingresaran los permisos al usuario indicado. ¿Deseas continuar?','Titulo de mensaje','InsertUpdate');", true);
    }
    protected void btncancelar_Click(object sender, EventArgs e)
    {
        limpiar();
    }

    protected void btnbuscaRol_Click(object sender, EventArgs e)
    {

        lblemplid.Text = DropUsuarios.SelectedItem.Value;
        lblNombre.Text = DropUsuarios.SelectedItem.Text;
        llenarPerfilesUsuario();
        btncancelar.Visible = true;
        btnregistrar.Visible = true;
        tablaPermisos.Visible = true;

        MultiView1.SetActiveView(View_PerfilDeUsuario);
    }
}