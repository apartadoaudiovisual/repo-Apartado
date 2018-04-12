<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="usuarios.aspx.cs" Inherits="usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script type="text/javascript" language="javascript" src="scripts/usuarios.js">  </script>



    <div class="row1">

        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="ViewUsuariosRegistrados" runat="server">
            <h4><asp:Label ID="Label1" runat="server" Text="&nbsp Usuarios Registrados"></asp:Label></h4>
        <div align="right" id="BuscarEnGrid" runat="server">
            Buscar Empleado:
            <input type="text" id="FilterTextBox" name="FilterTextBox" />  
       </div> 
    </div>

         
    <div class="divGrid scroll">
        <asp:Label ID="lblUsuarioeliminar" runat="server" Visible="False"></asp:Label>
             <asp:GridView ID="GridUsuarios" runat="server" AutoGenerateColumns="False" 
                 CssClass="grid" onrowcommand="GridUsuarios_RowCommand" 
                 onselectedindexchanged="GridUsuarios_SelectedIndexChanged">
                 <Columns>
                     <asp:BoundField DataField="emplid" HeaderText="ID" />
                     <asp:BoundField DataField="nombre" HeaderText="nombre">
                         <ControlStyle Width="100px" />
                     </asp:BoundField>
                  </Columns>
             </asp:GridView>
    </div>

    <div class="btn-form">
            <asp:LinkButton ID="Button1" runat="server" Text="Nuevo Usuario" class="btn btn-primary" onclick="Button1_Click">
            <i class="glyphicon glyphicon-plus"></i>    Nuevo Usuario 
            </asp:LinkButton>

            <asp:LinkButton ID="btnexporToexcel" runat="server" Text="Exportar a excel" class="btn btn-primary" onclick="btnexporToexcel_Click">
                      <i class="fa fa-file-excel-o"></i>    Exportar XLS
                  </asp:LinkButton>
     </div>






            </asp:View>
            <asp:View ID="ViewAgregarUsuario" runat="server">
            <h4>Buscar Empleado</h4>

               <div class="col-lg-4">
               <asp:Label ID="lblEmpleado" data-placeholder="Seleccione un empleado..." runat="server" Text=""></asp:Label>
               <asp:DropDownList ID="DropEmpleados" runat="server" class="form-control chzn-select" >
               </asp:DropDownList>
            </div><br />

            <div class="btn-form">
                   <asp:LinkButton ID="BtnAgregar" runat="server" Text="Agregar" class="btn btn-primary" onclick="BtnAgregar_Click">
                       <i class="glyphicon glyphicon-plus"></i>    Nuevo Usuario 
                   </asp:LinkButton>
               </div>
            </asp:View>
        </asp:MultiView>
   
</div>


</asp:Content>

