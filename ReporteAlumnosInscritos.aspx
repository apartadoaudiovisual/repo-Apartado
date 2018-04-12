<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReporteAlumnosInscritos.aspx.cs" Inherits="ReporteAlumnosInscritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="JS/w2ui-1.4.3.css" rel="stylesheet" type="text/css" />
   <script src="JS/w2ui-1.4.3.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="form-group">
          
       
         <div class="col-lg-2">
            <asp:Label ID="Label1" runat="server" Text="STRM:"></asp:Label>
            <asp:DropDownList ID="Dropciclo" CssClass="form-control"  runat="server">
                <asp:ListItem>3067</asp:ListItem>
                <asp:ListItem>3068</asp:ListItem>
                <asp:ListItem Value="3069"></asp:ListItem>
                </asp:DropDownList>
         </div>
         <div class="col-lg-2">
            <asp:Label ID="Label3" runat="server" Text="Acad Career:"></asp:Label>
            <asp:DropDownList ID="DropAcadCareer"  CssClass="form-control"  runat="server">
                <asp:ListItem Value="LIC">Licenciatura</asp:ListItem>
                <asp:ListItem Value="MAE">Maestría</asp:ListItem>
                <asp:ListItem Value="DOC">Doctorado</asp:ListItem>
             </asp:DropDownList>
            <br />
         </div>
          <div class="col-lg-2">
              <br />
          <input type="button" id="btnReporte"  value="Buscar"  class="btn btn-primary" />
       
             </div>       
         </div>
<div id="loa">
   <div id="main" style="width: 100%; height: 600px;">
   </div></div>
   <script type="text/javascript">

       $(document).ready(function () {


           $("#form").submit(function () {
               return false;
           }); 
           

            $("#btnReporte").click(function () {
                    ObtenerReporte();
               }); 

           // widget configuration
           var config = {

               grid: {
                   name: 'Report',
                   show: {
                       footer: true,
                       toolbar: true
                   },
                   columns: [
              { field: 'EMPLID', caption: 'EMPLID', size: '90px', sortable: true, searchable: 'text', resizable: true, sortable: true },
              { field: 'NAME', caption: 'NOMBRE', size: '200px', sortable: true, searchable: 'text', resizable: true, sortable: true },
              { field: 'ACAD_CAREER', caption: 'GRADO', size: '95px', sortable: true, searchable: 'text', resizable: true },
              { field: 'STRM', caption: 'CICLO LECTIVO', size: '90px', sortable: true, searchable: 'int', resizable: true },
              { field: 'DESCRSHORT', caption: 'PERIODO', size: '110px', resizable: true, resizable: true, sortable: true },
              { field: 'CRSE_ID', caption: 'N° CURSO', size: '60px', sortable: true, searchable: 'text', resizable: true },
              { field: 'CLASS_NBR', caption: 'N° CLASE', size: '60px', resizable: true, sortable: true },
              { field: 'DESCR', caption: 'DESCRIPCIÓN', size: '220px', resizable: true, sortable: true },
              { field: 'INSTRUCTOR', caption: 'INSTRUCTOR', size: '200px', resizable: true, sortable: true },
           
          ]

               }


           }




           function ObtenerReporte() {
                

               var dat;
               $.ajax({

                   type: "POST",
                   url: "ReporteAlumnosInscritos.aspx/GetReporteAlumnosInscritos",
                   data: '{STRM: "' + $("#<%=Dropciclo.ClientID%>")[0].value + '" , ACAD_CAREER: "' + $("#<%=DropAcadCareer.ClientID%>")[0].value + '" }',
                   contentType: "application/json; charset=utf-8",
                   dataType: 'json'

               })
              .fail(function () {

              })
              .done(function (response) {

                  $().w2grid(config.grid);

                  var json = (response.d);
                  for (var i = 0, l = json.length; i < l; i++) {
                      w2ui['Report'].records.push({
                          EMPLID: json[i].EMPLID,
                          NAME: json[i].NAME,
                          ACAD_CAREER: json[i].ACAD_CAREER,
                          STRM: json[i].STRM,
                          DESCRSHORT: json[i].DESCRSHORT,
                          CRSE_ID: json[i].CRSE_ID,
                          CLASS_NBR: json[i].CLASS_NBR,
                          DESCR: json[i].DESCR,
                          INSTRUCTOR: json[i].INSTRUCTOR,
                          

                      });


                  }

                  w2ui.Report.refresh();

                  $('#main').w2render('Report');
              });
           }

       });
      
        
   </script>
</asp:Content>
