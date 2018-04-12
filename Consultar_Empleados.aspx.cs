using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

public partial class Consultar_Empleados : System.Web.UI.Page
{
    BDEmpleados ObjEmpleados = new BDEmpleados();
    List<ClsEmpleados> listEmpleados;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MvEmpleados.SetActiveView(viewEmpleados);
            
        }
        CargaGridEmpleados();
    }

     

    void CargaGridEmpleados()
    {
        GridEmpleados.DataSource = ObjEmpleados.ConsultarEmpleados();
        GridEmpleados.DataBind();
    }

    protected void GridEmpleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bool Registro_Eliminado = false;
        GridViewRow row = GridEmpleados.Rows[e.RowIndex];
        Registro_Eliminado = ObjEmpleados.Eliminar_Empleado(row.Cells[0].Text);

        if (Registro_Eliminado == true)
        {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_info('Se elimino correctamente el empleado seleccionado.','Eliminar');", true);
            CargaGridEmpleados();
            MvEmpleados.SetActiveView(viewEmpleados);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Mensaje de informacion.','Error');", true);
        }
    }
    protected void GridEmpleados_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        MvEmpleados.SetActiveView(viewEditarEmpleado);
        GridViewRow row = GridEmpleados.Rows[e.RowIndex];
       listEmpleados= ObjEmpleados.Consultar_Empleado_Emplid( row.Cells[0].Text);


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
        bool Registro_Insertado = false;
        MvEmpleados.SetActiveView(viewEmpleados);
        Registro_Insertado = ObjEmpleados.Insert_Update_Empleado(txtEmplid.Text, txtNombre.Text, RadioSex.SelectedValue.ToString(), txtTelefono.Text, DropCampus.SelectedValue.ToString(), Convert.ToDateTime(txtFechaalta.Text));

        if (Registro_Insertado == true)
        {            
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_info('Se guardo la información correctamente.','Guardar');", true);
            CargaGridEmpleados();
            MvEmpleados.SetActiveView(viewEmpleados);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Mensaje de informacion.','Error');", true);
        }
    }
    protected void btnexporToexcel_Click(object sender, EventArgs e)
    {       
        ((MasterPage)(this.Master)).ExportarExcel2(GridEmpleados);           
    }
    protected void btncorreo_Click(object sender, EventArgs e)
    {        
        metodosGenerales metodos = new metodosGenerales();
        bool correcto = metodos.SendMail("jose.arreola@itson.edu.mx", "", "cajeros@itson.edu.mx", "Nombre quien envia", "cuerpo del correo", "correo pruebas");
        
        if (correcto == true)
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_info('Mensaje de informacion.','Servicio de envio de correos');", true);
        }
    }
}
