<%@ Page Title="Configuraciones de Areas" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConfiguracionesAreas.aspx.cs" Inherits="ConfiguracionesAreas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:MultiView ID="mvCongigAreas" runat="server">

        <asp:View ID="vAgregarAreas" runat="server">
        </asp:View>

        <asp:View ID="vAreas" runat="server">

            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                <asp:LinkButton ID="btnAgregarArea" runat="server" Text="" 
                    CssClass="btn btn-primary">
                    <i class="glyphicon glyphicon-plus"></i> Agregar Area
                </asp:LinkButton>
            </div>
            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                <asp:LinkButton ID="btnConfigurarArea" runat="server" Text="" 
                    CssClass="btn btn-primary">
                    <i class="glyphicon glyphicon-plus"></i> Configurar Area
                </asp:LinkButton>
            </div>

            <div align="right" id="BuscarEnGrid" runat="server" class="divFiltro">
                Buscar Area:
                <input type="text" id="FilterTextBox" name="FilterTextBox" />                   
            </div>

            <div class="divGrid scroll">
                <asp:GridView ID="gridAreas" runat="server" CssClass="grid" >
                </asp:GridView>
             </div>

        </asp:View>

    </asp:MultiView>

</asp:Content>

