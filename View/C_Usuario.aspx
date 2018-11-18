<%@ Page Title="" Language="C#" MasterPageFile="~/View/Menu.Master" AutoEventWireup="true" CodeBehind="C_Usuario.aspx.cs" Inherits="LojaWeb.View.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Título" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=0.8">
    <title>Cadastro de Usuário</title>
    <link rel="stylesheet" href="Css/C_Usuario.css" />
    <link rel="stylesheet" href="Css/Botoes.css" />
    <link rel="stylesheet" href="Css/Alertas.css" />
    <link rel="stylesheet" href="Css/layout.css" />
    <script type="text/javascript" src="Js/Validacoes.js"> </script>
    <!--Obrigatório usar para fechar o alerta -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subCorpo" runat="server">
    <!--Utilizo para mastrar mensagens-->
    <div runat="server" id="DivAlert" onclick="fecharAlerta()"></div>

    <div class="estiloC_Usuario" runat="server">
        <form name="frmC_Usuario" method="post" runat="server">
            <h2 class="h2">Cadastro de Usuário</h2>
            <div class="divCampos1">
                <br>
                <asp:TextBox ID="txtCodigo" CssClass="txtBoxC_Usuario" placeholder="Código" MaxLength="10" title="Informe o código do usuário" runat="server"> </asp:TextBox><br />
                <br>
                <asp:TextBox ID="txtUsuario" CssClass="txtBoxC_Usuario" placeholder="Usuário" MaxLength="20" title="Informe o usuário" runat="server"> </asp:TextBox><br />
                <br />
                <asp:TextBox type="password" ID="txtSenha" CssClass="txtBoxC_Usuario" placeholder="Senha" MaxLength="8" title="Informe a senha" runat="server"> </asp:TextBox><br />
                <br />
            </div>

            <div class="divCampos2">
                <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar><br>
                <asp:DropDownList ID="cboGrupo" runat="server" CssClass="comboC_Usuario"></asp:DropDownList><br />
                <br />
                <asp:DropDownList ID="cboEmpresa" runat="server" CssClass="comboC_Usuario"></asp:DropDownList><br />
                <br />
            </div>

            <div class="divBotao">
                <asp:Button ID="btnCadUsuario" CssClass="botoes" runat="server" Text="Cadastrar" OnClick="btnCadUsuario_Click" />
                <asp:Button ID="btnLimparUsuario" CssClass="botoes" runat="server" Text="Limpar" OnClick="btnLimparUsuario_Click" />
                <asp:Button ID="btnVoltar" CssClass="botoes" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            </div>
        </form>
    </div>
</asp:Content>
