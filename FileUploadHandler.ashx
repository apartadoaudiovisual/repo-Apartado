<%@ WebHandler Language="C#" Class="FileUploadHandler" %>

using System;
using System.Web;

public class FileUploadHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        try
        {

       
        if (context.Request.Files.Count > 0)
        {
            HttpFileCollection files = context.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                string fname = context.Server.MapPath("~/Archivos/" + file.FileName);
                file.SaveAs(fname);
            }
            
            
            context.Response.ContentType = "text/plain";
            context.Response.Write("{}");
            
        }
        }
        catch (Exception ex)
        {

            context.Response.ContentType = "text/plain";
            context.Response.Write("Error");
            
        }

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}