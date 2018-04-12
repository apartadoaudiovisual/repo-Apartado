using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de BDMenu
/// </summary>
public class BDMenu
{
	public BDMenu()
	{	
	}


    /// <summary>
    /// metodo que recolecta las cabeceras de los mneus
    /// </summary>
    /// <param name="emplid"></param>
    /// <returns></returns>
    public List<Menu> GetCabeceras(string emplid)
    {
        List<Menu> lista = new List<Menu>();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 14),
                new SqlParameter("@emplid", emplid),    
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Menu", param);
            foreach (DataRow fila in registro.Rows)
            {
                Menu M = new Menu();
                M.Idmenu = int.Parse(fila["idmenu"].ToString());
                M.Nombre = fila["nombre"].ToString();
                M.Orden = int.Parse(fila["orden"].ToString());
                M.Tipo = int.Parse(fila["tipo"].ToString());

                lista.Add(M);
            }
        }

        catch (Exception e)
        {
            lista = null;
        }

        return lista;
    }

    /// <summary>
    /// para menus publicos
    /// </summary>
    /// <returns></returns>
    public List<Menu> GetCabecerasPublicas()
    {
        List<Menu> lista = new List<Menu>();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 9),              
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Menu", param);
            foreach (DataRow fila in registro.Rows)
            {
                Menu M = new Menu();
                M.Idmenu = int.Parse(fila["idmenu"].ToString());
                M.Nombre = fila["nombre"].ToString();
                M.Orden = int.Parse(fila["orden"].ToString());
                M.Tipo = int.Parse(fila["tipo"].ToString());

                lista.Add(M);
            }
        }

        catch (Exception e)
        {
            lista = null;
        }

        return lista;
    }

    /// <summary>
    /// metodo para recolectar los submenus segun sea el menu
    /// </summary>
    /// <param name="emplid"></param>
    /// <param name="menu"></param>
    /// <returns></returns>
    public List<SubMenu> GetSubmenus(string emplid, int menu)
    {
        List<SubMenu> lista = new List<SubMenu>();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 2),
                new SqlParameter("@emplid", emplid),    
                new SqlParameter("@menu", menu), 
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Menu", param);
            foreach (DataRow fila in registro.Rows)
            {
                SubMenu SM = new SubMenu();
                SM.Idsubmenu = int.Parse(fila["idsubmenu"].ToString());
                SM.Nombre = fila["nombre"].ToString();
                SM.Orden = int.Parse(fila["orden"].ToString());
                SM.Idmenu = int.Parse(fila["idmenu"].ToString());

                lista.Add(SM);
            }
        }

        catch (Exception e)
        {
            lista = null;
        }

        return lista;
    }
    
    /// <summary>
    /// para menus publicos
    /// </summary>
    /// <param name="menu"></param>
    /// <returns></returns>
    public List<SubMenu> GetSubmenus(int menu)
    {
        List<SubMenu> lista = new List<SubMenu>();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 10),                  
                new SqlParameter("@menu", menu), 
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Menu", param);
            foreach (DataRow fila in registro.Rows)
            {
                SubMenu SM = new SubMenu();
                SM.Idsubmenu = int.Parse(fila["idsubmenu"].ToString());
                SM.Nombre = fila["nombre"].ToString();
                SM.Orden = int.Parse(fila["orden"].ToString());
                SM.Idmenu = int.Parse(fila["idmenu"].ToString());

                lista.Add(SM);
            }
        }

        catch (Exception e)
        {
            lista = null;
        }

        return lista;
    }

    /// <summary>
    /// metodo para recolectar los items segun sea el submenu
    /// </summary>
    /// <param name="emplid"></param>
    /// <param name="submenu"></param>
    /// <returns></returns>
    public List<Item> GetItems(string emplid, int submenu)
    {
        List<Item> lista = new List<Item>();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 3),
                new SqlParameter("@emplid", emplid),    
                new SqlParameter("@submenu", submenu), 
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Menu", param);
            foreach (DataRow fila in registro.Rows)
            {
                Item I = new Item();
                I.Iditem = int.Parse(fila["iditem"].ToString());
                I.Nombre = fila["nombre"].ToString();
                I.Orden = int.Parse(fila["orden"].ToString());
                I.Pagina = fila["pagina"].ToString();
                I.Idsubmenu = int.Parse(fila["idsubmenu"].ToString());

                lista.Add(I);
            }
        }

        catch (Exception e)
        {
            lista = null;
        }

        return lista;
    }

    /// <summary>
    /// para menus publicos
    /// </summary>
    /// <param name="submenu"></param>
    /// <returns></returns>
    public List<Item> GetItems(int submenu)
    {
        List<Item> lista = new List<Item>();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 11),                  
                new SqlParameter("@submenu", submenu), 
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Menu", param);
            foreach (DataRow fila in registro.Rows)
            {
                Item I = new Item();
                I.Iditem = int.Parse(fila["iditem"].ToString());
                I.Nombre = fila["nombre"].ToString();
                I.Orden = int.Parse(fila["orden"].ToString());
                I.Pagina = fila["pagina"].ToString();
                I.Idsubmenu = int.Parse(fila["idsubmenu"].ToString());

                lista.Add(I);
            }
        }

        catch (Exception e)
        {
            lista = null;
        }

        return lista;
    }

    /// <summary>
    /// metodo para recolectar los items segun sea su menu
    /// </summary>
    /// <param name="emplid"></param>
    /// <param name="menu"></param>
    /// <returns></returns>
    public List<Item> GetItemsByMenu(string emplid, int menu)
    {
        List<Item> lista = new List<Item>();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 15),
                new SqlParameter("@emplid", emplid),    
                new SqlParameter("@menu", menu), 
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Menu", param);
            foreach (DataRow fila in registro.Rows)
            {
                Item I = new Item();
                I.Iditem = int.Parse(fila["iditem"].ToString());
                I.Nombre = fila["nombre"].ToString();
                I.Orden = int.Parse(fila["orden"].ToString());
                I.Pagina = fila["pagina"].ToString();
                I.Idsubmenu = int.Parse(fila["idsubmenu"].ToString());
                I.Imagen = fila["imagen"].ToString();

                lista.Add(I);
            }
        }

        catch (Exception e)
        {
            lista = null;
        }

        return lista;
    }


    /// <summary>
    /// para menu publico
    /// </summary>
    /// <param name="emplid"></param>
    /// <param name="menu"></param>
    /// <returns></returns>
    public List<Item> GetItemsByMenu(int menu)
    {
        List<Item> lista = new List<Item>();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 12),                
                new SqlParameter("@menu", menu), 
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Menu", param);
            foreach (DataRow fila in registro.Rows)
            {
                Item I = new Item();
                I.Iditem = int.Parse(fila["iditem"].ToString());
                I.Nombre = fila["nombre"].ToString();
                I.Orden = int.Parse(fila["orden"].ToString());
                I.Pagina = fila["pagina"].ToString();
                I.Idsubmenu = int.Parse(fila["idsubmenu"].ToString());
                I.Imagen = fila["imagen"].ToString();

                lista.Add(I);
            }
        }

        catch (Exception e)
        {
            lista = null;
        }

        return lista;
    }


    /// <summary>
    /// metodo para recolectar todos los permisos
    /// </summary>
    /// <returns></returns>
    public DataTable GetlistadoDePermisos(string emplid)
    {
        DataTable tabla = new DataTable();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",5) ,
                new SqlParameter("@emplid",emplid) 
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Menu", param);
            tabla = registro;
        }

        catch (Exception e)
        {
            tabla = null;
        }

        return tabla;
    }

    /// <summary>
    /// metodo para recolectar los datos del empleado
    /// </summary>
    /// <param name="emplid"></param>
    /// <returns></returns>
    public DataTable getEmpleado(string emplid)
    {
        DataTable tabla = new DataTable();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",6) ,
                new SqlParameter("@emplid",emplid) 
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Menu", param);
            tabla = registro;
        }

        catch (Exception e)
        {
            tabla = null;
        }

        return tabla;
    }

    /// <summary>
    /// metodo para activar o quitar permisos
    /// </summary>
    /// <param name="emplid"></param>
    /// <param name="item"></param>
    /// <param name="activo"></param>
    /// <returns></returns>
    public bool ActivaDesactivaPerimsos(string emplid, int item, int activo)
    {
        bool correcto = false;
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",7) ,
                new SqlParameter("@emplid",emplid) ,
                new SqlParameter("@item",item) ,
                new SqlParameter("@permiso",activo) 
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Menu", param);
            correcto = true;
        }

        catch (Exception e)
        {
            correcto = false;
        }

        return correcto;
    }

    /// <summary>
    /// metodo para verificar que el usuario tenga permisos en la pagina a la que esta entrando
    /// </summary>
    /// <param name="pagina"></param>
    /// <param name="emplid"></param>
    /// <returns></returns>
    public int VerificaPermisoEnPagina(string pagina, string emplid)
    {
        int correcto = 0;

        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",8) ,
                new SqlParameter("@emplid",emplid) ,
                new SqlParameter("@pagina",pagina) 
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Menu", param);

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
    /// verificar si la pagina es publica
    /// </summary>
    /// <param name="pagina"></param>
    /// <returns></returns>
    public int verificarpaginaPublica(string pagina)
    {
        int correcto = 0;

        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",13) ,                
                new SqlParameter("@pagina",pagina) 
            };

            DataTable registro = new ClsSQL().ExecuteSp("SP_Menu", param);

            foreach (DataRow fila in registro.Rows)
            {
                correcto = int.Parse(fila["privado"].ToString());
            }
        }

        catch (Exception e)
        {
            correcto = 0;
        }

        return correcto;
    }

    //*********************************************************************CODIGO PARA MOSTRAR CREAR Y ASIGNAR PERFILES DE USUARIOS

    /// <summary>
    /// metodo para mostrar todos los perfiles registrados
    /// </summary>
    /// <returns></returns>
    public DataTable GetPerfilesUsuarios()
    {
        DataTable tabla = new DataTable();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",1)             
            };

            DataTable registro = new ClsSQL().ExecuteSp("Proc_perfilesUsuarios", param);
            tabla = registro;
        }

        catch (Exception e)
        {
            tabla = null;
        }

        return tabla;
    }

    /// <summary>
    /// metodo para registrar el perfil de usuarios
    /// </summary>
    /// <param name="nombre"></param>
    public void RegistraPerfilUsuario(string nombre)
    {
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",2) ,                
                new SqlParameter("@nombreperfil",nombre) 
            };

            DataTable registro = new ClsSQL().ExecuteSp("Proc_perfilesUsuarios", param);
        }

        catch (Exception e)
        {
        }
    }

    /// <summary>
    /// metodo para actualizar el perfil de usuario(se actualiza solo si esta activo o no activo)
    /// </summary>
    /// <param name="idperfil"></param>
    /// <param name="activo"></param>
    public void updateperfilusuario(int idperfil, bool activo)
    {
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",3) ,                
                new SqlParameter("@activo",activo==true?1:0), 
                new SqlParameter("@idrol",idperfil) 
            };

            DataTable registro = new ClsSQL().ExecuteSp("Proc_perfilesUsuarios", param);
        }

        catch (Exception e)
        {
        }
    }

    /// <summary>
    /// metodo para recolectar la lista de permisos
    /// </summary>
    /// <param name="emplid"></param>
    /// <returns></returns>
    public DataTable GetlistadoDePermisosPerfiles(string idrol)
    {
        DataTable tabla = new DataTable();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",4) ,
                new SqlParameter("@idrol",idrol) 
            };

            DataTable registro = new ClsSQL().ExecuteSp("Proc_perfilesUsuarios", param);
            tabla = registro;
        }

        catch (Exception e)
        {
            tabla = null;
        }

        return tabla;
    }

    /// <summary>
    /// metodo para activar o quitar permisos
    /// </summary>
    /// <param name="emplid"></param>
    /// <param name="item"></param>
    /// <param name="activo"></param>
    /// <returns></returns>
    public bool ActivaDesactivaPerimsosPerfiles(string idrol, int item, int activo)
    {
        bool correcto = false;
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",5) ,
                new SqlParameter("@idrol",idrol) ,
                new SqlParameter("@item",item) ,
                new SqlParameter("@activo",activo) 
            };

            DataTable registro = new ClsSQL().ExecuteSp("Proc_perfilesUsuarios", param);
            correcto = true;
        }

        catch (Exception e)
        {
            correcto = false;
        }

        return correcto;
    }

    /// <summary>
    /// metodo para eliminar los permisos del usuario junto con el rol
    /// </summary>
    /// <param name="emplid"></param>
    public void eliminarpermisosyrol(string emplid)
    {
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",8) ,
                new SqlParameter("@emplid",emplid) 
                
            };

            DataTable registro = new ClsSQL().ExecuteSp("Proc_perfilesUsuarios", param);

        }
        catch (Exception e)
        {
        }
    }

    /// <summary>
    /// crear la relacion del usuario con el rol seleccionado
    /// </summary>
    /// <param name="emplid"></param>
    /// <param name="idrol"></param>
    public void RegistraRolAlUsuario(string emplid, string idrol)
    {
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",6) ,
                new SqlParameter("@emplid",emplid),
                new SqlParameter("@idrol",idrol)
                
            };

            DataTable registro = new ClsSQL().ExecuteSp("Proc_perfilesUsuarios", param);

        }
        catch (Exception e)
        {
        }
    }

    /// <summary>
    /// metodo para mostrar los permisos en el rol del usuario
    /// </summary>
    /// <param name="emplid"></param>
    /// <returns></returns>
    public DataTable getPerfilesUsuarioasignados(string emplid)
    {
        DataTable tabla = new DataTable();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",7),
                new SqlParameter("@emplid",emplid)                
            };

            DataTable registro = new ClsSQL().ExecuteSp("Proc_perfilesUsuarios", param);
            tabla = registro;
        }

        catch (Exception e)
        {
            tabla = null;
        }

        return tabla;
    }

    //metodo para mostrar a los usuarios del perfil
    public DataTable getUsuariosByperfil(string perfil)
    {
        DataTable tabla = new DataTable();
        try
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion",9),
                new SqlParameter("@idrol",perfil)                
            };

            DataTable registro = new ClsSQL().ExecuteSp("Proc_perfilesUsuarios", param);
            tabla = registro;
        }

        catch (Exception e)
        {
            tabla = null;
        }

        return tabla;
    }


}