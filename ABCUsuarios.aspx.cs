using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABCUsuarios : System.Web.UI.Page
{
    BDEmpleados ObjEmpleados = new BDEmpleados();
    List<ClsEmpleados> listEmpleados;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MultiView1.SetActiveView(Viewbusqueda);
            Carga_Empleados();
        }


    }

    void Carga_Empleados()
    {
        DropEmpleados.DataSource = ObjEmpleados.ConsultarEmpleados_Combo();

        DropEmpleados.DataTextField = "Name";
        DropEmpleados.DataValueField = "Emplid";
        DropEmpleados.DataBind();
    }
    protected void DropEmpleados_SelectedIndexChanged(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(ViewUsuarios);
        Carga_Datos_Empleado(DropEmpleados.SelectedValue.ToString());
    }


    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(ViewUsuarios);
    }

    void Carga_Datos_Empleado(string Emplid)
    {
        listEmpleados = ObjEmpleados.Consultar_Empleado_Emplid(Emplid);

        foreach (ClsEmpleados Obj in listEmpleados)
        {
            txtEmplid.Text = Obj.Emplid.ToString();
            txtNombre.Text = Obj.Name.ToString();
            txtTelefono.Text = Obj.Phone.ToString();
            txtFechaalta.Text = Obj.Fecha_alta.ToString();
            
            DropCampus.SelectedValue = Obj.Campus_id.ToString();
            RadioSex.SelectedValue = Obj.Sex.ToString();
            txtEmplid.Enabled = false;
           
        }
    }


    protected void BtnGuardar_Click(object sender, EventArgs e)
    {

        try
        {


            bool correcto = ObjEmpleados.Insert_Update_Empleado(txtEmplid.Text, txtNombre.Text, RadioSex.SelectedValue.ToString(), txtTelefono.Text, DropCampus.SelectedValue.ToString(), Convert.ToDateTime(txtFechaalta.Text));
            if (correcto == true)
            {
                
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_info('Se guardo la información correctamente.','Guardar');", true);
                MultiView1.SetActiveView(Viewbusqueda);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Mensaje de informacion.','Error');", true);

            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "Guardar('" + ex.Message + "', 'Error');", true);
            
            
        }
    }
       


  

}