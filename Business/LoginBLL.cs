using LojaWeb.Data;
using LojaWeb.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace LojaWeb.Business
{
    public class LoginBLL
    {
        Conexao conexao = new Conexao();
        public string achou = "0";
        public string VerificarUsuario(LoginENT login)
        {
            try
            {
                conexao.LimparParametros();
                conexao.AdicionarParametros("@usuario", login.usuario);
                conexao.AdicionarParametros("@senha", login.senha);

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT u.Codigo,u.Usuario,u.Senha,u.Grupo AS 'Cod. Grupo',g.Grupo,u.Data_Cadastro,  ");
                sql.AppendLine("u.Data_Atualizacao,u.Maquina,u.Versao,u.Data_Ult_Login,u.Ativo FROM usuario u ");
                sql.AppendLine("INNER JOIN Usuario_Grupo g ON u.Grupo = g.Codigo ");
                sql.AppendLine("WHERE Usuario = @usuario AND Senha = @senha");



                DataTable dt = conexao.Consultar(CommandType.Text, Convert.ToString(sql));
                foreach (DataRow dr in dt.Rows)
                {
                    login.codigo = Convert.ToInt16(dr["Codigo"]);
                    login.usuario = dr["Usuario"].ToString();
                    login.senha = dr["Senha"].ToString();
                    login.cod_grupo = Convert.ToInt16(dr["Cod. Grupo"]);
                    login.grupo = dr["Grupo"].ToString();                    
                    login.data_cadastro = Convert.ToDateTime(dr["Data_Cadastro"]);
                    login.data_atualizacao = Convert.ToDateTime(dr["Data_Atualizacao"]);
                    login.maquina = dr["Maquina"].ToString();
                    login.versao = dr["Versao"].ToString();
                    login.data_ult_login = Convert.ToDateTime(dr["Data_Ult_Login"]);                    
                    login.ativo = Convert.ToBoolean(dr["Ativo"]);

                    //login.cod_empresa = Convert.ToInt16(dr["Cod. Empresa"]);
                    //login.empresa = dr["Empresa"].ToString();
                    return achou = "1";
                }
                return achou = "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string InserirUsuario(LoginENT login)
        {
            try
            {
                conexao.LimparParametros();
                conexao.AdicionarParametros("@codigo", login.codigo);
                conexao.AdicionarParametros("@usuario", login.usuario);
                conexao.AdicionarParametros("@ativo", login.ativo);
                conexao.AdicionarParametros("@grupo", login.grupo);
                conexao.AdicionarParametros("@empresa", login.empresa);                
                conexao.AdicionarParametros("@versao", login.versao);
                conexao.AdicionarParametros("@maquina", login.maquina);
                conexao.AdicionarParametros("@data", login.data_ult_login);
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Temp (Codigo, Usuario, Ativo, Grupo, Empresa, Maquina, Versao, Data) ");
                sql.AppendLine("VALUES(@codigo,@usuario,@ativo,@grupo,@empresa,@maquina,@versao, @data) ");
                sql.AppendLine("SELECT Codigo FROM Temp WHERE Usuario = @usuario");
                string codigo = conexao.Manipular(CommandType.Text, Convert.ToString(sql)).ToString();
                return codigo;
                // >> inserir usuário logado no controle, USAR QDO FINALIZAR O SISTEMA
                //conexao.LimparParametros();
                //conexao.AdicionarParametros("@codigo", login.codigo);
                //conexao.AdicionarParametros("@usuario", login.usuario);
                //conexao.AdicionarParametros("@maquina", login.maquina);
                //conexao.AdicionarParametros("@versao", login.versao);
                //StringBuilder sql = new StringBuilder();
                //sql.AppendLine("INSERT INTO Funcionario_Controle (Cod_Funcionario, Funcionario, Maquina, Data_Acesso, Versao) ");
                //sql.AppendLine("VALUES(@codigo, @usuario, @maquina, GETDATE(), @versao)");
                //conexao.Manipular(CommandType.Text, Convert.ToString(sql)).ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}