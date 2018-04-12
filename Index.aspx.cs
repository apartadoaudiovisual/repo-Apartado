using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mx.edu.itson.apps2;

public partial class Index : System.Web.UI.Page
{
    string emplid, nombre, departamento, noControl, nip, campus, perfil;
    int nivel;
    Boolean daClases;
    List<string> rol;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.emplid = "";
        this.nombre = "";
        this.departamento = "";
        this.noControl = "";
        this.nip = "";
        this.rol = null;
        this.campus = "";
        this.nivel = 0;
        this.perfil = "";
        this.daClases = false;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {

        BDUsuarios OBJUsuarios = new BDUsuarios();

        //verificamos que esta registrado en la Institucion
        string existe = OBJUsuarios.ExisteUsuario(txtUSUARIO.Text);

        if(existe.Equals("1")){

            //verificamos el nip del usuario
            this.nip = OBJUsuarios.getNip(txtUSUARIO.Text);

            //y se valida
            if (nip.Equals(txtpassword.Text))
            {
                    //consultamos el nivel de acceso del usuario
                    this.nivel = OBJUsuarios.GetnivelAcceso(txtUSUARIO.Text);
                    
                    //guardamos los datos en las variables
                    this.emplid = txtUSUARIO.Text;
                    this.nombre = OBJUsuarios.getNombreUsuarioID(emplid);
                    this.departamento = OBJUsuarios.getDepartamento(emplid);
                    this.campus = OBJUsuarios.getCampus(emplid);
                    this.rol = OBJUsuarios.getRol(emplid);

                    

                    string tipo = OBJUsuarios.getTipo(emplid);


                    daClases = OBJUsuarios.getDaClases(emplid); 
                    

                    
                    

                    if (tipo == "A")
                    {
                        perfil = "Maestro Auxiliar";
                    
                    }
                    if (tipo == "E")
                    {
                        perfil = "Empleado Eventual";

                    }
                    if (tipo == "P")
                    {
                        perfil = "Empleado Planta";

                    }
                    if (tipo == "H")
                    {
                        perfil = "Maestro Auxiliar";

                    }



                    List<string> listaSesion = new List<string>();

                    listaSesion.Add(emplid);
                    listaSesion.Add(nivel.ToString());
                    listaSesion.Add(nombre);
                    listaSesion.Add(nip);
                    listaSesion.Add(departamento);
                    listaSesion.Add(campus);
                    listaSesion.Add(perfil);
                    listaSesion.Add(daClases.ToString());

                    foreach(string s in rol)
                    {
                        
                        listaSesion.Add(s);
                    }

                    
                    

                    Session["ListaSession"] = listaSesion;

                    Response.Redirect("Principal.aspx");
                
            }
            else {

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Contraseña incorrecta.','Inicio de sesión');", true);
            
            }
        
        }else if(existe.Equals("0")){

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('El ID del usuario no existe.','Inicio de sesión');", true);

        }else if(existe.Equals("")){

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Error en la conexion.', 'Inicio de Sesion');", true);

        }

        //AuthADService servicio = new AuthADService();
        //string response = servicio.IsAuth("ITSONEDU", txtUSUARIO.Text, txtpassword.Text);
        //string response = "True";

             
    }


    
}