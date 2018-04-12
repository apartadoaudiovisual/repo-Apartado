<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="permisos.aspx.cs" Inherits="permisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <script type="text/javascript" language="javascript" src="scripts/permisos.js"></script>

 <div class="row">
    <div class="col-lg-5">
        <asp:Label ID="Label1" runat="server" Text="Ingresar id del empleado para asignar permisos" ></asp:Label>
               <asp:DropDownList ID="DropUsuarios" runat="server" 
                       class="form-control chzn-select" >
               </asp:DropDownList>


                 <asp:LinkButton ID="btnbuscarEmpleado" runat="server" Text="
            &lt;i class=&quot;glyphicon glyphicon-search&quot;&gt;&lt;/i&gt;    Ver Permisos
         " class="btn btn-primary" onclick="btnbuscarEmpleado_Click" ></asp:LinkButton>

              <asp:LinkButton ID="btnbuscaRol" runat="server" 
            Text="Buscar perfil de usuario" class="btn btn-primary" 
            onclick="btnbuscaRol_Click"  >
            <i class="glyphicon glyphicon-search"></i>    Buscar perfil de usuario
         </asp:LinkButton>
 
    </div>
     <div class="col-lg-8">
         <asp:Label ID="lblemplid" runat="server" Text=""></asp:Label><br />
         <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
         <br />
         <asp:Label ID="lblperfil" runat="server"></asp:Label>
         <br />      
    </div>
    </div>
 <div class="row">
     <asp:MultiView ID="MultiView1" runat="server">
         <asp:View ID="View_permisosDeUsuario" runat="server">
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


         </asp:View>
         <asp:View ID="View_PerfilDeUsuario" runat="server">
 seleccionar el perfil de usuario
                    <div class="divGrid scroll">
                   
                                <asp:GridView ID="GridView2" runat="server" name="GridView1"  AutoGenerateColumns="False" Width="400px" 
                            CellPadding="4" ForeColor="#333333" GridLines="None">
                                             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                             <Columns>
                                                    <asp:BoundField DataField="idRol" HeaderText="Cve perfil" />                
                                                    <asp:BoundField DataField="nombreRol" HeaderText="nombre" />
                                                    <asp:TemplateField>
                                                            <ItemTemplate>
                   
                                                               <asp:CheckBox runat="server" ID="chkactivo" CssClass="" />
                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                             <EditRowStyle BackColor="#999999" />
                                             <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                             <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                             <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                             <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                             <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                             <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                             <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>

                    </div>


         </asp:View>

     </asp:MultiView>








<div>

   
    <br />

   
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

