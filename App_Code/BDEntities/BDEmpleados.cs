using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de BDEmpleados
/// </summary>
public class BDEmpleados
{
	public BDEmpleados()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    /// <summary>
    /// método para consultar el nombre y emplid de todos los empleados
    /// </summary>
    public List<ClsEmpleados> ConsultarEmpleados_Combo()
    {
        List<ClsEmpleados> ListEmpleados = new List<ClsEmpleados>();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 1),
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_Empleados", param);
            foreach (DataRow fila in registro.Rows)
            {
                ClsEmpleados ObjEmpleado = new ClsEmpleados();
                ObjEmpleado.Name = fila["Name"].ToString();
                ObjEmpleado.Emplid = fila["Emplid"].ToString();

                ListEmpleados.Add(ObjEmpleado);
            }
        }
        catch (Exception e)
        {


        }
        return ListEmpleados;
        
    }


    /// <summary>
    /// método para consultar a un empleado especifico
    /// </summary>
    public List<ClsEmpleados> Consultar_Empleado_Emplid(string Emplid)
    {
        List<ClsEmpleados> ListEmpleados = new List<ClsEmpleados>();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 3),
                 new SqlParameter("@Emplid", Emplid),
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_Empleados", param);
            foreach (DataRow fila in registro.Rows)
            {
                ClsEmpleados ObjEmpleado = new ClsEmpleados();
                ObjEmpleado.Emplid = fila["Emplid"].ToString();
                ObjEmpleado.Name = fila["Name"].ToString();
                ObjEmpleado.Sex = fila["Sex"].ToString();
                ObjEmpleado.Phone = fila["Phone"].ToString();
                ObjEmpleado.Campus_id = fila["Campus_id"].ToString();
                ObjEmpleado.Fecha_alta = Convert.ToDateTime(fila["Fecha_alta"].ToString());

                ListEmpleados.Add(ObjEmpleado);
            }
        }
        catch (Exception e)
        {


        }
        return ListEmpleados;



    }

    /// <summary>
    /// método para insertar o actualizar empleados
    /// </summary>
    public bool Insert_Update_Empleado(string EMPLID,string NAME,string SEX,string PHONE,string CAMPUS_ID,DateTime FECHA_ALTA)
    {
        
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 4),
                new SqlParameter("@EMPLID", EMPLID),
                new SqlParameter("@NAME", NAME),
                new SqlParameter("@SEX", SEX),
                new SqlParameter("@PHONE", PHONE),
                new SqlParameter("@CAMPUS_ID", CAMPUS_ID),
                new SqlParameter("@FECHA_ALTA", FECHA_ALTA),
                
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_Empleados", param);
           
        }
        catch (Exception er)
        {
            return false;
        }

        return true;
    }


    /// <summary>
    /// método para consultar  todos los empleados
    /// </summary>
    public List<ClsEmpleados> ConsultarEmpleados()
    {
        List<ClsEmpleados> ListEmpleados = new List<ClsEmpleados>();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 5),
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_Empleados", param);
            foreach (DataRow fila in registro.Rows)
            {
                ClsEmpleados ObjEmpleado = new ClsEmpleados();
                ObjEmpleado.Name = fila["Name"].ToString();
                ObjEmpleado.Emplid = fila["Emplid"].ToString();
                ObjEmpleado.Phone = fila["Phone"].ToString();
                ObjEmpleado.Sex = fila["Sex"].ToString();
                ObjEmpleado.Campus_id = fila["Campus_id"].ToString();
                ObjEmpleado.Fecha_alta = Convert.ToDateTime(fila["Fecha_alta"].ToString());
                

                ListEmpleados.Add(ObjEmpleado);
            }
        }
        catch (Exception e)
        {


        }
        return ListEmpleados;



    }



    /// <summary>
    /// método para eliminar a un empleado especifico
    /// </summary>
    /// 
   public  bool Eliminar_Empleado(string Emplid)
    {
      
       try
        {
        List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 6),
                 new SqlParameter("@Emplid", Emplid),
                
                
                    
            };
      
            DataTable registro = new ClsSQL().ExecuteSp("Procedure_Empleados", param);
           
        }
       catch (Exception e)
       {
           return  false;

       }
       return true;
    }

    /// <summary>
    /// metodo para recolectar a todos los empleados activos
    /// </summary>
    /// <returns></returns>
   public List<ClsEmpleados> ConsultarEmpleadosActivos()
   {
       List<ClsEmpleados> ListEmpleados = new List<ClsEmpleados>();
       try
       {
           List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 2),
            };

           DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);
           foreach (DataRow fila in registro.Rows)
           {
               ClsEmpleados ObjEmpleado = new ClsEmpleados();
               ObjEmpleado.Name = fila["YAALPH"].ToString();
               ObjEmpleado.Emplid = fila["Emplid"].ToString();

               ListEmpleados.Add(ObjEmpleado);
           }
       }
       catch (Exception e)
       {


       }
       return ListEmpleados;
   }



}