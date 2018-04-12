using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PerfilUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          
            Getperfilesusuarios();
            MultiView1.SetActiveView(view_tablaPerfiles);
        }
    }

    void Getperfilesusuarios()
    {
        BDMenu BDMENU = new BDMenu();
        DataTable tabla = BDMENU.GetPerfilesUsuarios();
        
        GridView1.DataSource = tabla;
        GridView1.DataBind();

        for (int c = 0; c <= GridView1.Rows.Count - 1; c++)
        {
            CheckBox chkbox1 = (CheckBox)GridView1.Rows[c].FindControl("chkactivo") as CheckBox;
            if (tabla.Rows[c].ItemArray[2].ToString() == "1" || tabla.Rows[c].ItemArray[2].ToString() == "True")
            {
                chkbox1.Checked = true;
            }
        }
    }
    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View_nuevoperfil);
    }
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (txtnombreperfil.Text != "")
        {
            BDMenu menu = new BDMenu();
            menu.RegistraPerfilUsuario(txtnombreperfil.Text);
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_info('Se registro el perfil correctamente.','Perfiles');", true);

            txtnombreperfil.Text = "";

            Getperfilesusuarios();
            MultiView1.SetActiveView(view_tablaPerfiles);
        }
    }
    protected void btncancelar_Click(object sender, EventArgs e)
    {
        txtnombreperfil.Text = "";
        Getperfilesusuarios();
        MultiView1.SetActiveView(view_tablaPerfiles);

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Getperfilesusuarios();
    }
    protected void btnregistrarcambios_Click(object sender, EventArgs e)
    {
        BDMenu menu = new BDMenu();
        for (int c = 0; c <= GridView1.Rows.Count - 1; c++)
        {
            CheckBox chkbox1 = (CheckBox)GridView1.Rows[c].FindControl("chkactivo") as CheckBox;

            menu.updateperfilusuario(int.Parse(GridView1.Rows[c].Cells[0].Text), chkbox1.Checked);

        }
    }
}