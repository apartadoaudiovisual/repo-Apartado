<%@ Page Title="Agregar Apartado de Recursos Audiovisuales" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RealizarApartadoRecurso.aspx.cs" Inherits="RealizarApartadoRecurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:MultiView ID="mvApartadoRecursos" runat="server">

        <asp:View ID="vAgregarApartadosRecursos" runat="server">


        </asp:View>

        <asp:View ID="vApartadosRecursos" runat="server">

        <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                <asp:LinkButton ID="btnAgregarApartado" runat="server" Text="Agregar" 
                    CssClass="btn btn-primary">
                    <i class="glyphicon glyphicon-plus"></i> Agregar Apartado de Recursos
                </asp:LinkButton>
            </div>
            <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                <asp:LinkButton ID="btnBuscarEspecifico" runat="server" Text="Agregar" 
                    CssClass="btn btn-primary">
                    <i class="glyphicon glyphicon-plus"></i> Buscar Apartado Especifico
                </asp:LinkButton>
            </div>

            <div align="right" id="BuscarEnGrid" runat="server" class="divFiltro">
                Buscar Apartado de Recurso:
                <input type="text" id="FilterTextBox" name="FilterTextBox" />                   
            </div>

            <div class="divGrid scroll">
                <asp:GridView ID="gridApartadosRecursos" runat="server" CssClass="grid">
                </asp:GridView>
             </div>

        </asp:View>

    </asp:MultiView>

</asp:Content>

