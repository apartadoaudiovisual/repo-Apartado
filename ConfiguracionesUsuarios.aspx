<%@ Page Title="Configuraciones de Usuarios" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConfiguracionesUsuarios.aspx.cs" Inherits="ConfiguracionesUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:MultiView ID="mvConfigUsuarios" runat="server">

        <asp:View ID="vAgregarUsuarios" runat="server">
        </asp:View>

        <asp:View ID="vUsuarios" runat="server">

            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                <asp:LinkButton ID="btnAgregarUsuario" runat="server" Text="" 
                    CssClass="btn btn-primary">
                    <i class="glyphicon glyphicon-plus"></i> Agregar Usuario
                </asp:LinkButton>
            </div>
            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                <asp:LinkButton ID="btnConfigurarUsuario" runat="server" Text="" 
                    CssClass="btn btn-primary">
                    <i class="glyphicon glyphicon-plus"></i> Configurar Usuario
                </asp:LinkButton>
            </div>

            <div align="right" id="BuscarEnGrid" runat="server" class="divFiltro">
                Buscar Usuario:
                <input type="text" id="FilterTextBox" name="FilterTextBox" />                   
            </div>

            <div class="divGrid scroll">
                <asp:GridView ID="gridUsuarios" runat="server" CssClass="grid">
                </asp:GridView>
             </div>

        </asp:View>

    </asp:MultiView>

</asp:Content>

