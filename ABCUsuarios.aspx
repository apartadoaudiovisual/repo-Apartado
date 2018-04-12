<%@ Page Title="ABC USUARIOS" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABCUsuarios.aspx.cs" Inherits="ABCUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:MultiView ID="MultiView1" runat="server">
      <asp:View ID="Viewbusqueda" runat="server">
         <div class="row">
            <div class="col-md-3">
               <asp:Label ID="lblEmpleado" data-placeholder="Seleccione un empleado..." runat="server" Text="&nbsp Buscar Empleado">
               </asp:Label>

               <asp:DropDownList ID="DropEmpleados" runat="server" 
                  class="form-control chzn-select" 
                  onselectedindexchanged="DropEmpleados_SelectedIndexChanged" 
                  AutoPostBack="True">
               </asp:DropDownList>
            
            </div>

            <div class="btn-form">
                 <asp:LinkButton ID="LinkButton1" runat="server" Text="Nuevo Usuario" class="btn btn-primary" onclick="BtnAgregar_Click">
                 <i class="glyphicon glyphicon-plus"></i>    Nuevo Usuario
                 </asp:LinkButton>
            </div>
         </div>
      </asp:View>


      <asp:View ID="ViewUsuarios" runat="server">
        <div class="textABCusers">
            <div class="gralABC">
             <div class="col-lg-2">
                <asp:Label ID="Label1" runat="server" Text="Emplid"></asp:Label>
                <asp:TextBox ID="txtEmplid" runat="server" class="form-control" ></asp:TextBox>
             </div>

             <div class="col-lg-5">
                <asp:Label ID="Label3" runat="server" Text="Apellidos"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
             </div>

             <div class="col-lg-5">
                <asp:Label ID="Label5" runat="server" Text="Telefono"></asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server" class="form-control"></asp:TextBox><br /> 
             </div>
        </div>
         

         <div class="row">
            <div class="col-md-3">
               <asp:Label ID="Label2" runat="server" Text="Campus"></asp:Label>
               <asp:DropDownList ID="DropCampus" runat="server" class="form-control">
                  <asp:ListItem>Seleccionar</asp:ListItem>
                  <asp:ListItem Value="00001">Obregón Centro</asp:ListItem>
                  <asp:ListItem Value="00002">Obregón Nainari</asp:ListItem>
                  <asp:ListItem Value="00003">Guaymas</asp:ListItem>
                  <asp:ListItem Value="00005">Empalme</asp:ListItem>
                  <asp:ListItem Value="00006">Navojoa</asp:ListItem>
               </asp:DropDownList>
               <br />
            </div>

            <div class="col-lg-2">
               <asp:Label ID="Label4" runat="server" Text="Fecha:"></asp:Label>
               <asp:TextBox ID="txtFechaalta" runat="server" class="form-control Fecha" required></asp:TextBox>
               <br />
            </div>
         </div>

       

         <div class="row">
            <div class="col-md-3">
               <h4>Sexo</h4>
               <asp:RadioButtonList ID="RadioSex" runat="server" class="css-checkbox css-label radGroup1 radGroup1">
                  <asp:ListItem Value="F">   Femenino</asp:ListItem>
                  <asp:ListItem Value="M">   Masculino</asp:ListItem>
               </asp:RadioButtonList>
               <br />
            </div>
         </div>

         <div class="btn-form">
         
         <div class="gralABC">
             <asp:LinkButton ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-primary" onclick="BtnGuardar_Click" >
                <i class="fa fa-floppy-o"></i>    Guardar
             </asp:LinkButton>
         </div>
         </div>
            
         </div>
      </asp:View>
   </asp:MultiView>
</asp:Content>