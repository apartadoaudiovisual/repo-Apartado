<%@ Page Title="Cargar Archivos" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cargar_Archivos.aspx.cs" Inherits="Cargar_Archivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



      
    <link href="css/bootstrap-fileinput/css/bootstrap.min.css" rel="stylesheet" type="text/css" /> 
        <link href="css/bootstrap-fileinput/css/fileinput.css" media="all" rel="stylesheet" type="text/css" />
      
        <script src="css/bootstrap-fileinput/js/fileinput.js" type="text/javascript"></script>
       
        <script src="css/bootstrap-fileinput/js/fileinput_locale_es.js" type="text/javascript"></script>
      

      
      <input id="input-ru" type="file" multiple=true class="file-loading">
<script>
    $("#input-ru").fileinput({
        language: "es",
        uploadUrl: "FileUploadHandler.ashx",
      
        allowedFileExtensions: ["jpg", "png", "gif","txt","xls"],
        maxFileCount: 4,
   
 

    });
</script>
</asp:Content>

