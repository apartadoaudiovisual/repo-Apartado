<%@ Page Title="Configuraciones de Roles" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConfiguracionesRoles.aspx.cs" Inherits="ConfiguracionesRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:MultiView ID="mvConfigRoles" runat="server">

        <asp:View ID="vAgregarRoles" runat="server">

            <div class="form-inline">

                    <div class="col-sm-12 form-group">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre del Rol" CssClass=""></asp:Label>
                        
                        <asp:TextBox ID="txtNombreRol" runat="server" class="form-control"></asp:TextBox>

                        <asp:Label ID="lblActivo" runat="server" Text="Activar Rol" CssClass=""></asp:Label>

                        <input id="cbxRolActivo" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary form-control"/>
                        
                        <asp:Label ID="lblAreaAS" runat="server" Text="Area de Servicio" CssClass=""></asp:Label>
                        
                        <asp:DropDownList ID="ddlAS" runat="server" class="form-control">
                            
                        </asp:DropDownList>

                    </div>

                    
                    <h3><span class="">Configuracion de Permisos</span></h3>
                    

                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <table>
                            <tr class="toogle">
                                <td>Apartado de Areas</td> <td><input id="cbxApartadoAreas" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Apartado de Recursos</td> <td><input id="cbxApartadoRecursos" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Configuracion de Areas</td> <td><input id="cbxConfAreas" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Configuracion de Recursos</td> <td><input id="cbxConfRecursos" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Configuracion de Usuarios</td> <td><input id="cbxConfUsuarios" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Configuracion de Roles</td> <td><input id="cbxConfRoles" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Generar Reportes</td> <td><input id="cbxConfReportes" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Generar Estadisticas</td> <td><input id="cbxConfEstadisticas" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                        </table>
                    </div>


                    

                    <div class="col-sm-12 form-group">
                    <div class="col-sm-2 form-group" >
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Agregar" 
                                CssClass="btn btn-primary" onclick="btnGuardarRol">
                                <i class="glyphicon glyphicon-save"></i> Guardar
                            </asp:LinkButton>
                    </div>
                    <div class="col-sm-2 form-group">
                        <asp:LinkButton ID="btnCancelar" runat="server" Text="Cancelar" 
                            CssClass="btn btn-primary" onclick="btnCancelarAgregarRol">
                            <i class="glyphicon glyphicon-remove"></i> Cancelar
                        </asp:LinkButton>
                    </div>
                    </div>
                </div>

        </asp:View>

        <asp:View ID="vRoles" runat="server">

            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                <asp:LinkButton ID="btnAgregarRoles" runat="server" Text="" 
                    CssClass="btn btn-primary" OnClick="AgregarRol">
                    <i class="glyphicon glyphicon-plus"></i> Agregar Rol
                </asp:LinkButton>
            </div>
            
            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                <asp:LinkButton ID="btnEliminarRol" runat="server" Text="" 
                    CssClass="btn btn-primary" OnClick="EliminarRol">
                    <i class="glyphicon glyphicon-remove"></i> Eliminar Rol
                </asp:LinkButton>
            </div>
            
            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                <asp:LinkButton ID="btnConfigurarRol" runat="server" Text="" 
                    CssClass="btn btn-primary" onclick="ConfigurarRol">
                    <i class="glyphicon glyphicon-cog"></i> Configurar Rol
                </asp:LinkButton>
            </div>
            

            <div align="right" id="BuscarEnGrid" runat="server" class="divFiltro">
                Buscar Rol:
                <input type="text" id="FilterTextBox" name="FilterTextBox" />                   
            </div>

            <div class="divGrid scroll col-sm-12">
                <asp:GridView ID="gridRoles" runat="server" CssClass="grid"  
                    onrowcommand="gridRoles_RowCommand" Width="100%" 
                    onselectedindexchanged="gridRoles_SelectedIndexChanged" 
                    onselectedindexchanging="gridRoles_SelectedIndexChanging">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                    </Columns>
                </asp:GridView>
             </div>

        </asp:View>

        <asp:View ID="vConfigurarRol" runat="server">

            <div class="form-inline">

                    <div class="col-sm-12 form-group">
                        <asp:Label ID="Label1" runat="server" Text="Nombre del Rol" CssClass=""></asp:Label>
                        
                        <asp:TextBox ID="txtNombreRolC" runat="server" class="form-control"></asp:TextBox>

                        <asp:Label ID="Label2" runat="server" Text="Activar Rol" CssClass=""></asp:Label>

                        <input id="cbxActivoC" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary form-control"/>
                        
                    </div>

                    
                    <h3><span class="">Configuracion de Permisos</span></h3>
                    

                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <table>
                            <tr class="toogle">
                                <td>Apartado de Areas</td> <td><input id="cbxApartadoAreasC" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Apartado de Recursos</td> <td><input id="cbxApartadoRecursoC" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Configuracion de Areas</td> <td><input id="cbxConfAreasC" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Configuracion de Recursos</td> <td><input id="cbxConfRecursosC" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Configuracion de Usuarios</td> <td><input id="cbxConfUsuariosC" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Configuracion de Roles</td> <td><input id="cbxConfRolesC" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Generar Reportes</td> <td><input id="cbxConfReportesC" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                             <tr class="toogle">
                                <td>Generar Estadisticas</td> <td><input id="cbxConfEstadisticasC" type="checkbox"  data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary"/></td>
                             </tr>
                        </table>
                    </div>


                    

                    <div class="col-sm-12 form-group">
                    <div class="col-sm-2 form-group" >
                            <asp:LinkButton ID="btnGuardarConf" runat="server" Text="Agregar" 
                                CssClass="btn btn-primary" onclick="btnGuardarConfiguracion">
                                <i class="glyphicon glyphicon-save"></i> Guardar
                            </asp:LinkButton>
                    </div>
                    <div class="col-sm-2 form-group">
                        <asp:LinkButton ID="btnCancelarConf" runat="server" Text="Cancelar" 
                            CssClass="btn btn-primary" onclick="btnCancelarAgregarRol">
                            <i class="glyphicon glyphicon-remove"></i> Cancelar
                        </asp:LinkButton>
                    </div>
                    </div>
                </div>

        </asp:View>

    </asp:MultiView>

</asp:Content>

