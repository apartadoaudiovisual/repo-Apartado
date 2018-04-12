<%@ Page Title="Configuraciones de Recursos Audiovisuales" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConfiguracionesRecursos.aspx.cs" Inherits="ConfiguracionesRecursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:MultiView ID="mvConfigRecursos" runat="server">

        <asp:View ID="vAgregarRecursos" runat="server">
        </asp:View>

        <asp:View ID="vRecursos" runat="server">

            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                <asp:LinkButton ID="btnAgregarRecurso" runat="server" Text="" 
                    CssClass="btn btn-primary">
                    <i class="glyphicon glyphicon-plus"></i> Agregar Recurso
                </asp:LinkButton>
            </div>
            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                <asp:LinkButton ID="btnConfigurarRecurso" runat="server" Text="" 
                    CssClass="btn btn-primary">
                    <i class="glyphicon glyphicon-plus"></i> Configurar Recurso
                </asp:LinkButton>
            </div>

            <div align="right" id="BuscarEnGrid" runat="server" class="divFiltro">
                Buscar Recurso:
                <input type="text" id="FilterTextBox" name="FilterTextBox" />                   
            </div>

            <div class="divGrid scroll">
                <asp:GridView ID="gridRecursos" runat="server" CssClass="grid">
                </asp:GridView>
             </div>

        </asp:View>

    </asp:MultiView>

</asp:Content>

