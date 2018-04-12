using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Data;
using OfficeOpenXml.Style;
using OfficeOpenXml;

public partial class Formulario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["_parametro"] != null)
        {

            string Parametro = Request.Params["_parametro"];

            if (Parametro != "")
            {
                string[] ParametroArray = Parametro.Split('_');

                if (ParametroArray[0] == "Comando" && ParametroArray[1] == "Y")
                {
                    Response.Write("Llamar al metodo que ocupo comando");
                }
                if (ParametroArray[0] == "Comando2" && ParametroArray[1] == "Y")
                {
                    Response.Write("Llammar al metodo que ocupo comando2");
                }
                else if (ParametroArray[0] == "Comando2" && ParametroArray[1] == "C")
                {
                    Response.Redirect("Formulario.aspx");
                }
            }
        }

        llenagrid();

    }

    void llenagrid()
    {
        BDEmpleados bd = new BDEmpleados();

        GridView1.DataSource = bd.ConsultarEmpleados();
        GridView1.DataBind();
    }

    void ExportarExcel()
    {
        DataTable dt1 = new DataTable();
      

        dt1 = (DataTable)GridView1.DataSource;
      

        using (ExcelPackage pck = new ExcelPackage())
        {
            //Create the worksheet
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("hoja");

            //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
            ws.Cells["A1"].LoadFromDataTable(dt1, true);
            //prepare the range for the column headers
            string cellRange = "A1:" + Convert.ToChar('A' + dt1.Columns.Count - 1) + 1;
            //Format the header for columns
            using (ExcelRange rng = ws.Cells[cellRange])
            {
                rng.Style.WrapText = false;
                rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                rng.Style.Font.Bold = true;
                rng.Style.Fill.PatternType = ExcelFillStyle.Solid; //Set Pattern for the background to Solid
                rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                rng.Style.Font.Color.SetColor(Color.White);
            }
            //prepare the range for the rows
            string rowsCellRange = "A2:" + Convert.ToChar('A' + dt1.Columns.Count - 1) + dt1.Rows.Count * dt1.Columns.Count;
            //Format the rows
            using (ExcelRange rng = ws.Cells[rowsCellRange])
            {
                rng.Style.WrapText = false;
                rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            }




            //Read the Excel file in a byte array
            Byte[] fileBytes = pck.GetAsByteArray();

            //Clear the response
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Cookies.Clear();
            //Add the header & other information 
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.CacheControl = "private";
            Response.Charset = System.Text.UTF8Encoding.UTF8.WebName;
            Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
            Response.AppendHeader("Content-Length", fileBytes.Length.ToString());
            Response.AppendHeader("Pragma", "cache");
            Response.AppendHeader("Expires", "60");
            Response.AppendHeader("Content-Disposition", "attachment; filename=\"ExcelReport2.xlsx\"");
            //Response.AppendHeader("Content-Disposition",
            //"attachment; " +
            //"filename=\"ExcelReport.xlsx\"; " +
            //"size=" + fileBytes.Length.ToString() + "; " +
            //"creation-date=" + DateTime.Now.ToString("R") + "; " +
            //"modification-date=" + DateTime.Now.ToString("R") + "; " +
            //"read-date=" + DateTime.Now.ToString("R"));
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Write it back to the client
            Response.BinaryWrite(fileBytes);
            Response.End();

        }

    }

    

    protected void Button15_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Mensaje de error.','Titulo de mensaje');", true);
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_info('Mensaje de informacion.','Titulo de mensaje');", true);
    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_yesno('mensaje con botones','Titulo de mensaje','Comando');", true);
        
    }
    protected void Button19_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_YesNoCancel('mensaje con botones','Titulo de mensaje','Comando2');", true);
    }
    protected void Button18_Click(object sender, EventArgs e)
    {
        ExportarExcel();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}