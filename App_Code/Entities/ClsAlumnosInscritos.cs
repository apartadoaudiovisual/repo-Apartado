using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsAlumnosInscritos
/// </summary>
public class ClsAlumnosInscritos
{
	public ClsAlumnosInscritos()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    private string eMPLID;

    public string EMPLID
    {
        get { return eMPLID; }
        set { eMPLID = value; }
    }
    private string nAME;

    public string NAME
    {
        get { return nAME; }
        set { nAME = value; }
    }
    private string aCAD_CAREER;

    public string ACAD_CAREER
    {
        get { return aCAD_CAREER; }
        set { aCAD_CAREER = value; }
    }
    private string sTRM;

    public string STRM
    {
        get { return sTRM; }
        set { sTRM = value; }
    }
    private string dESCRSHORT;

    public string DESCRSHORT
    {
        get { return dESCRSHORT; }
        set { dESCRSHORT = value; }
    }
    private string cRSE_ID;

    public string CRSE_ID
    {
        get { return cRSE_ID; }
        set { cRSE_ID = value; }
    }
    private int cLASS_NBR;

    public int CLASS_NBR
    {
        get { return cLASS_NBR; }
        set { cLASS_NBR = value; }
    }
    private string dESCR;

    public string DESCR
    {
        get { return dESCR; }
        set { dESCR = value; }
    }
    private string iNSTRUCTOR;

    public string INSTRUCTOR
    {
        get { return iNSTRUCTOR; }
        set { iNSTRUCTOR = value; }
    }
}