using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Descripción breve de ClsSQL
/// </summary>
public class ClsSQL
{
	
     private SqlConnection cn;
     SqlTransaction transaction;
     public ClsSQL()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//

        try
        {
            this.CrearConexion();
            this.AbirConexion();
        }
        

        catch (Exception Ex)
        {
            throw new Exception(Ex.Message,Ex.InnerException);
        }
    



	}


    private void CrearConexion()
    {
        string cadena = ConfigurationManager.AppSettings["Conexion"];
        this.cn = new SqlConnection(cadena);
    }
    private void AbirConexion()
    {
        this.cn.Open();
    }
    public void ConexClose()
    {
        this.cn.Close();
    }

    /// <summary>
    /// método para Ejecutar un sp normal
    /// </summary>
    public DataTable ExecuteSp(string sp, List<SqlParameter> args)
    {

        DataTable dt = new DataTable();
        SqlCommand cmd;

        cmd = new SqlCommand(sp, this.cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddRange(args.ToArray());

        SqlDataAdapter dta = new SqlDataAdapter(cmd);
        dta.Fill(dt);
        this.ConexClose();
        return dt;


    }

    /// <summary>
    /// método para Ejecutar un sp con transaction
    /// </summary>
    public DataTable ExecuteSpTransaction(string sp, List<SqlParameter> args)
    {
        DataTable dt = new DataTable();
        try
        {

            transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);


            SqlCommand cmd;

            cmd = new SqlCommand(sp, this.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = transaction;
            cmd.Parameters.AddRange(args.ToArray());

            SqlDataAdapter dta = new SqlDataAdapter(cmd);
            dta.Fill(dt);
            return dt;

        }
        catch (Exception)
        {
            transaction.Rollback();
            return dt;
        }
        finally
        {

            transaction.Commit();
            ConexClose();

        }
    }
  

  

}