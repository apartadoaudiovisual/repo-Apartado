<%@ Page Title="Perfiles de usuarios" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PerfilUsuario.aspx.cs" Inherits="PerfilUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:MultiView ID="MultiView1" runat="server">
         <asp:View ID="view_tablaPerfiles" runat="server">
             <div class="row">
                <div class="btn-form">
                   <asp:LinkButton ID="BtnAgregar" runat="server" Text="Nuevo perfil" class="btn btn-primary" onclick="BtnAgregar_Click">
                       <i class="glyphicon glyphicon-plus"></i>    Nuevo Perfil 
                   </asp:LinkButton>
               </div>
             </div>
             <div class="row"> 
                    <div class="divGrid scroll">  
                        <asp:GridView ID="GridView1" runat="server" name="GridView1" class="grid" 
                                AutoGenerateColumns="False">
                         <Columns>
                                <asp:BoundField DataField="idRol" HeaderText="Id perfil" />                
                                <asp:BoundField DataField="nombreRol" HeaderText="nombre" />
                                <asp:TemplateField>
                                        <ItemTemplate>
                   
                                           <asp:CheckBox runat="server" ID="chkactivo" CssClass="" />
                 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                        </asp:GridView>
                     </div>

                       <div class="btn-form">   
                             <asp:LinkButton ID="LinkButton1" runat="server" Text="Cancelar" 
                                 class="btn btn-primary" onclick="LinkButton1_Click">
                                <i class="glyphicon glyphicon-remove"></i>    Cancelar
                             </asp:LinkButton> 
       
                             <asp:LinkButton ID="btnregistrarcambios" runat="server" Text="Guardar" 
                                 class="btn btn-primary" onclick="btnregistrarcambios_Click"  >
                                <i class="fa fa-floppy-o"></i>    Guardar cambios
                             </asp:LinkButton>
                         </div>

                 </div>
         </asp:View>
         <asp:View ID="View_nuevoperfil" runat="server">
         <div class="row">
            <div class="col-lg-8">
            Agregar nombre del nuevo perfil
                <asp:TextBox ID="txtnombreperfil" runat="server" class="form-control" 
                    MaxLength="50"></asp:TextBox>
            </div>
           <div class="col-lg-8">
              <asp:Button ID="BtnGuardar" runat="server" Text="Guardar"  
                   class="push_button blue btnSave" onclick="BtnGuardar_Click" />
               <asp:Button ID="btncancelar" runat="server" class="push_button blue btnSave" 
                   Text="Cancelar" onclick="btncancelar_Click" />
           </div>
         </div>
         </asp:View>


    </asp:MultiView>
   
</asp:Content>

