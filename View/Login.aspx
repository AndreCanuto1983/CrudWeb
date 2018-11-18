<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LojaWeb.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
    <meta name="viewport" charset="utf-8" content="width=device-width, initial-scale=0.8">
    <link rel="stylesheet" href="Css/Login.css" />
    <link rel="stylesheet" href="Css/Botoes.css" />
    <link rel="stylesheet" href="Css/Alertas.css" />
    <link rel="stylesheet" href="Css/Layout.css" />
    <script type="text/javascript" src="Js/Validacoes.js"> </script> <!--Obrigatório usar para fechar o alerta -->

</head>
<body class="fundo">
    <!--Utilizo para mastrar mensagens-->
    
    <div runat="server" id="DivAlert" onclick="fecharAlerta()"></div>    

    <div class="estiloLogin">
        <form id="frmLogin" runat="server" method="post">
            <h2 class="h2">Login</h2>
            <br>
            <asp:TextBox type="text" ID="txtUsuario" name="txtUsuario" CssClass="txtBoxLogin" placeholder="Usuário" MaxLength="20" runat="server" title="Informe um usuário válido"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox type="password" ID="txtSenha" name="txtSenha" CssClass="txtBoxLogin" placeholder="Senha" MaxLength="8" runat="server" title="Informe uma senha válida"></asp:TextBox>
            <br />
            <br />
            <div>
                <asp:Button ID="btnEntrar" CssClass="botoes" runat="server" Text="Entrar" title="Entre no sistema" onSubmit="validaCampos" OnClick="btnEntrar_Click" />
            </div>
        </form>

    </div>
</body>
</html>

<!--Style="text-transform: uppercase;"   isto transforma tudo em maiúsculo-->
<!--title="Informe um usuário válido"  usando isto dentro de um textbox será exibido um tolltip do campo-->
<!-- Style="text-transform: uppercase;"  usa-se para deixar o campo em maiúsculo -->
<!--box-shadow: 15px 15px 20px grey;   utilizo para inserir sombra nos componentes via css-->
