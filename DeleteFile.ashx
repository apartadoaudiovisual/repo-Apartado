<%@ WebHandler Language="C#" Class="DeleteFile" %>

using System;
using System.Web;

public class DeleteFile : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        try
        {

        
        string archivo = context.Server.MapPath("~/Archivos/" + context.Request["Archivo"]); 
        
        if(System.IO.File.Exists(archivo))
        {
            System.IO.File.Delete(archivo);
        }

        }
        catch (Exception ex)
        {

            context.Response.ContentType = "text/plain";
            context.Response.Write(ex.Message.ToString());
        }

        
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

   
}