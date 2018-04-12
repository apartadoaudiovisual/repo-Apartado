using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class RealizarApartadoArea : System.Web.UI.Page
{
    List<string> listaSession;
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            mvApartadosAreas.SetActiveView(vApartadosAreas);

            
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("ID", typeof(int)),  
                            new DataColumn("Area", typeof(string)),  
                            new DataColumn("AREA DE SERVICIO",typeof(string)),
                            new DataColumn("FECHA DE APARTADO",typeof(string)),
                            new DataColumn("HORA INICIAL", typeof(string)),
                            new DataColumn("HORA FINAL", typeof(string)),
                            new DataColumn("ESTATUS", typeof(string))});

            dt.Rows.Add(1, "AV212", "AUDIOVISUALES", "23/05/2018", "10:00 am", "11:00 am", "PENDIENTE");
            dt.Rows.Add(1, "LV1012", "CISCO", "30/05/2018", "8:00 am", "10:00 am", "PENDIENTE");
            dt.Rows.Add(1, "LV1215", "INDUSTRIAL", "20/04/2018", "7:00 pm", "8:00 pm", "PENDIENTE");
            dt.Rows.Add(1, "LV212", "AUDIOVISUALES", "23/05/2018", "10:00 am", "11:00 am", "PENDIENTE");

            gridApartadosAreas.DataSource = dt;
            gridApartadosAreas.DataBind();

            

        }

        listaSession = (List<string>)Session["listaSession"];
    }

    protected void btnAgregarApartado_Click(object sender, EventArgs e)
    {

    }

    protected void gridApartadosAreas_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        
    }
   
    protected void gridApartadosAreas_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }
   
}