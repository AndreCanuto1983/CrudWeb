<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal_.aspx.cs" Inherits="LojaWeb.View.Principal_" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" charset="utf-8" content="width=device-width, initial-scale=0.8" />
    <title>Principal</title>
    <link rel="stylesheet" href="Css/Botoes.css" />
    <link rel="stylesheet" href="Css/Menu.css" />
    <link rel="stylesheet" href="Css/MenuEssencial.css" />
    <link rel="stylesheet" href="Css/Layout.css" />
</head>
<body class="fundo">
    <div class="posicao">
        <div class="navbar">
            <a href="#home">Home</a>

            <div class="dropdown">
                <button class="dropbtn">Administrativo<i class="fa"></i></button>
                <div class="dropdown-content">
                    <a href="#">Relação de Vendas no período</a>
                    <a href="#">Relação de Vendas por Cliente</a>
                    <a href="#">Relação de vendas por Produto</a>
                    <a href="#">Relação de vendas por Vendedor</a>
                </div>
            </div>

            <div class="dropdown">
                <button class="dropbtn">RH<i class="fa"></i></button>
                <div class="dropdown-content">
                    <a href="#">Cadastro de Usuário</a>
                    <a href="#">Cadastro de Funcionário</a>
                    <a href="#">Cadastro de Ponto</a>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
