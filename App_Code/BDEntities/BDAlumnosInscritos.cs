using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de BDAlumnosInscritos
/// </summary>
public class BDAlumnosInscritos
{
	public BDAlumnosInscritos()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    /// <summary>
    /// metodo para recolectar a los usuarios del sistema
    /// </summary>
    /// <returns></returns>
    public List<ClsAlumnosInscritos> getReporteAlumnosInscritos(string Strm,string Acad_career)
    {
        List<ClsAlumnosInscritos> Lista = new List<ClsAlumnosInscritos>();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 1),  
                new SqlParameter("@STRM ", Strm),  
                new SqlParameter("@ACAD_CAREER", Acad_career),  
               
            };

            DataTable registro = new ClsSQL().ExecuteSp("Sp_AlumnosInscritos", param);
            foreach (DataRow fila in registro.Rows)
            {
                ClsAlumnosInscritos ObjAlumnos = new ClsAlumnosInscritos();
                ObjAlumnos.EMPLID = fila["EMPLID"].ToString();
                ObjAlumnos.NAME = fila["NAME"].ToString();
                ObjAlumnos.ACAD_CAREER = fila["ACAD_CAREER"].ToString();
                ObjAlumnos.STRM = fila["STRM"].ToString();
                ObjAlumnos.DESCRSHORT = fila["DESCRSHORT"].ToString();
                ObjAlumnos.CRSE_ID = fila["CRSE_ID"].ToString();
                ObjAlumnos.CLASS_NBR = Convert.ToInt32(fila["CLASS_NBR"].ToString());
                ObjAlumnos.DESCR = fila["DESCR"].ToString();
                ObjAlumnos.INSTRUCTOR = fila["INSTRUCTOR"].ToString();

              
                Lista.Add(ObjAlumnos);
            }
        }
        catch (Exception e)
        {


        }
        return Lista;

    }
}