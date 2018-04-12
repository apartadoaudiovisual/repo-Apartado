using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de BDUsuarios
/// </summary>
public class BDUsuarios
{
	public BDUsuarios()
	{		
	}

    /// <summary>
    /// metodo para recolectar a los usuarios del sistema
    /// </summary>
    /// <returns></returns>
    public List<Usuario> getUsuarios()
    {
        List<Usuario> Lista = new List<Usuario>();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 1),                 
            };

            DataTable registro = new ClsSQL().ExecuteSp("procedure_usuarios", param);
            foreach (DataRow fila in registro.Rows)
            {
                Usuario ObjUsuario = new Usuario();
                ObjUsuario.Nombre = fila["Name"].ToString();
                ObjUsuario.Emplid = fila["Emplid"].ToString();
                Lista.Add(ObjUsuario);
            }
        }
        catch (Exception e)
        {


        }
        return Lista;

    }

    /// <summary>
    /// metodo para registrar a los usuarios al sistema
    /// </summary>
    /// <param name="emplid"></param>
    /// <returns></returns>
    public bool RegistrarUsuario(string emplid)
    {
        bool correcto = false;
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 3),                 
                new SqlParameter("@emplid", emplid), 
            };

            DataTable registro = new ClsSQL().ExecuteSp("procedure_usuarios", param);
            correcto = true;
        }
        catch (Exception e)
        {
            correcto = false;
        }

        return correcto;
    }

    public bool EliminarUsuarioByEmplid(string emplid)
    {
        bool correcto = false;
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 4),                 
                new SqlParameter("@emplid", emplid), 
            };

            DataTable registro = new ClsSQL().ExecuteSp("procedure_usuarios", param);
            correcto = true;
        }
        catch (Exception e)
        {
            correcto = false;
        }

        return correcto;
    }

    /// <summary>
    /// metodo para verificar si es un usuario del sistema
    /// </summary>
    /// <param name="pagina"></param>
    /// <param name="emplid"></param>
    /// <returns></returns>
    public int VerificaUsuarioDelDistema(string emplid)
    {
        int correcto = 0;

        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",9) ,
                new SqlParameter("@emplid",emplid)
              
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);

            foreach (DataRow fila in registro.Rows)
            {
                correcto = int.Parse(fila["correcto"].ToString());
            }
        }

        catch (Exception e)
        {
            correcto = 0;
        }

        return correcto;
    }

    /// <summary>
    /// metodo para recolectar el emplid del empleado segun su cuenta de dominio
    /// </summary>
    /// <param name="dominio"></param>
    /// <returns></returns>
    public string GetEmplidEmpleadoByNombreDominio(string dominio)
    {
       /*string emplid = "";

        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",10) ,
                new SqlParameter("@dominio",dominio)                 
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);

            foreach (DataRow fila in registro.Rows)
            {
                emplid = fila["EMPLID"].ToString();
            }
        }

        catch (Exception e)
        {
            emplid = "";
        }

        return emplid;*/
        return "41453";
    }

    /// <summary>
    /// metodo para verificar el nivel de cceso del usuario
    /// </summary>
    /// <param name="dominio"></param>
    /// <returns></returns>
    public int GetnivelAcceso(string emplid)
    {
        int acceso = 0;

        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",11) ,
                new SqlParameter("@emplid",emplid)                 
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);

            foreach (DataRow fila in registro.Rows)
            {
                acceso = int.Parse(fila["acceso"].ToString());
            }
        }

        catch (Exception e)
        {
            acceso = 0;
        }

        return acceso;
    }


    public string GetnombreReal(string emplid)
    {
        /*string nombre="";

        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",5) ,
                new SqlParameter("@emplid",emplid)                 
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);

            foreach (DataRow fila in registro.Rows)
            {
                nombre = fila["name"].ToString();
            }
        }

        catch (Exception e)
        {
            nombre = "";
        }

        return nombre;*/

        return "Manuel Fabian Torres Gutierrez";
    }


    //metodo para obtener el Nombre del usuario por su ID
    public string getNombreUsuarioID( string ID) {

        string nombre = "";

        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",14) ,
                new SqlParameter("@emplid",ID)                 
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);

            foreach (DataRow fila in registro.Rows)
            {
                nombre = fila["name"].ToString();
                
            }
        }

        catch (Exception e)
        {
            nombre = "";
        }

        return nombre;

    }

    //metodo para saber si el usuario existe en la BD de la institucion o no
    public string ExisteUsuario(string ID) {

        string res= "0";

        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",15) ,
                new SqlParameter("@emplid",ID)                 
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);

            foreach (DataRow fila in registro.Rows)
            {
                res = fila["correcto"].ToString();
            }
        }

        catch (Exception e)
        {
            res = "";
        }

        return res;
    
    }

    //metodo para obtener el NIP del usuario
    public string getNip(string ID) {

        string nip = "";

        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",16) ,
                new SqlParameter("@emplid",ID)                 
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);

            foreach (DataRow fila in registro.Rows)
            {
                nip = fila["nip"].ToString();
            }
        }

        catch (Exception e)
        {
            nip = "";
        }

        return nip;
    }

    //Obtener el departamento del usuario
    public string getDepartamento(string ID) {

        string depto = "";

        try
        {

            List<SqlParameter> param = new List<SqlParameter>()
            { 
                new SqlParameter("@accion", 17),
                new SqlParameter("@emplid", ID)
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);

            foreach(DataRow fila in registro.Rows){
            
                depto=fila["depto"].ToString();

            }


        }
        catch (Exception e)
        {

            depto = "";

        }

        return depto;
    }

    //devuelve el campus donde trabaja el usuario
    public string getCampus(string ID) {

        string campus = "";

        try {

            List<SqlParameter> param = new List<SqlParameter>{
            
                new SqlParameter("@accion", 18),
                new SqlParameter("@emplid", ID)
            
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);

            foreach(DataRow fila in registro.Rows){

                campus = fila["campus"].ToString();
            
            }
        
        }catch(Exception e){

            campus = "";

        }

        return campus;
    
    }

    public List<string> getRol(string ID) {

        List<string> rol = new List<string>();

        try
        {

            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@accion", 19),
                new SqlParameter("@emplid", ID)

            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);

            foreach(DataRow fila in registro.Rows){

                rol.Add(fila["rol"].ToString());
            
            }

        }
        catch (Exception e) {

            rol = null;
        
        }

        return rol;
    
    }

    public string getTipo(string ID){

        string tipo = "";

        try {

            List<SqlParameter> param = new List<SqlParameter>() 
            { 
            
                new SqlParameter("@accion", 21),
                new SqlParameter("@emplid", ID)

            };


            DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);

            foreach (DataRow fila in registro.Rows)
            {

                tipo=fila["rol"].ToString();

            }
        
        }catch(Exception e){
        
            tipo="";
        
        }

        return tipo;
    }

    public Boolean getDaClases(string ID) {

        Boolean b = false;

        try
        {

            List<SqlParameter> param = new List<SqlParameter>() 
            { 
            
                new SqlParameter("@accion", 22),
                new SqlParameter("@emplid", ID)
            
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);

            foreach (DataRow dr in registro.Rows) {

                b = Convert.ToBoolean(dr["res"]);
            
            }

        }
        catch (Exception e) {

            b = false;
        
        }

        return b;

    }

    //metodo para devolver dodos los usuarios con rol de administrador
    public DataTable ListaAdministradores() {

        DataTable tabla = new DataTable();
    
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",1)                 
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Administradores", param);

            tabla = registro;
            
        }
        catch(Exception e){

            tabla = null;
        }

        return tabla;

    
    }

    //
    public List<Usuario> ListaUsuarios(string nombre) {

        

        List<Usuario> usuarios = new List<Usuario>();

        try {

            List<SqlParameter> param = new List<SqlParameter>() 
            { 
            
                new SqlParameter("@Accion", 2),
                new SqlParameter("@nombre", nombre)
            
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Administradores", param);

            foreach(DataRow dr in registro.Rows){

                Usuario u = new Usuario();

                u.Emplid = dr["ID"].ToString();
                u.Nombre = dr["Nombre"].ToString();

                usuarios.Add(u);
            }
        
        
        }catch(Exception e){

            usuarios = null;
        
        }

        return usuarios;
    
    }

    //Agregar un administrador nuevo
    public int AgregarAdministradorAS(string ID, string IDArea)
    {

        int res = 0;

        try
        {

            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 20),
                new SqlParameter("@emplid", ID),
                new SqlParameter("@idArea", IDArea),
            };

            DataTable registro = new ClsSQL().ExecuteSp("Procedure_usuarios", param);

            foreach (DataRow dr in registro.Rows)
            {

                res = Int32.Parse(dr["res"].ToString());

            }

        }
        catch (Exception e)
        {

            res = 0;

        }

        return res;
    
    }

    //Eliminar un Usuario Administrador
    public int EliminarAdministrador(int ID, string area) {

        int res = 0;



        try
        {
            List<SqlParameter> param = new List<SqlParameter>() 
            { 
                new SqlParameter("@Accion", 4),
                new SqlParameter("@emplid", ID),
                new SqlParameter("@area", area)
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Administradores", param);

            foreach(DataRow dr in registro.Rows){

                res = Int32.Parse(dr["res"].ToString());
            
            }
        }
        catch (Exception e) {

            res = 0;
        
        }

        return res;
    
    }

    public int ActualizarAdministrador(string ID, int acceso, string area, string areaA) {

        int res = 0;

        try
        {
            List<SqlParameter> param = new List<SqlParameter>() 
            { 
                new SqlParameter("@Accion", 5),
                new SqlParameter("@emplid", ID),
                new SqlParameter("@acceso", acceso),
                new SqlParameter("@area", area),
                new SqlParameter("@areaA", areaA)
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Administradores", param);

            foreach(DataRow dr in registro.Rows){
            
                res=Int32.Parse(dr["res"].ToString());

            }

        }
        catch (Exception e) {

            res = 0;
        
        }

        return res;
    
    }



}