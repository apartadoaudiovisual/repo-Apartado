<%@ Page Title="Empleados" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Consultar_Empleados.aspx.cs" Inherits="Consultar_Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
       $(document).ready(function () {

           $("[id*=GridEmpleados] tr:has(td)").each(function () {
               var t = $(this).text().toLowerCase(); //all row text
               $("<td class='indexColumn'></td>")
          .hide().text(t).appendTo(this);
           }); //each tr
           $("#FilterTextBox").keyup(function () {

               var s = $(this).val().toLowerCase().split(" ");
               if ($(this).val() == "") {
                   s = "";
               }

               $("[id*=GridEmpleados] tr:hidden").show();
               $.each(s, function () {

                   $("[id*=GridEmpleados] tr:visible .indexColumn:not(:contains('"
                  + this + "'))").parent().hide();
               });

           });
       });
        
   </script>
   <asp:MultiView runat="server" ID="MvEmpleados">
      <asp:View ID="viewEmpleados" runat="server">
         <div align="right" id="BuscarEnGrid" runat="server" class="divFiltro">
            Buscar Empleado:
            <input type="text" id="FilterTextBox" name="FilterTextBox" />                   
         </div>
         <div  class="divGrid scroll">
            <asp:GridView ID="GridEmpleados" runat="server" CssClass="grid"  
               AutoGenerateColumns="False" onrowdeleting="GridEmpleados_RowDeleting" 
               onrowupdating="GridEmpleados_RowUpdating">
               <Columns>
                  <asp:BoundField DataField="EMPLID" HeaderText="id" >
                     <ControlStyle Width="100px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="NAME" HeaderText="nombre" >
                     <ControlStyle Width="100px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="SEX" HeaderText="sexo" >
                     <ControlStyle Width="100px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="PHONE" HeaderText="teléfono" >
                     <ControlStyle Width="100px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="CAMPUS_ID" HeaderText="campus" >
                     <ControlStyle Width="100px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="FECHA_ALTA" HeaderText="fecha de alta" >
                     <ControlStyle Width="100px" />
                  </asp:BoundField>
                  
                  <asp:ButtonField ButtonType="Link" CommandName="Update" Text="<i aria-hidden='true' class='glyphicon glyphicon-edit  fa-lg'></i>">
                  </asp:ButtonField>
                  
                   <asp:TemplateField ShowHeader="False">
                       <ItemTemplate>


                       <asp:LinkButton ID="btnBorrar" runat="server" CausesValidation="false" 
                               CommandName="Delete" Text="<i aria-hidden='true' class='glyphicon glyphicon-trash  fa-lg'></i>" 
                               OnClientClick="return confirm('¿Esta seguro que desea eliminar este empleado?');"/>
                               
                       </ItemTemplate>
                                              
                   </asp:TemplateField>

               </Columns>
            </asp:GridView>
         </div>

         <div class="btn-form">
           <asp:LinkButton ID="btnexporToexcel" runat="server" Text="Exportar a excel" onclick="btnexporToexcel_Click"  class="btn btn-primary">
           <i class="fa fa-file-excel-o"></i>    Exportar XLS
           </asp:LinkButton>


           <asp:LinkButton ID="btncorreo" runat="server" Text="Enviar correo" onclick="btncorreo_Click"  class="btn btn-primary">
           <i class="fa fa-envelope"></i>    Enviar correo
           </asp:LinkButton>

         </div>


      </asp:View>
      <asp:View ID="viewEditarEmpleado" runat="server">
         <div class="col-lg-2">
            <asp:Label ID="Label1" runat="server" Text="Emplid"></asp:Label>
            <asp:TextBox ID="txtEmplid" runat="server" class="form-control"></asp:TextBox>
         </div>
         <div class="col-lg-5">
            <asp:Label ID="Label3" runat="server" Text="Apellidos"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
            <br />
         </div>
         <div class="col-lg-5">
            <asp:Label ID="Label5" runat="server" Text="Telefono"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" class="form-control"></asp:TextBox>
            <br />
         </div>
         <div class="row">
            <div class="col-lg-3">
               <asp:Label ID="Label2" runat="server" Text="Cmpus"></asp:Label>
               <asp:DropDownList ID="DropCampus" runat="server" class="form-control">
                  <asp:ListItem>Sleeccionar</asp:ListItem>
                  <asp:ListItem Value="00001">Obregón Centro</asp:ListItem>
                  <asp:ListItem Value="00002">Obregón Nainari</asp:ListItem>
                  <asp:ListItem Value="00003">Guaymas</asp:ListItem>
                  <asp:ListItem Value="00005">Empalme</asp:ListItem>
                  <asp:ListItem Value="00006">Navojoa</asp:ListItem>
               </asp:DropDownList>
               <br />
            </div>
            <div class="col-md-2">
               <asp:Label ID="Label4" runat="server" Text="Fecha:"></asp:Label>
               <asp:TextBox ID="txtFechaalta" runat="server" class="form-control Fecha" required></asp:TextBox>
               <br />
            </div>
         </div>
         <div class="row">
            <div class="col-lg-6">
               <h4>Sexo</h4>
               <asp:RadioButtonList ID="RadioSex" runat="server" class="css-checkbox css-label radGroup1 radGroup1">
                  <asp:ListItem Value="F">Femenino</asp:ListItem>
                  <asp:ListItem Value="M">Masculino</asp:ListItem>
               </asp:RadioButtonList>
               <br />
            </div>
         </div>
         <div class="col-md-3">
            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" 
               class="push_button blue btnSave" onclick="BtnGuardar_Click" />
         </div>
      </asp:View>
   </asp:MultiView>
</asp:Content>



