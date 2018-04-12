<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRE-CIA.aspx.cs" Inherits="PRE_CIA" %>

<!DOCTYPE>
<html>
<head>
<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	
    <link href="css/precia.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="path/to/font-awesome/css/font-awesome.min.css">


    <title>PRE CIA ITSON</title>
</head>
<body>
 
    <form runat="server">
      
           <div class="limiter">
    <!-- <img src="../ITSON MARCA.png" id="logoITSON"/> -->
		<div class="container-login">
			<div class="wrap-login">
            
              <!-- Aquí se muestra el acceso -->

			   <form class="login-form validate-form">
                
                <!-- <img src="../../ITSON-MARCA.png" width="70%" style="padding-bottom:50px;"/>-->
               <img src="img/CIA-color.png" /><br/><br/>
                   	<div class="wrap-input validate-input" data-validate = "Ejemplo de e-mail: usuario@empresa.com">
						<input class="input" type="text" name="user" placeholder="Ingresar ID ITSON de 11 dígitos" maxlength="11">
						<span class="focus-input"></span>
						<span class="symbol-input">
							<i class="fa fa-user fa-lg" aria-hidden="true"></i>
						</span>
					</div>
					
					<div class="container-login-form-btn">
						<button class="login-form-btn">
							Iniciar Sesión
						</button>
					</div>

					<div class="text-password">
						<span class="txt1">
							¿Has olvidado tu
						</span>
						<a class="txt2" href="http://smartweb1.itson.edu.mx:8700/psp/ITSONPRD/EMPLOYEE/HRMS/c/MAINTAIN_SECURITY.EMAIL_PSWD.GBL?FolderPath=PORTAL_ROOT_OBJECT.PT_TOOLS_HIDDEN.PT_EMAIL_PSWD_GBL&IsFolder=false&IgnoreParamTempl=FolderPath%2cIsFolder" target="_blank">
							Usuario / Contraseña?
						</a>
					</div>

				</form>
                
                <!-- Aquí se muestra la imagen de la app -->
                	<div class="login-pic">
                    <img src="img/SCREENSHOTS-PPLAYSTORE-BACKBLUE2.png" alt="IMG"/>
					                    
                    <div class="playstore">
                    	<p id="playstore-text">Encuentra la nueva APP exclusiva de alumnos ITSON</p><br/>
						<a href="https://play.google.com/store/apps/details?id=mx.itson.potrosapp" target="_blank" class="hvr-float-shadow">
                            <img src="img/googleplay.png" />
                        </a>
                    </div>
				</div>
                
			</div>
		</div>
	</div>
        
        <footer>
</form>
   
   <!-- Start of admisionesitson Zendesk Widget script -->
<iframe src="javascript:false" title="" style="display: none;"></iframe><script>/*<![CDATA[*/window.zEmbed||function(e,t){var n,o,d,i,s,a=[],r=document.createElement("iframe");window.zEmbed=function(){a.push(arguments)},window.zE=window.zE||window.zEmbed,r.src="javascript:false",r.title="",r.role="presentation",(r.frameElement||r).style.cssText="display: none",d=document.getElementsByTagName("script"),d=d[d.length-1],d.parentNode.insertBefore(r,d),i=r.contentWindow,s=i.document;try{o=s}catch(e){n=document.domain,r.src='javascript:var d=document.open();d.domain="'+n+'";void(0);',o=s}o.open()._l=function(){var o=this.createElement("script");n&&(this.domain=n),o.id="js-iframe-async",o.src=e,this.t=+new Date,this.zendeskHost=t,this.zEQueue=a,this.body.appendChild(o)},o.write('<body onload="document._l();">'),o.close()}("https://assets.zendesk.com/embeddable_framework/main.js","admisionesitson.zendesk.com");
/*]]>*/</script>
<!-- End of admisionesitson Zendesk Widget script -->


<div><iframe id="launcher" tabindex="0" class="zEWidget-launcher zEWidget-launcher--active" style="border: none; background: transparent; z-index: 999998; transform: translateZ(0px); position: fixed; opacity: 1; right: 0px; bottom: 0px; width: 125px; height: 47px; margin: 10px 20px;"></iframe></div><div><iframe id="webWidget" tabindex="-1" class="zEWidget-webWidget " style="border: none; background: transparent; z-index: 999999; transform: translateZ(0px); position: fixed; opacity: 0; right: 0px; bottom: 0px; width: 357px; margin-left: 15px; margin-right: 15px; height: 15px; transition-property: none; transition-timing-function: unset; top: -9999px;"></iframe></div></body>
    </form>

</footer>
</body>
</html>
