using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de BDAreasDeServicios
/// </summary>
public class BDAreasDeServicios
{
	public BDAreasDeServicios()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    //Lista todas las Areas de Servicio
    public DataTable ListaAreasServicios() {

        DataTable tabla = new DataTable();

        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 1)    
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_AreasDeServicios", param);

            tabla = registro;

           
            
        }
        catch (Exception e)
        {

            tabla = null;

        }

        return tabla;

    
    }

    //Agregar una nueva Area de Servicio en las tablas tblAreasDeServicios, tbl_TipoRelAreaServicio, tbl_AreaDeServiciosRelCampus
    public int AgregarAreaDeServicio(string emplid, string descripcion, string depto, string idCampus, string idTipoArea) {

        int b = 0;

        try {

            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 2),
                new SqlParameter("@emplid", emplid),
                new SqlParameter("@descripcionAS", descripcion),
                new SqlParameter("@depto", depto),
                new SqlParameter("@idCampus", idCampus),
                new SqlParameter("@idTipoAS", idTipoArea)
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_AreasDeServicios", param);

            foreach(DataRow dr in registro.Rows){

                b = Int32.Parse(dr["res"].ToString());
            
            }
        
        }catch(Exception e){

            b = 0;
        
        }

        return b;
    
    }

    //Listar todos los Campus
    public List<ClsCampus> ListaCampus() {

        List<ClsCampus> campus = new List<ClsCampus>();

        try {

            List<SqlParameter> param = new List<SqlParameter>
            {
                new SqlParameter("@Accion", 4)
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_AreasDeServicios", param);
            

            foreach(DataRow dr in registro.Rows){

                ClsCampus bdc = new ClsCampus();
                bdc.ID = dr["ID"].ToString();
                bdc.descripcion = dr["Descripcion"].ToString();

                campus.Add(bdc);
            
            }

        }catch(Exception e){

            campus = null;
        }


        return campus;

    }

    //Listar todos los departamentos
    public List<ClsDepartamento> ListaDeptos() {

        List<ClsDepartamento> depto = new List<ClsDepartamento>();


        try {

            List<SqlParameter> param = new List<SqlParameter> { 
            
                new SqlParameter("@Accion", 3)
            
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_AreasDeServicios", param);

            foreach(DataRow dr in registro.Rows){

                ClsDepartamento dpt = new ClsDepartamento();
                dpt.ID = dr["ID"].ToString();
                dpt.Descripcion = dr["Descr"].ToString();

                depto.Add(dpt);
            
            }
        
        
        }catch(Exception e){

            depto = null;

        }

        return depto;
    
    }

    //Listar los tipos de Areas de Servicio para el DropDownList
    public List<ClsTiposAS> ListaTiposAS() {

        List<ClsTiposAS> tipos = new List<ClsTiposAS>();


        try {

            List<SqlParameter> param = new List<SqlParameter>() 
            { 
                new SqlParameter("@Accion", 5)
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_AreasDeServicios", param);

            foreach(DataRow dr in registro.Rows){

                ClsTiposAS tas = new ClsTiposAS();

                tas.ID=dr["ID"].ToString();
                tas.Descripcion = dr["Descripcion"].ToString();

                tipos.Add(tas);
            
            }
        
        }catch(Exception e){

            tipos = null;
        }

        return tipos;
    
    }

    //Listar todos las Areas de Servicio segun el administrador
    public List<ClsAreaDeServicio> ListaAS() {

        List<ClsAreaDeServicio> areas = new List<ClsAreaDeServicio>();

        try {

            List<SqlParameter> param = new List<SqlParameter>() 
            { 
                new SqlParameter("@Accion", 3)
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Administradores", param);

            foreach (DataRow dr in registro.Rows) {

                ClsAreaDeServicio ar = new ClsAreaDeServicio();

                ar.idAreaServicio = dr["ID"].ToString();
                ar.descripcionAS = dr["Nombre"].ToString();
                ar.depto = dr["depto"].ToString();

                areas.Add(ar);
            
            }
        
        
        }catch(Exception e){

            areas = null;
        }

        return areas;
    
    }

    //Eliminar un Area de Servicio
    public int EliminarAS(int ID) {

        int res = 0;

        try
        {

            List<SqlParameter> param = new List<SqlParameter>() 
            { 
            
                new SqlParameter("@Accion", 6),
                new SqlParameter("@idAreaServicio", ID)

            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_AreasDeServicios", param);

            foreach(DataRow dr in registro.Rows){

                res = Int32.Parse(dr["res"].ToString());
            }

        }
        catch (Exception e) {


            res = 0;
        
        }

        return res;
    
    }

    //Traer datos de una Area de Servicio Seleccionado
    public DataTable DatosDelAreaServicio(int id) {

        DataTable registro = null;

        try
        {

            List<SqlParameter> param = new List<SqlParameter>() 
            { 
            
                new SqlParameter("@Accion", 7),
                new SqlParameter("@idAreaServicio", id)
            
            };

            registro = new ClsSQL().ExecuteSp("SP_AreasDeServicios", param);

        }
        catch (Exception e) {

            registro = null;
        
        }

        return registro;
    
    }

    //Actualizar un area de servicio
    public int ActualizaAS(int ID, string descripcionAS, string depto, string idTipoAS, string idCampus) {

        int res = 0;

        try
        {
            List<SqlParameter> param = new List<SqlParameter>() 
            { 
                new SqlParameter("@Accion", 8),
                new SqlParameter("@idAreaServicio", ID),
                new SqlParameter("@descripcionAS", descripcionAS),
                new SqlParameter("@depto", depto),
                new SqlParameter("@idTipoAS", idTipoAS),
                new SqlParameter("@idCampus", idCampus)

            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_AreasDeServicios", param);

            foreach (DataRow dr in registro.Rows) {

                res = Int32.Parse(dr["res"].ToString());
            
            }

        }
        catch (Exception e) {

            res = 0;
        
        }


        return res;
    
    }
}