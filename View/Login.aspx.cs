using LojaWeb.Business;
using LojaWeb.Data;
using LojaWeb.Entity;
using LojaWeb.View;
using LojaWeb.Functions;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaWeb
{
    public partial class Login : System.Web.UI.Page
    {
        Conexao conexao = new Conexao();
        LoginBLL loginBll = new LoginBLL();
        LoginENT loginEnt = new LoginENT();
        Funcoes funcoes = new Funcoes();
 
        private void LimparCampos()
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
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
        protected void btnEntrar_Click(object sender, EventArgs e)
        {                                    
            if (txtUsuario.Text == "")
            {
                Alerta("alerta posicao atencao", "Informe o usuário!");
                txtUsuario.Focus();
            }
            else if (txtSenha.Text == "")
            {
                Alerta("alerta posicao atencao", "Informe uma senha válida!");
                txtSenha.Focus();
            }
            else
            {
                loginEnt.usuario = txtUsuario.Text;
                loginEnt.senha = txtSenha.Text;
                string retorno = loginBll.VerificarUsuario(loginEnt);
                switch(retorno)
                {
                    case "1":
                        Session.Timeout = 120;
                        Session["usuario"] = loginEnt.usuario;
                        Response.Redirect("/View/Principal.aspx");
                        break;
                    case "0":
                        Alerta("alerta posicao atencao", "Usuário e senha não conferem!");
                        LimparCampos();
                        break;
                    default:
                        Alerta("alerta posicao perigo", "Não foi possível logar no sistema! Entre em contato com o administrador.");
                        break;
                }
            }
        }
    }
}


//System.Diagnostics.Process.Start("~/View/frmPrincipal.aspx"); >>isto abre a página padrão o iis com uma msg de erro:

//Response.Redirect("/View/C_Usuario.aspx");   >> como chamar uma página


//login.usuario = txtUsuario.Text;
//login.senha = txtSenha.Text;
//retorno = loginBLL.VerificarLogin(login);
//if ((retorno == "true") && (login.usuario == txtUsuario.Text) && (login.senha == txtSenha.Text))
//{
//    string maquina = funcoes.VerificarMaquina();
//    if (maquina != "ALCS")
//    {
//        MessageBox.Show("Sua máquina não tem permissão para acesso! Favor contatar o administrador do sistema.", "Importante!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//    }
//    else
//    {
//        if (login.situacao != 1)
//        {
//            MessageBox.Show("O funcionário " + login.usuario + " foi demitido, afastado ou está inativo!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            txtUsuario.Focus();
//        }
//        else
//        {
//            try
//            {
//                login.versao = funcoes.GetVersion();
//                login.data_ult_login = DateTime.Now;
//                login.maquina = maquina;
//                retorno = string.Empty;
//                retorno = loginBLL.InserirUsuario(login);
//                int codigo = Convert.ToInt32(retorno); //se não conseguir converter é pq deu erro                             
//                FrmMDI principal = new FrmMDI();
//                principal.Show();
//                this.Hide();
//            }
//            catch
//            {
//                MessageBox.Show("Não foi possível conectar com o banco de dados. Detalhe: " + retorno, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//            }
//        }
//    }
//}
//else
//{
//    MessageBox.Show("Informe um usuário e senha válidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
//    txtUsuario.Focus();
//}