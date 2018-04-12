using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;

public partial class ServiciosPromep : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    DataTable tabla = new DataTable();
    protected void btnProyectos_Click(object sender, EventArgs e)
    {
        ServiceReferencePROMEP.PROMEPWebServicesSoapClient servicio = new ServiceReferencePROMEP.PROMEPWebServicesSoapClient(); 
       // PROMEPWebServices servicio = new PROMEPWebServices();
        string strServicio = dboServicio.SelectedValue;

        string pass = "ITSONWS27";

        DataSet dt = new DataSet();

        switch (strServicio)
        {
            case "Produccion":
                {
                    dt = servicio.Produccion("ITSONWS", pass);
                    break;
                }
            case "Proyectos":
                {
                    dt = servicio.Proyectos("ITSONWS", pass);                 
                    break;
                }
            case "Premios":
                {
                     dt = servicio.Premios("ITSONWS", pass);
                 
                    break;
                }
            case "DatosLaborales":
                {
                     dt = servicio.DatosLaborales("ITSONWS", pass);
                  
                    break;
                }
            case "IdentificaPTC":
                {
                     dt = servicio.IdentificaPTC("ITSONWS", pass);               
                    break;
                }
            case "Tutorias":
                {
                     dt = servicio.Tutorias("ITSONWS", pass);
                
                    break;
                }
            case "Estudios":
                {
                    dt = servicio.Estudios("ITSONWS", pass);
                 
                    break;
                }
            case "Direccion":
                {
                    DataSet dt7 = servicio.Direccion("ITSONWS", pass);
                    dgProyectos.DataSource = dt7;
                    break;
                }
            case "GestionAcademica":
                {
                    DataSet dt8 = servicio.GestionAcademica("ITSONWS", pass);
                    dgProyectos.DataSource = dt8;
                    break;
                }
            default:
                break;
        }
        dgProyectos.DataSource = dt;
        dgProyectos.DataBind();

        DataTable tabla = dt.Tables[0];

        ExportToExcel2(tabla);

    }

   
    void ExportToExcel2(DataTable datos)
    {
        var memoryStream = new MemoryStream();
        string excelName = "PROMEP";

      
        if (datos.Rows.Count > 0)
        {
            using (ExcelPackage objExcelPackage = new ExcelPackage())
            {

                ExcelWorksheet objWorksheet = objExcelPackage.Workbook.Worksheets.Add("Reporte PROMEP");

                objWorksheet.Cells["A1"].LoadFromDataTable(datos, true);
                objWorksheet.Cells.Style.Font.SetFromFont(new Font("Calibri", 10));
                objWorksheet.Cells.AutoFitColumns();



                using (ExcelRange objRange = objWorksheet.Cells["A1:XFD1"])
                {
                    objRange.Style.Font.Bold = true;
                    objRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    objRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    objRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    objRange.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    objRange.Style.Font.Color.SetColor(Color.White);
                    objExcelPackage.SaveAs(memoryStream);
                }

            }

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=" + excelName + ".xlsx");

            Response.Charset = "UTF-8";
            memoryStream.WriteTo(Response.OutputStream);
            Response.ContentEncoding = Encoding.Unicode;

        }
    }

   
    protected void dboServicio_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
}