<%@ Page Title="" Language="C#" MasterPageFile="~/View/Menu.Master" AutoEventWireup="true" CodeBehind="C_Usuario_antigo.aspx.cs" Inherits="LojaWeb.View.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Título" runat="server">
    <title>Cadastro de Usuário</title>
    <meta name="viewport" charset="utf-8" content="width=device-width, initial-scale=0.8" />
    <link rel="stylesheet" href="Css/C_Usuario.css" />
    <link rel="stylesheet" href="Css/Botoes.css" />
    <link rel="stylesheet" href="Css/Alertas.css" />
    <link rel="stylesheet" href="Css/layout.css" />
    <script type="text/javascript" src="Js/Validacoes.js"> </script> <!--Obrigatório usar para fechar o alerta -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="subCorpo" runat="server">  
    <!--Utilizo para mastrar mensagens-->
    <div runat="server" ID="DivAlert" onclick="fecharAlerta()"></div>

    <div class="estiloC_Usuario" runat="server">
        <form name="frmC_Usuario" method="post" runat="server">
            <h2 class="h2">Cadastro de Usuário</h2>
            <br>
            <asp:TextBox ID="txtCodigo" CssClass="txtBox" placeholder="Código" MaxLength="10" title="Informe o código do usuário" runat="server"> </asp:TextBox><br />
            <br>
            <asp:TextBox ID="txtUsuario" CssClass="txtBox" placeholder="Usuário" MaxLength="20" title="Informe o usuário" runat="server"> </asp:TextBox><br />
            <br />
            <asp:TextBox type="password" ID="txtSenha" CssClass="txtBox" placeholder="Senha" MaxLength="8" title="Informe a senha" runat="server"> </asp:TextBox><br />
            <br />
            <asp:TextBox type="password" ID="txtSenha1" CssClass="txtBox" placeholder="Confirme a senha" MaxLength="8" title="Confirme a senha" runat="server"> </asp:TextBox><br />
            <br />
            <div>
                <asp:Button ID="btnCadUsuario" CssClass="botoes" runat="server" Text="Cadastrar" OnClick="btnCadUsuario_Click"/>
                <asp:Button ID="btnLimparUsuario" CssClass="botoes" runat="server" Text="Limpar" OnClick="btnLimparUsuario_Click" />
            </div>
        </form>
    </div>
</asp:Content>
