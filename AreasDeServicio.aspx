<%@ Page Title="Areas de Servicio" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AreasDeServicio.aspx.cs" Inherits="AreasDeServicio" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:MultiView ID="mViewAreasDeServicio" runat="server">

        <asp:View ID="vAgregarAreaDeServicio" runat="server">

            <div class="col-sm-12 form-vertical">

                <div class="col-sm-6 form-group">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion" CssClass="control-label"></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server" class="form-control"></asp:TextBox>
                </div>


                <div class="col-sm-6 form-group">
                    <asp:Label ID="lblCampus" runat="server" Text="Campus" CssClass="control-label"></asp:Label>
                        <asp:DropDownList ID="ddlCampus" runat="server" class="form-control">
                            
                    </asp:DropDownList>
                </div>


                <div class="col-sm-6 form-group">
                    <asp:Label ID="lblDepartamento" runat="server" Text="Departamento" CssClass="control-label"></asp:Label>
                        <asp:DropDownList ID="ddlDepartamento" runat="server" class="form-control">
                            
                    </asp:DropDownList>
                </div>


                <div class="col-sm-6 form-group">
                    <asp:Label ID="Label6" runat="server" Text="Tipo de Area" CssClass="control-label"></asp:Label>
                        <asp:DropDownList ID="ddlTipoArea" runat="server" class="form-control">
                            
                    </asp:DropDownList>
                </div>

                <div class="col-sm-12 form-group">
                <div class="col-sm-2 form-group" >
                        <asp:LinkButton runat="server" Text="Agregar" 
                            CssClass="btn btn-primary" onclick="GuardarAS">
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

        <asp:View ID="vAreasDeServicio" runat="server">

            <div class="col-xs-6 col-sm-3 col-md-3 col-lg-2">
                <asp:LinkButton ID="btnGuardar" runat="server" Text="Agregar" 
                    CssClass="btn btn-primary" onclick="btnAgregar_Click">
                    <i class="glyphicon glyphicon-plus"></i> Agregar Area de Servicio
                </asp:LinkButton>
            </div>

            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                <asp:LinkButton ID="btnEliminarAS" runat="server" Text="" OnClick="EliminarAS"
                    CssClass="btn btn-primary">
                    <i class="glyphicon glyphicon-remove"></i> Eliminar Area de Servicio
                </asp:LinkButton>
            </div>
            
            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                <asp:LinkButton ID="btnConfigurarAS" runat="server" Text="" OnClick="ConfigurarAS"
                    CssClass="btn btn-primary">
                    <i class="glyphicon glyphicon-cog"></i> Configurar Area de Servicio
                </asp:LinkButton>
            </div>

            <div align="right" id="BuscarEnGrid" runat="server" class="divFiltro">
                Buscar Area de Servicio:
                <input type="text" class="" id="FilterTextBox" name="FilterTextBox" onclick="return FilterTextBox_onclick()" />                   
            </div>
            <div class="divGrid scroll">
                <asp:GridView ID="gridAreasServicio" runat="server" CssClass="grid" 
                    onselectedindexchanged="gridAreasServicio_SelectedIndexChanged" 
                    onselectedindexchanging="gridAreasServicio_SelectedIndexChanging" 
                    Width="100%" onrowcommand="gridAreasServicio_RowCommand">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
             </div>



        </asp:View>

        <asp:View ID="vActualizarAreaDeServicio" runat="server">

            <div class="col-sm-12 form-vertical">

                <div class="col-sm-6 form-group">
                <asp:Label ID="Label1" runat="server" Text="Descripcion" CssClass="control-label"></asp:Label>
                <asp:TextBox ID="txtDescrAct" runat="server" class="form-control"></asp:TextBox>
                </div>


                <div class="col-sm-6 form-group">
                    <asp:Label ID="Label2" runat="server" Text="Campus" CssClass="control-label"></asp:Label>
                        <asp:DropDownList ID="ddlCampusAct" runat="server" class="form-control">
                            
                    </asp:DropDownList>
                </div>


                <div class="col-sm-6 form-group">
                    <asp:Label ID="Label3" runat="server" Text="Departamento" CssClass="control-label"></asp:Label>
                        <asp:DropDownList ID="ddlDeptoAct" runat="server" class="form-control">
                            
                    </asp:DropDownList>
                </div>


                <div class="col-sm-6 form-group">
                    <asp:Label ID="Label4" runat="server" Text="Tipo de Area" CssClass="control-label"></asp:Label>
                        <asp:DropDownList ID="ddlTipoAct" runat="server" class="form-control">
                            
                    </asp:DropDownList>
                </div>

                <div class="col-sm-12 form-group">
                <div class="col-sm-2 form-group" >
                        <asp:LinkButton ID="btnGuardarActAS" runat="server" Text="Actualizar" 
                            CssClass="btn btn-primary" onclick="GuardarActualizacion">
                            <i class="glyphicon glyphicon-save"></i> Actualizar
                        </asp:LinkButton>
                </div>
                <div class="col-sm-2 form-group">
                    <asp:LinkButton ID="btnCancelarActAS" runat="server" Text="Cancelar" 
                        CssClass="btn btn-primary" onclick="btnCanvelarActualizacion">
                        <i class="glyphicon glyphicon-remove"></i> Cancelar
                    </asp:LinkButton>
                </div>
                </div>
            </div>

        </asp:View>

    </asp:MultiView>

</asp:Content>

