<%@ Page Title="Servicios PROMEP" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ServiciosPromep.aspx.cs" Inherits="ServiciosPromep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:DropDownList ID="dboServicio" runat="server" Height="30px" 
    onselectedindexchanged="dboServicio_SelectedIndexChanged" Width="334px">
    <asp:ListItem>Produccion</asp:ListItem>
    <asp:ListItem>Proyectos</asp:ListItem>
    <asp:ListItem>Premios</asp:ListItem>
    <asp:ListItem>DatosLaborales</asp:ListItem>
    <asp:ListItem>IdentificaPTC</asp:ListItem>
    <asp:ListItem>Tutorias</asp:ListItem>
    <asp:ListItem>Estudios</asp:ListItem>
    <asp:ListItem>Direccion</asp:ListItem>
    <asp:ListItem>GestionAcademica</asp:ListItem>
</asp:DropDownList>
<br />
<asp:GridView ID="dgProyectos" runat="server" CellPadding="4" 
    ForeColor="#333333" GridLines="None">
    <RowStyle BackColor="#EFF3FB" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
<br />
<asp:Button ID="btnProyectos" runat="server" Height="29px" 
    onclick="btnProyectos_Click" Text="Consultar" />
&nbsp;

</asp:Content>

