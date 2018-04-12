<%@ Page Title="Reporte sin servicio de cómputo" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReporteSinServicio.aspx.cs" Inherits="ReporteSinServicio" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
   <div class="row">
        <div class="col-xs-6 col-sm-3 col-md-2 col-lg-2">
            <asp:Button ID="btnReporte" runat="server" Text="Generar reporte" CssClass="btn btn-default" onclick="btnReporte_Click" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            
            
            
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                Font-Size="8pt" InteractiveDeviceInfos="(Colección)" ProcessingMode="Remote" 
                ShowCredentialPrompts="False" ShowDocumentMapButton="False" WaitMessageFont-Names="Verdana" 
                WaitMessageFont-Size="14pt" Height="552px" Width="1024px">
            <ServerReport ReportServerUrl="" />
            </rsweb:ReportViewer>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
    </div>

    

</asp:Content>

