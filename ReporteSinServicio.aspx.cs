using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class ReporteSinServicio : System.Web.UI.Page
{
    #region Load 
    protected void Page_Load(object sender, EventArgs e)
    {

    } 
    #endregion

    #region Boton reporte 
    protected void btnReporte_Click(object sender, EventArgs e)
    {
        try
        {

            this.ReportViewer1.ServerReport.ReportPath = "/ReportesAdminBitacora/SinServicio";
            this.ReportViewer1.ServerReport.ReportServerUrl = new System.Uri("http://cubos-sol/reportserver");

            ReportParameter rpFechaInicio = new ReportParameter();
            rpFechaInicio.Name = "2016-05-02";
            rpFechaInicio.Values.Add("1");

            ReportParameter rpFechaFin = new ReportParameter();
            rpFechaFin.Name = "fechaFin";
            rpFechaFin.Values.Add("2017-05-02");

           this.ReportViewer1.ServerReport.ReportServerCredentials = new CustomReportCredentials("useReports", "S0luci0nes", "ITSONEDU");

           ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rpFechaInicio, rpFechaFin });

            ReportViewer1.ShowPrintButton = true;

            //this.ReportViewer1.ServerReport.ReportPath = "/ReportesAdminBitacora/SinServicio";
            //this.ReportViewer1.ServerReport.ReportServerUrl = new System.Uri("http://cubos-sol/reportserver");

            //ReportParameter rpFechaInicio = new ReportParameter();
            //rpFechaInicio.Name = "fechaInicio";
            //rpFechaInicio.Values.Add("2017-05-02");

            //ReportParameter rpFechaFin = new ReportParameter();
            //rpFechaFin.Name = "fechaFin";
            //rpFechaFin.Values.Add("2017-05-02");

            //this.ReportViewer1.ServerReport.ReportServerCredentials = new CustomReportCredentials("useReports", "S0luci0nes", "ITSONEDU");

            //ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rpFechaInicio, rpFechaFin });

            //ReportViewer1.ShowPrintButton = true;
        }
        catch (Exception ex)
        {
            MandarMensajeUsario("error en generar reporte comuníquese con el administrador del sistema " + ex.Message);
        }

    }
    #endregion

    #region Mensaje a usuario 
    void MandarMensajeUsario(string mensaje)
    {
        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_info('" + mensaje + ".','Informacion');", true);
    } 
    #endregion
}