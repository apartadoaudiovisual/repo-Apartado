using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["listaSession"] != null && Session["listaSession"].ToString() != "")
        {
            List<string> listaSession = (List<string>)Session["listaSession"];
            lblusuarioSistema.Text = listaSession[2];
            //verifica si la sesion es de usuario del sistema
            
            GetMenuPublico();
            
            if (verificarUsuarioEnSistema() == 1)
            {
                //verificar si tiene permisos a la pagina que entro el usuari
                if (verificarpermiso() == 1)
                {
                    GetMenu(listaSession[0]);
                }
                else if (getPageName() == "Principal.aspx" || listaSession[1] == "1")
                {
                    GetMenu(listaSession[0]);
                }
                else
                {
                    //verificar si es pagina publica(cuando sea publica se regresa al menu principal)
                    if (paginapublica() == 1)
                    {
                        Response.Redirect("Principal.aspx");
                    }
                }
            }
            else
            {              
                //Response.Redirect("index.aspx");
            }
        }
        else if(Session["listaSession"] ==null)
        {
            Response.Redirect("index.aspx");
        }
    }


    void GetMenu(string emplid)
    {
        Literal2.Text = "";
       

        BDMenu OBJmenu = new BDMenu();
        List<Menu> Listaheaders = OBJmenu.GetCabeceras(emplid);
        string menuHTML = "";

		if (Listaheaders != null && Listaheaders.Count > 0)
		{
        foreach (Menu M in Listaheaders)
        {
            #region imprimir menu de tipo 1 con submenus
            if (M.Tipo == 1)
            {
                menuHTML = menuHTML + @" <li class='dropdown'><a href='#' data-toggle='dropdown' class='dropdown-toggle menu-pal'>" + M.Nombre + @"<b class='caret'></b></a>   <ul class='dropdown-menu'>
                                      <li> ";
                List<SubMenu> Lista_SM = OBJmenu.GetSubmenus(emplid, M.Idmenu);
                foreach (SubMenu SM in Lista_SM)
                {
                  

                    List<Item> lista_items = OBJmenu.GetItems(emplid, SM.Idsubmenu);
                    foreach (Item I in lista_items)
                    {
                        menuHTML = menuHTML + "<li><a href='" + I.Pagina + "'  >" + I.Nombre + " </a></li>";
                    }

                }



                menuHTML = menuHTML + @" 
                                        </li>
                                      </ul>
                                    </li>";
            }
            #endregion

            #region imprimir menu de tipo 2 solo con items
            if (M.Tipo == 2)
            {
                menuHTML = menuHTML + " <li class='dropdown'><a href='#' data-toggle='dropdown' class='dropdown-toggle menu-pal'>" + M.Nombre + "<b class='caret'></b></a>  <ul role='menu' class='dropdown-menu'>";


                List<Item> lista_items = OBJmenu.GetItemsByMenu(emplid, M.Idmenu);
                foreach (Item I in lista_items)
                {
                    menuHTML = menuHTML + "<li><a tabindex='-1' href='" + I.Pagina + "'>" + I.Nombre + "</a></li>";
                }


                menuHTML = menuHTML + "</ul></li>";
            }
            #endregion

            #region imprimir menu de tipo 3 con imagenes
            if (M.Tipo == 3)
            {
                menuHTML = menuHTML + @" <li class='dropdown yamm-fw'><a href='#' data-toggle='dropdown' class='dropdown-toggle menu-pal'>" + M.Nombre + @"<b class='caret'></b></a>
                          <ul class='dropdown-menu'>
                            <li>
                              <div class='yamm-content'>
                                <div class='row'>";

                List<Item> lista_items = OBJmenu.GetItemsByMenu(emplid, M.Idmenu);
                foreach (Item I in lista_items)
                {
                    menuHTML = menuHTML + @"  <div class='col-xs-6 col-sm-2'><a href='" + I.Pagina + "' class='thumbnail'>" + I.Nombre + "<img alt='150x190' src='img/" + I.Imagen + "'></a></div>";
                }

                menuHTML = menuHTML + @"</div>
                                      </div>
                                    </li>
                                  </ul>
                                </li>";
            }
            #endregion

            if (M.Tipo == 4)
            {
                List<Item> lista_items = OBJmenu.GetItemsByMenu(emplid, M.Idmenu);
                foreach (Item I in lista_items)
                {
                    Literal2.Text=Literal2.Text+"<a href='"+I.Pagina+"' class='navbar-brand menu-pal'>"+I.Nombre+" </a>";
                }
            }
        }
		}
        Literal1.Text = menuHTML;
    }

    void GetMenuPublico()
    {
        Literal3.Text = "";


        BDMenu OBJmenu = new BDMenu();
        List<Menu> Listaheaders = OBJmenu.GetCabecerasPublicas();
        string menuHTML = "";

		if (Listaheaders != null && Listaheaders.Count > 0)
		{
		
        foreach (Menu M in Listaheaders)
        {
            #region imprimir menu de tipo 1 con submenus
            if (M.Tipo == 1)
            {
                menuHTML = menuHTML + @"<!--si se modifica --!> <li class='dropdown'><a href='#' data-toggle='dropdown' class='dropdown-toggle menu-pal'>" + M.Nombre + @"<b class='caret'></b></a>   <ul class='dropdown-menu'>
                                      <li>                  
                                      <div class='yamm-content'>
                                       <div class='row'>";
                List<SubMenu> Lista_SM = OBJmenu.GetSubmenus(M.Idmenu);
                foreach (SubMenu SM in Lista_SM)
                {
                    menuHTML = menuHTML + @" <ul class='col-sm-4 list-unstyled'>
                                            <li>
                                            <p><strong>" + SM.Nombre + @"</strong></p>
                                            </li>";

                    List<Item> lista_items = OBJmenu.GetItems(SM.Idsubmenu);
                    foreach (Item I in lista_items)
                    {
                        menuHTML = menuHTML + "<li><a href='" + I.Pagina + "'  >" + I.Nombre + " </a></li>";
                    }



                    menuHTML = menuHTML + " </ul>";
                }



                menuHTML = menuHTML + @"       </div>
                                          </div>
                                        </li>
                                      </ul>
                                    </li>";
            }
            #endregion

            #region imprimir menu de tipo 2 solo con items
            if (M.Tipo == 2)
            {
                menuHTML = menuHTML + " <li class='dropdown'><a href='#' data-toggle='dropdown' class='dropdown-toggle menu-pal'>" + M.Nombre + "<b class='caret'></b></a>  <ul role='menu' class='dropdown-menu'>";


                List<Item> lista_items = OBJmenu.GetItemsByMenu(M.Idmenu);
                foreach (Item I in lista_items)
                {
                    menuHTML = menuHTML + "<li><a tabindex='-1' href='" + I.Pagina + "'>" + I.Nombre + "</a></li>";
                }


                menuHTML = menuHTML + "</ul></li>";
            }
            #endregion

            #region imprimir menu de tipo 3 con imagenes
            if (M.Tipo == 3)
            {
                menuHTML = menuHTML + @" <li class='dropdown yamm-fw'><a href='#' data-toggle='dropdown' class='dropdown-toggle menu-pal'>" + M.Nombre + @"<b class='caret'></b></a>
                          <ul class='dropdown-menu'>
                            <li>
                              <div class='yamm-content'>
                                <div class='row'>";

                List<Item> lista_items = OBJmenu.GetItemsByMenu( M.Idmenu);
                foreach (Item I in lista_items)
                {
                    menuHTML = menuHTML + @"  <div class='col-xs-6 col-sm-2'><a href='" + I.Pagina + "' class='thumbnail'>" + I.Nombre + "<img alt='150x190' src='img/" + I.Imagen + "'></a></div>";
                }

                menuHTML = menuHTML + @"</div>
                                      </div>
                                    </li>
                                  </ul>
                                </li>";
            }
            #endregion

            //if (M.Tipo == 4)
            //{
            //    List<Item> lista_items = OBJmenu.GetItemsByMenu( M.Idmenu);
            //    foreach (Item I in lista_items)
            //    {
            //        Literal3.Text = Literal3.Text + "<a href='" + I.Pagina + "' class='navbar-brand'>" + I.Nombre + " |</a>";
            //    }
            //}
        }
		}
        Literal3.Text = menuHTML;
    }

    static public string getPageName()
    {
        string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');
        string result = arrResult[arrResult.GetUpperBound(0)];
        arrResult = result.Split('?');
        return arrResult[arrResult.GetLowerBound(0)];
    }

    int verificarpermiso()
    {
        int continua = 0;

        List<string> listaSession = (List<string>)Session["ListaSession"];

        BDMenu OBJMenu = new BDMenu();
        continua = OBJMenu.VerificaPermisoEnPagina(getPageName(), listaSession[0]);

        return continua;
    }

    int paginapublica()
    {
        int continua = 0;

        List<string> listaSession = (List<string>)Session["ListaSession"];

        BDMenu OBJMenu = new BDMenu();
        continua = OBJMenu.VerificaPermisoEnPagina(getPageName(), listaSession[0]);

        return continua;
    }


    int verificarUsuarioEnSistema()
    {
        int continua = 0;

        List<string> listaSession = (List<string>)Session["ListaSession"];

        BDUsuarios OBUsuarios = new BDUsuarios();
        continua = OBUsuarios.VerificaUsuarioDelDistema(listaSession[0]);

        return continua;
    }


    /// <summary>
    /// metodo que regresa un datatable solicitando un gridview
    /// </summary>
    /// <param name="dtg"></param>
    /// <returns></returns>
    public DataTable GetDataTable(GridView dtg)
    {
        DataTable dt = new DataTable();

        // add the columns to the datatable            
        if (dtg.HeaderRow != null)
        {

            for (int i = 0; i < dtg.HeaderRow.Cells.Count - 2; i++)
            {
                dt.Columns.Add(dtg.HeaderRow.Cells[i].Text);
            }
        }

        //  add each of the data rows to the table
        foreach (GridViewRow row in dtg.Rows)
        {
            DataRow dr;
            dr = dt.NewRow();

            for (int i = 0; i < row.Cells.Count - 2; i++)
            {
                dr[i] = row.Cells[i].Text.Replace(" ", "");
            }
            dt.Rows.Add(dr);
        }
        return dt;
    }

    public void ExportarExcel2(GridView grid)
    {
        // DataTable dt1 = GetDataTable(GridEmpleados);
        DataTable dt1 = GetDataTable(grid);
        //dt1 = (DataTable)GridEmpleados.DataSource;

        using (ExcelPackage pck = new ExcelPackage())
        {
            //Create the worksheet
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("hoja1");

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
            Response.AppendHeader("Content-Disposition", "attachment; filename=\"ExcelReport.xlsx\"");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Write it back to the client
            Response.BinaryWrite(fileBytes);
            Response.End();

        }



    }


   
   protected void lnkcerrar_Click(object sender, EventArgs e)
   {
       Response.Redirect("cerrar.aspx");
   }
}
