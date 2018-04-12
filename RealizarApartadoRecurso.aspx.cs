using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class RealizarApartadoRecurso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {

            mvApartadoRecursos.SetActiveView(vApartadosRecursos);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("ID", typeof(int)),  
                            new DataColumn("Recurso", typeof(string)),  
                            new DataColumn("Area", typeof(string)),
                            new DataColumn("AREA DE SERVICIO",typeof(string)),
                            new DataColumn("FECHA DE APARTADO",typeof(string)),
                            new DataColumn("HORA INICIAL", typeof(string)),
                            new DataColumn("HORA FINAL", typeof(string)),
                            new DataColumn("ESTATUS", typeof(string))});

            dt.Rows.Add(1, "Bocinas", "AV212", "AUDIOVISUALES", "23/05/2018", "10:00 am", "11:00 am", "PENDIENTE");
            dt.Rows.Add(1, "Microfono", "LV1012", "CISCO", "30/05/2018", "8:00 am", "10:00 am", "PENDIENTE");
            dt.Rows.Add(1, "VideoCasetera", "LV1215", "INDUSTRIAL", "20/04/2018", "7:00 pm", "8:00 pm", "PENDIENTE");
            dt.Rows.Add(1, "Reproductor de CD",  "LV212", "AUDIOVISUALES", "23/05/2018", "10:00 am", "11:00 am", "PENDIENTE");

            gridApartadosRecursos.DataSource = dt;
            gridApartadosRecursos.DataBind();
        
        }
    }
}