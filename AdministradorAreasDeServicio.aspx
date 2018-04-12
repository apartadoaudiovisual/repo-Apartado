<%@ Page Title="Administrador de Areas de Servicio" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministradorAreasDeServicio.aspx.cs" Inherits="AdministradorAreasDeServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    </br>
    <asp:MultiView ID="mvAdministradoresAS" runat="server">

        <asp:View ID="vAgregarAdministradoresAS" runat="server">

            <div class="col-sm-12 form-vertical">
                
                <div class="col-sm-4 form-group">
                <asp:Label ID="lblUsuario" runat="server" Text="Buscar Usuario" CssClass="control-label"></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server" class="form-control"></asp:TextBox>
                </div>

                <div class="col-sm-2 form-group" >
                        <asp:LinkButton ID="btnBuscar" runat="server" Text="Buscar" 
                            CssClass="btn btn-primary" onclick="btnBuscar_Click">
                            <i class="glyphicon glyphicon-search"></i> Buscar
                        </asp:LinkButton>
                </div>

                <div class="col-sm-6 form-group">
                    <asp:Label ID="lblAdministradorNombre" runat="server" Text="Nuevo Administrador" CssClass="control-label"></asp:Label>
                        <asp:DropDownList ID="ddlAdministradorNombre" runat="server" class="form-control">
                            
                    </asp:DropDownList>
                </div>

                <div class="col-sm-6 form-group">
                    <asp:Label ID="lblAreaServicio" runat="server" Text="Asignar Area de Servicio" CssClass="control-label"></asp:Label>
                        <asp:DropDownList ID="ddlAreaServicio" runat="server" class="form-control">
                            
                    </asp:DropDownList>
                </div>

                <div class="col-sm-12 form-group">
                <div class="col-sm-2 form-group" >
                        <asp:LinkButton ID="btnAgregar" runat="server" Text="Agregar" 
                            CssClass="btn btn-primary" OnClick="guardarAdministrador">
                            <i class="glyphicon glyphicon-save"></i> Guardar
                        </asp:LinkButton>
                </div>
                <div class="col-sm-2 form-group">
                    <asp:LinkButton ID="btnCancelar" runat="server" Text="Cancelar" 
                        CssClass="btn btn-primary" onclick="btnCancelar_Click">
                        <i class="glyphicon glyphicon-remove"></i> Cancelar
                    </asp:LinkButton>
                </div>
                </div>

            </div>

        </asp:View>

        <asp:View ID="vAdministradoresAS" runat="server">

            <div class="col-lg-2 col-sm-3">
                <asp:LinkButton ID="btnAgregarAdministrador" runat="server" Text="Agregar" 
                    CssClass="btn btn-primary" onclick="btnAgregarAdministrador_Click">
                    <i class="glyphicon glyphicon-plus"></i> Agregar Administrador
                </asp:LinkButton>
            </div>

            <div class="col-lg-2 col-sm-3">
                <asp:LinkButton ID="btnEliminarAdministrador" runat="server" OnClick="EliminarAdmin" 
                    CssClass="btn btn-primary">
                    <i class="glyphicon glyphicon-remove"></i> Eliminar Administrador
                </asp:LinkButton>
            </div>

            <div class="col-lg-2 col-sm-3">
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="ActualizarAdmin" 
                    CssClass="btn btn-primary">
                    <i class="glyphicon glyphicon-cog"></i> Configurar Administrador
                </asp:LinkButton>
            </div>

            <div class="input-group">
                <span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>
                <input id="email" type="text" class="form-control" name="email" placeholder="Buscar Administrador">
            </div>
            <!--<div id="BuscarEnGrid" runat="server" class="divFiltro col-lg-3 col-sm-3">
                Buscar:
                <input type="text" id="FilterTextBox" name="FilterTextBox" class="form-control"/>                   
            </div>-->
            <div class="divGrid scroll col-lg-12">
                <asp:GridView ID="gridAdministradorAS" runat="server" CssClass="grid" 
                    Width="100%" onrowcommand="gridAdministradorAS_RowCommand" 
                    onselectedindexchanged="gridAdministradorAS_SelectedIndexChanged" 
                    onselectedindexchanging="gridAdministradorAS_SelectedIndexChanging">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
             </div>

        </asp:View>

        <asp:View ID="vActualizarAdministrador" runat="server">

            <div class="col-sm-12 form-vertical">
                
                <div class="col-sm-4 form-group">
                <asp:Label ID="Label1" runat="server" Text="Administrador" CssClass="control-label"></asp:Label>
                <asp:TextBox ID="txtAdministradoAct" runat="server" class="form-control"></asp:TextBox>
                </div>

                <div class="col-sm-4 form-group">
                    <asp:Label ID="Label3" runat="server" Text="Area de Servicio" CssClass="control-label"></asp:Label>
                        <asp:DropDownList ID="ddlAreasAdminAct" runat="server" class="form-control">
                        </asp:DropDownList>
                </div>

                <div class="col-sm-4 form-group">
                    <asp:Label ID="Label2" runat="server" Text="Estatus del Administrador" CssClass="control-label"></asp:Label>
                    <div class="">
                    <input id="cbxAdminAct" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary form-control"/>
                    </div>
                </div>

                <div class="col-sm-12 form-group">
                <div class="col-sm-2 form-group" >
                        <asp:LinkButton ID="LinkButton3" runat="server" Text="Agregar" 
                            CssClass="btn btn-primary" OnClick="GuardarAdminAct">
                            <i class="glyphicon glyphicon-save"></i> Guardar
                        </asp:LinkButton>
                </div>
                <div class="col-sm-2 form-group">
                    <asp:LinkButton ID="LinkButton4" runat="server" Text="Cancelar" 
                        CssClass="btn btn-primary" OnClick="CancelarAdminAct">
                        <i class="glyphicon glyphicon-remove"></i> Cancelar
                    </asp:LinkButton>
                </div>
                </div>

            </div>

        </asp:View>

    </asp:MultiView>

</asp:Content>

