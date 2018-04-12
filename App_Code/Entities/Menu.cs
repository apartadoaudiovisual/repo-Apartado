using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Menu
/// </summary>
public class Menu
{
	public Menu()
	{		
	}

    private int idmenu;

    public int Idmenu
    {
        get { return idmenu; }
        set { idmenu = value; }
    }

    private string nombre;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }


    private int orden;

    public int Orden
    {
        get { return orden; }
        set { orden = value; }
    }

    private int tipo;

    public int Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }

}