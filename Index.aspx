<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

<meta charset="UTF-8">
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Sistema de Apartados</title>
    <link rel="shortcut icon" href="img/login-logo.png"/>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/checkbox.css" type="text/css" media="screen" charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="css/jquery.datetimepicker.css"/>
    <link rel="stylesheet" type="text/css" href="css/messi.css" />
    <link href="css/basics.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="css/newstyle.css" />
    <link href="https://fonts.googleapis.com/css?family=Roboto" type="text/css" rel="stylesheet">
    <script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/iphone-style-checkboxes.js" type="text/javascript" charset="utf-8"></script>  
    <script type="text/javascript" src="js/Radios.js"></script>
    <script type="text/javascript" src="js/jquery.datetimepicker.js"></script>
    <script type="text/javascript" src="js/messi.js"></script>
    <script type="text/javascript" src="js/jquery.blockUI.js"></script>
    <script src="js/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="scripts/MasterPage.js" type="text/javascript"></script>

    <!--LIBRERIAS -->
    <link rel="stylesheet" type="text/css" href="estilo.css">
 	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    
    <script src="scripts/MasterPage.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <!-- TOGGLE -->
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.2/css/bootstrap-toggle.min.css" rel="stylesheet">
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.2/js/bootstrap-toggle.min.js"></script>
	
	<!-- Optional theme -->
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
	
</head>
<body >
    <!--HEADER-->
    <form id="form1" runat="server">
        <input type="hidden" value="false" name="_parametro" id="_parametro" />
           <div id="topEmpleados">
            <div id="logo-comun">
                <img src="img/LOGO-ITSONUNIVERSIDAD.png">
            </div>
            <p id="titleSystem_header">Sistema de Apartados</p>
            <p id="subtitle_header">INSTITUTO TECNOLOGICO DE SONORA</p>
           </div>
        <!--FIN HEADER-->
       <div style="margin-top:150px">
        <div class="container">
            <div class="row">
                <div class="col-xs-0 col-sm-3 col-md-4 col-lg-4"></div>
                <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                    <asp:Label ID="Label1" runat="server" Text="ID de Usuario"></asp:Label>
                    <asp:TextBox ID="txtUSUARIO" runat="server" CssClass="form-control" placeholder="Ingrese el ID de usuario" autocompletetype="Disabled" required></asp:TextBox>
                     <asp:Label ID="Label2" runat="server" Text="NIP"></asp:Label>
                    <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" placeholder="Ingrese el NIP" TextMode="Password" autocompletetype="Disabled" required></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-xs-0 col-sm-3 col-md-4 col-lg-4"></div>
                <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                    <asp:Button ID="btnLogin" runat="server" Text="INICIAR SESION" 
                        CssClass="btn btn-primary btn-block" onclick="btnLogin_Click"  />
                </div>
            </div>
        </div>
        </div>
    </form>
    <!--FOOTER-->
    <div class="help">
        <div class="hvr-fade">
            <a>
                <i class="select fa fa-question-circle fa-2x" aria-hidden="true"></i>
            </a>
        </div>
        <div class="hvr-fade">
            <a>
                <i class="select fa fa-envelope-o fa-2x" aria-hidden="true"></i>
            </a>
        </div>
    </div>
    <footer>
        <div class="footer">
            <div class="text-footer" style="float:left;">
                <p>© DTSI - Departamento de Tecnologías y Servicios Informáticos</p>
            </div>

            <div class="text-footer" style="float:right;">
                <p>Navegadores soportados:
                <img class="imgNav" src="img/chrome.png" />
                <img class="imgNav" src="img/firefox.png"/>
                <img class="imgNav" src="img/safari.png"/>
                <img class="imgNav" src="img/iexplorer.png"/>
            </div>
        </div>
    </footer>
    <!--FIN FOOTER-->    
</body>
</html>


