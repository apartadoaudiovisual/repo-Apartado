using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsEmpleados
/// </summary>
public class ClsEmpleados
{
	public ClsEmpleados()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    string emplid = string.Empty;

    public string Emplid
    {
        get { return emplid; }
        set { emplid = value; }
    }
    string name = "";

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    string sex = "";

    public string Sex
    {
        get { return sex; }
        set { sex = value; }
    }
    string phone = "";

    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    string campus_id = "";

    public string Campus_id
    {
        get { return campus_id; }
        set { campus_id = value; }
    }
    DateTime fecha_alta ;

    public DateTime Fecha_alta
    {
        get { return fecha_alta; }
        set { fecha_alta = value; }
    }

}