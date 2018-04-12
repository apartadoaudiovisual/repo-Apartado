<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Enviar_Email.aspx.cs" Inherits="Enviar_Email"   ValidateRequest="false"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

   <div class="col-lg-12">
      <asp:Label ID="Label1" runat="server"></asp:Label>
          <p class="title-sendmail">
            Correo
          </p>
      <asp:TextBox ID="txtCorreo" runat="server" class="form-control"></asp:TextBox>
            
         <div id="sample">
             <script src="JS/Editor/nicEdit.js" type="text/javascript"></script>
   <script type="text/javascript">

                                                                                             bkLib.onDomLoaded(function () { nicEditors.allTextAreas() });
  
  </script>
  
  <p class="title-sendmail">
    Mensaje
  </p>

  <div class="sendmail">
  <textarea id="editor" runat="server" name="area2" style="width: 100%; ">
     
</textarea>

</div><br />
 
</div>
      <div class="btn-form">
         <asp:LinkButton ID="BtnGuardar" runat="server" Text="Enviar correo" class="btn btn-primary" onclick="BtnGuardar_Click">
            <i class="fa fa-envelope" aria-hidden="true"></i>   Enviar Correo
         </asp:LinkButton>
      </div> 
</div>
</asp:Content>