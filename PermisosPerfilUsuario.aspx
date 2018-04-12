<%@ Page Title="Permisos para los perfiles de usuario" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PermisosPerfilUsuario.aspx.cs" Inherits="PermisosPerfilUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" language="javascript" src="scripts/permisos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="row">
    <div class="col-lg-4">
        <asp:Label ID="Label1" runat="server" Text="Ingresar id del empleado para asignar permisos" ></asp:Label>
               <asp:DropDownList ID="DropPerfiles" runat="server" 
                       class="form-control chzn-select" >
               </asp:DropDownList>


                 <asp:LinkButton ID="btnbuscarEmpleado" runat="server" Text="Buscar" class="btn btn-primary" onclick="btnbuscarEmpleado_Click" >
            <i class="glyphicon glyphicon-search"></i>    Buscar Permisos
         </asp:LinkButton>
 
    </div>
     <div class="col-lg-8">
         <asp:Label ID="lblidrol" runat="server" Text=""></asp:Label><br />
         <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label><br />      
    </div>
    </div>
 <div class="row">

<div id="tablaPermisos" runat="server" visible="false">
  <div align="right" class="divFiltro" >
    <div align="right" style="width:200px"> 
        <asp:Label ID="Label9" runat="server" Text="Filtro:"></asp:Label> 
         <input type="text" id="FilterTextBox" name="FilterTextBox" />
    </div>
 </div>
<div class="divGrid scroll">  
<asp:GridView ID="GridView1" runat="server" name="GridView1" class="grid" 
        AutoGenerateColumns="False">
 <Columns>
        <asp:BoundField DataField="Menu" HeaderText="categoria" />
        <asp:BoundField DataField="iditem" HeaderText="no. permiso" />
        <asp:BoundField DataField="nombre" HeaderText="nombre" />
        <asp:TemplateField>
                <ItemTemplate>
                   
                   <asp:CheckBox runat="server" ID="chkpermiso" CssClass="" />
                 
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
</asp:GridView>
</div>
</div>
<div>

   
 </div>

 </div>
 
     <div class="btn-form">   
         <asp:LinkButton ID="btncancelar" runat="server" Text="Cancelar" class="btn btn-primary" onclick="btncancelar_Click" Visible="False">
            <i class="glyphicon glyphicon-remove"></i>    Cancelar
         </asp:LinkButton> 
       
         <asp:LinkButton ID="btnregistrar" runat="server" Text="Guardar" class="btn btn-primary" onclick="btnregistrar_Click" Visible="False" >
            <i class="fa fa-floppy-o"></i>    Guardar
         </asp:LinkButton>
     </div>


</asp:Content>

