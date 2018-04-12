using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Usuario
/// </summary>
public class Usuario
{
	public Usuario()
	{		
	}

    private string emplid;

    public string Emplid
    {
        get { return emplid; }
        set { emplid = value; }
    }


    private string nombre;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

}