using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Item
/// </summary>
public class Item
{
	public Item()
	{	
	}

    private int iditem;

    public int Iditem
    {
        get { return iditem; }
        set { iditem = value; }
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

    private string pagina;

    public string Pagina
    {
        get { return pagina; }
        set { pagina = value; }
    }

    private int idsubmenu;

    public int Idsubmenu
    {
        get { return idsubmenu; }
        set { idsubmenu = value; }
    }

    private string imagen;

    public string Imagen
    {
        get { return imagen; }
        set { imagen = value; }
    }
}