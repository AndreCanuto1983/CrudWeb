using LojaWeb.Business;
using LojaWeb.Data;
using LojaWeb.Entity;
using LojaWeb.View;
using LojaWeb.Functions;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaWeb.View
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Conexao conexao = new Conexao();
        Funcoes funcoes = new Funcoes();
        C_UsuarioBLL c_usuarioBLL = new C_UsuarioBLL();
        C_UsuarioENT c_usuarioENT = new C_UsuarioENT();
        private void LimparCampos()
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtSenha1.Text = "";
            txtUsuario.Focus();
        }
        private void Alerta(string css, string msg)
        {
            DivAlert.Attributes["class"] = css; //defino css da div
            DivAlert.InnerText = msg; //defino a mensagem da div

            //como utilizar o sistema de mensagem:
            // use na tela.aspx dentro do body: <div runat="server" id="DivAlert" onclick="fecharAlerta()"></div> <!--Utilizo para mastrar mensagens-->
            // use na tela.aspx <script type="text/javascript" src="Js/Validacoes.js"> </script> <!--Obrigatório usar para fechar o alerta -->
            // use "alerta posicao successo" p/ msg de sucesso: azul, onde, alerta é a msg, posiciona = ajusta a msg e sucesso é a cor azul
            // use "alerta posicao atencao" p/ msg de alerta: amarela
            // use "alerta posicao perigo" p/ msg de atenção: vermelha
            // use "alerta posicao info" p/ msg de informação: azul
        }
        protected void btnCadUsuario_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                Alerta("alerta posicao atencao", "Informe o usuário.");
                txtUsuario.Focus();
            }
            else if (txtSenha.Text == "")
            {
                Alerta("alerta posicao atencao", "Informe uma senha.");
                txtSenha.Focus();
            }
            else if (txtSenha1.Text == "")
            {
                Alerta("alerta posicao atencao", "Confirme a senha.");
                txtSenha1.Focus();
            }
            else if (txtSenha.Text != txtSenha1.Text)
            {
                Alerta("alerta posicao atencao", "As senhas informadas não conferem!");
                txtSenha1.Focus();
            }
            else
            {
                c_usuarioENT.usuario = txtUsuario.Text;
                c_usuarioENT.senha = txtSenha.Text;
                c_usuarioENT.maquina = funcoes.VerificarMaquina();
                c_usuarioENT.versao = funcoes.GetVersion();
                string existe = c_usuarioBLL.Consultar(c_usuarioENT, "nome");
                if (existe == "1")
                {
                    Alerta("alerta posicao atencao", "O usuário " + c_usuarioENT.usuario + " já existe no sistema!");
                }
                else if (existe == "0")
                {
                    string gravar = c_usuarioBLL.Gravar(c_usuarioENT, "gravar");
                    try
                    {
                        Convert.ToInt32(gravar);
                        Alerta("alerta posicao sucesso", "Usuário " + gravar + " gravado com sucesso!");
                        txtCodigo.Text = gravar;
                        LimparCampos();
                    }
                    catch
                    {
                        Alerta("alerta posicao perigo", "Houve uma falha ao gravar o registro! Falha: " + gravar);
                    }
                }
                else
                {
                    Alerta("alerta posicao perigo", "Não foi possível gravar o usuário! Entre em contato com o administrador.");
                }
            }
        }

        protected void btnLimparUsuario_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}