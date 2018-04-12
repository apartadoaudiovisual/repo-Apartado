<%@ Page Title="Titulo de la pantalla" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Formulario.aspx.cs" Inherits="Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
            <asp:Label ID="Label1" runat="server" Text="Emplid"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
            <asp:Label ID="Label3" runat="server" Text="Apellidos"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
            <asp:Label ID="Label4" runat="server" Text="Seleccinar Carrera"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                <asp:ListItem>Seleccionar</asp:ListItem>
                <asp:ListItem>opción 1</asp:ListItem>
                <asp:ListItem>Opción 2</asp:ListItem>
                <asp:ListItem>Opción 3</asp:ListItem>
            </asp:DropDownList>
         </div>
    </div>
    <br />
    <div class="row">
        <h4>Botones</h4>
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-primary">
                <i class="glyphicon glyphicon-trash"></i> Eliminar
            </asp:LinkButton>
        </div>
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnRefresh" runat="server" Text="Actualizar" class="btn btn-primary">
                <i class="glyphicon glyphicon-refresh"></i> Actualizar
            </asp:LinkButton>
        </div>
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnListalt" runat="server" Text="Registrar" class="btn btn-primary">
            <i class="glyphicon glyphicon-list-alt"></i> Registrar
            </asp:LinkButton>
        </div>
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnUser" runat="server" Text="Usuario" class="btn btn-primary">
            <i class="glyphicon glyphicon-user"></i> Usuario
            </asp:LinkButton>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnPDF" runat="server" Text="Exportar PDF" class="btn btn-primary">
            <i class="fa fa-file-pdf-o"></i>  Exportar PDF
            </asp:LinkButton>
        </div>
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnSearch" runat="server" Text="Buscar" class="btn btn-primary">
            <i class="glyphicon glyphicon-search"></i> Buscar
            </asp:LinkButton>
        </div>
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnOk" runat="server" Text="Aceptar" class="btn btn-primary">
            <i class="glyphicon glyphicon-ok"></i> Aceptar
            </asp:LinkButton>
        </div>
         <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnUsers" runat="server" Text="Usuarios" class="btn btn-primary">
            <i class="fa fa-users"></i> Usuarios
            </asp:LinkButton>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnXLS" runat="server" Text="Exportar XLS" class="btn btn-primary">
            <i class="fa fa-file-excel-o"></i> Exportar XLS
            </asp:LinkButton>
        </div>     
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnSalir" runat="server" Text="Salir" class="btn btn-primary">
            <i class="glyphicon glyphicon-off"></i> Salir
            </asp:LinkButton>
        </div>    
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnReporte" runat="server" Text="Reporte" class="btn btn-primary">
            <i class="fa fa-file"></i> Reporte
            </asp:LinkButton>
        </div>
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnCog" runat="server" Text="Configurar" class="btn btn-primary">
            <i class="glyphicon glyphicon-cog"></i> Configurar
            </asp:LinkButton>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnRemove" runat="server" Text="Cancelar trámite" class="btn btn-primary">
            <i class="glyphicon glyphicon-remove"></i> Cancelar trámite
            </asp:LinkButton>
        </div>
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnEdit" runat="server" Text="Editar" class="btn btn-primary">
            <i class="glyphicon glyphicon-edit"></i> Editar
            </asp:LinkButton>
        </div>
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="btnPlus" runat="server" Text="Agregar" class="btn btn-primary">
            <i class="glyphicon glyphicon-plus"></i> Agregar
            </asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <h4>Links</h4>
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="Link" runat="server" class="btn btn-link">LinkButton</asp:LinkButton>                                    
        </div>
        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
            <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-link">LinkButton</asp:LinkButton>                                    
        </div>   
    </div>
    <br />
    <div class="row">
        <h4>CheckBox</h4>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <table>
                <tr class="toogle">
                    ¿Trabajas?  <input id="Checkbox" type="checkbox" checked data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary">

                    ¿Estudias?  <input id="Checkbox1" type="checkbox" checked data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary">

                    ¿Eres casado?  <input id="Checkbox2" type="checkbox" checked data-toggle="toggle" data-style="slow ios" runat="server" class="bt-primary">

                </tr>
            </table>
        </div>
    </div>
    <div class="row radiobtn">
        <h4>RadioButton</h4>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <form action="">
                <input type="radio" name="radiobtn" id="opcion1" value="Opcion1" /> Opción 1 
                <input type="radio" name="radiobtn" id="opcion2" value="Opcion2" /> Opción 2
                <input type="radio" name="radiobtn" id="opcion3" value="Opcion3" /> Opción 3
            </form>
        </div>
    </div>
    <div class="row">
        <h3>Fechas</h3>
        <div class="col-xs-12 col-sm-6 col-md-2 col-lg-2">
            <asp:Label ID="Label2" runat="server" Text="Fecha Inicio"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" class="form-control dtFecha_inicio"></asp:TextBox>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-2 col-lg-2">
            <asp:Label ID="Label5" runat="server" Text="Fecha Fin"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" class="form-control dfecha_Fin"></asp:TextBox>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-2 col-lg-2">
            <asp:Label ID="Label6" runat="server" Text="Seleccionar Fecha"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" class="form-control Fecha"></asp:TextBox>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
            <asp:Label ID="Label7" runat="server" Text="Bloqueas fechas atrasadas"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" class="form-control MayorIgual"></asp:TextBox>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
            <asp:Label ID="Label8" runat="server" Text="Fechas solo de lunes a viernes"></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server" class="form-control L_V"></asp:TextBox>
        </div>
    </div> 
    <br />
    <div class="row">
        <h4>Mensajes</h4>
        <div class="col-xs-12 col-sm-6 col-md-2 col-lg-2">
            <asp:Button ID="Button15" runat="server" Text="Mensaje de error" CssClass="btn btn-danger" onclick="Button15_Click" />
        </div>
        <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
            <asp:Button ID="Button16" runat="server" Text="Mensaje informativo" CssClass="btn btn-info" onclick="Button16_Click" />    
        </div>
        <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
            <asp:Button ID="Button17" runat="server" Text="Mensaje Si/No"  CssClass="btn btn-info" onclick="Button17_Click"  /> 
        </div>
        <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
            <asp:Button ID="Button19" runat="server" Text="Mensaje Si/No/Cancelar"  CssClass="btn btn-info" onclick="Button19_Click" /> 
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-0 col-sm-6 col-md-9 col-lg-9">
        </div>
        <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
            <div align="right" class="divFiltro" >
                <div align="right" style="width:200px"> 
                    <asp:Label ID="Label9" runat="server" Text="Filtro de busqueda"></asp:Label> 
                    <asp:TextBox ID="TextBox8" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <div class="table-responsive">
                <asp:GridView ID="GridView1" runat="server" name="GridView1" class="grid" 
                    AutoGenerateColumns="False" PageIndex="1" allowpaging="true" 
                    onpageindexchanging="GridView1_PageIndexChanging" >
                    <Columns>
                        <asp:BoundField DataField="EMPLID" HeaderText="emplid" >
                        <ControlStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NAME" HeaderText="nombre" >
                        </asp:BoundField>
                        <asp:BoundField DataField="Phone" HeaderText="telefono" >
                        </asp:BoundField>
                        <asp:BoundField DataField="Fecha_alta" HeaderText="fecha de alta" >
                        </asp:BoundField>
                        <asp:ButtonField ButtonType="Link"  Text="<i aria-hidden='true' class='glyphicon glyphicon-edit fa-lg'></i>"></asp:ButtonField>
                        <asp:ButtonField ButtonType="Link"  Text="<i aria-hidden='true' class='glyphicon glyphicon-trash fa-lg'></i>"></asp:ButtonField>
                     </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-2 col-lg-2">
            <asp:LinkButton ID="btnexportXLS" runat="server" Text="Exportar XLS" class="btn btn-primary">
                <i class="fa fa-file-excel-o"></i> Exportar XLS
            </asp:LinkButton>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-2 col-lg-2">
            <asp:LinkButton ID="btnexportPDF" runat="server" Text="Exportar PDF" class="btn btn-primary">
                <i class="fa fa-file-pdf-o"></i> Exportar PDF
            </asp:LinkButton>
        </div>
    </div>

</asp:Content>

