using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de BDRoles
/// </summary>
public class BDRoles
{
	public BDRoles()
	{
		
	}

    public List<ClsRoles> ListarRoles() {

        List<ClsRoles> roles = new List<ClsRoles>();

        try {

            List<SqlParameter> param = new List<SqlParameter>() 
            { 
                new SqlParameter("@accion", 1)
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Roles", param);

            foreach(DataRow dr in registro.Rows){

                ClsRoles r = new ClsRoles();

                r.idRol = Int32.Parse(dr["ID"].ToString());
                r.nombreRol = dr["DESCRIPCION"].ToString();
                r.activo = Boolean.Parse(dr["ESTATUS"].ToString());

                roles.Add(r);
            
            }
        
        }catch(Exception e){

            roles = null;

        }

        return roles;
    
    }

    public int AgregarRol(string nombreRol, int activo, int apartadoAreas, int apartadoRecursos, int confArea, int confRecurso, int confUsuarios, int confRoles, int reportes, int estadisticas) {

        int res = 0;

        try
        {

            List<SqlParameter> param = new List<SqlParameter>() 
            { 
                new SqlParameter("@accion", 2),
                new SqlParameter("@nombreRol", nombreRol),
                new SqlParameter("@activo", activo),
                new SqlParameter("@apartadoArea", apartadoAreas),
                new SqlParameter("@apartadoRecursos", apartadoRecursos),
                new SqlParameter("@confArea", confArea),
                new SqlParameter("@confRecurso", confRecurso),
                new SqlParameter("@confUsuarios", confUsuarios),
                new SqlParameter("@confRoles", confRoles),
                new SqlParameter("@reportes", reportes),
                new SqlParameter("@estadisticas", estadisticas)
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Roles", param);

            foreach (DataRow dr in registro.Rows)
            {
                res=Int32.Parse(dr["res"].ToString());

            }

        }
        catch (Exception e)
        {

            res=0;

        }

        return res;
    
    }

    public int EliminarRol(string idRol){

        int res = 0;

        try
        {

            List<SqlParameter> param = new List<SqlParameter>() 
            { 
        
                new SqlParameter("@accion", 3),
                new SqlParameter("@idRol", idRol)
        
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Roles", param);

            foreach(DataRow dr in registro.Rows){

                res = Int32.Parse(dr["res"].ToString());
            
            }


        }catch(Exception e){
        
            res=0;
        
        }


        return res;

    
    }

    public List<string> ListarConfiguracionRol(string idRol){

        List<string> resultado = null;

        try {

            List<SqlParameter> param = new List<SqlParameter>() 
            { 
            
                new SqlParameter("@accion", 4),
                new SqlParameter("@idRol", idRol)
            
            };


            DataTable registro = new ClsSQL().ExecuteSp("SP_Roles", param);

            foreach(DataRow dr in registro.Rows){

                resultado[0] = dr["1"].ToString();
            
            }

        }catch(Exception e){

            resultado = null;
        }

        return resultado;
    
    }


    public List<string> DepartamentosDeRolesdelPerfil(string idPerfil) {

        List<string> rolesDepto = new List<string>();

        try
        {

            List<SqlParameter> param = new List<SqlParameter>() 
            { 
            
                new SqlParameter("@accion", 5),
                new SqlParameter("@idRol", idPerfil)
            
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Roles", param);

            foreach(DataRow dr in registro.Rows){

                rolesDepto.Add(dr["idDepartamentos"].ToString());
            
            }

        }
        catch (Exception e) {

            rolesDepto = null;
        
        }

        return rolesDepto;
    
    }


    public List<ClsAreaDeServicio> listaAreasDelRol(string emplid) {

        List<ClsAreaDeServicio> areasAS = new List<ClsAreaDeServicio>();

        try {

            List<SqlParameter> param = new List<SqlParameter>() 
            { 
            
                new SqlParameter("@accion", 5),
                new SqlParameter("@emplid", emplid)
            
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Roles", param);


            foreach(DataRow dr in registro.Rows){

                ClsAreaDeServicio areas = new ClsAreaDeServicio();

                areas.idAreaServicio = dr["idAreaServicio"].ToString();
                areas.descripcionAS = dr["descripcionAS"].ToString();
                areas.depto = dr["depto"].ToString();

                areasAS.Add(areas);
            
            }

        
        }catch(Exception e){

            areasAS = null;
        
        }


        return areasAS;
    
    
    }

}