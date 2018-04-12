using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de SubMenu
/// </summary>
public class SubMenu
{
	public SubMenu()
	{
	
	}

    private int idsubmenu;

    public int Idsubmenu
    {
        get { return idsubmenu; }
        set { idsubmenu = value; }
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

    private int idmenu;

    public int Idmenu
    {
        get { return idmenu; }
        set { idmenu = value; }
    }
}