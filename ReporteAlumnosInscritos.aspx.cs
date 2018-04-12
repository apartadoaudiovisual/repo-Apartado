using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class ReporteAlumnosInscritos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]

    public static List<ClsAlumnosInscritos> GetReporteAlumnosInscritos(string STRM,string ACAD_CAREER)
    {
        BDAlumnosInscritos ObjAlumnosInscritos = new BDAlumnosInscritos();

        List<ClsAlumnosInscritos> ListReporte = ObjAlumnosInscritos.getReporteAlumnosInscritos(STRM, ACAD_CAREER);
      

        return ListReporte;

    }


    
}