using LojaWeb.Business;
using LojaWeb.Data;
using LojaWeb.Entity;
using LojaWeb.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace LojaWeb.Business
{
    public class C_UsuarioBLL
    {
        Conexao conexao = new Conexao();

        public string Consultar(C_UsuarioENT usuario, string pesquisar)
        {
            string achou = "0";
            switch (pesquisar)
            {
                case "codigo":
                    try
                    {
                        conexao.LimparParametros();
                        conexao.AdicionarParametros("@codigo", usuario.codigo);
                        StringBuilder sql = new StringBuilder();
                        sql.AppendLine("SELECT * FROM Usuario WHERE Codigo = @codigo");
                        DataTable dt = conexao.Consultar(CommandType.Text, Convert.ToString(sql));
                        foreach (DataRow dr in dt.Rows)
                        {
                            usuario.codigo = Convert.ToInt16(dr["Codigo"]);
                            usuario.usuario = dr["Usuario"].ToString();
                            usuario.senha = dr["Senha"].ToString();
                            usuario.cod_grupo = Convert.ToInt16(dr["Grupo"]);
                            usuario.grupo = dr["Grupo"].ToString();
                            usuario.cod_empresa = Convert.ToInt16(dr["Empresa"]);
                            usuario.empresa = dr["Empresa"].ToString();
                            usuario.data_cadastro = Convert.ToDateTime(dr["Data_Cadastro"]);
                            usuario.data_atualizacao = Convert.ToDateTime(dr["Data_Atualizacao"]);
                            usuario.maquina = dr["Maquina"].ToString();
                            usuario.versao = dr["Versao"].ToString();
                            usuario.data_ult_login = Convert.ToDateTime(dr["Data_Ult_Login"]);
                            usuario.aprovado = Convert.ToBoolean(dr["Aprovado"]);
                            achou = "1";
                        }
                        return achou;
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    break;

                case "nome":
                    try
                    {
                        conexao.LimparParametros();
                        conexao.AdicionarParametros("@usuario", usuario.usuario);
                        StringBuilder sql = new StringBuilder();
                        sql.AppendLine("SELECT * FROM Usuario WHERE Usuario = @usuario");
                        DataTable dt = conexao.Consultar(CommandType.Text, Convert.ToString(sql));
                        foreach (DataRow dr in dt.Rows)
                        {
                            usuario.codigo = Convert.ToInt16(dr["Codigo"]);
                            usuario.usuario = dr["Usuario"].ToString();
                            usuario.senha = dr["Senha"].ToString();
                            usuario.cod_grupo = Convert.ToInt16(dr["Grupo"]);
                            usuario.grupo = dr["Grupo"].ToString();
                            usuario.cod_empresa = Convert.ToInt16(dr["Empresa"]);
                            usuario.empresa = dr["Empresa"].ToString();
                            usuario.data_cadastro = Convert.ToDateTime(dr["Data_Cadastro"]);
                            usuario.data_atualizacao = Convert.ToDateTime(dr["Data_Atualizacao"]);
                            usuario.maquina = dr["Maquina"].ToString();
                            usuario.versao = dr["Versao"].ToString();
                            usuario.data_ult_login = Convert.ToDateTime(dr["Data_Ult_Login"]);
                            usuario.aprovado = Convert.ToBoolean(dr["Aprovado"]);
                            achou = "1";
                        }
                        return achou;
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    break;                

                default:
                    return "Informe as palavras chave 'codigo' ou 'nome' para pesquisar por código ou por nome";
                    break;
            }            
        }
        public string Deletar(C_UsuarioENT usuario)
        {
            string excluido = "0";
            try
            {
                conexao.LimparParametros();
                conexao.AdicionarParametros("@codigo", usuario.codigo);
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE Usuario WHERE Codigo = @codigo");
                conexao.Manipular(CommandType.Text, Convert.ToString(sql));
                return excluido = "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Gravar(C_UsuarioENT usuario, string acao)
        {
            switch (acao)
            {
                case "gravar":
                    try
                    {
                        conexao.LimparParametros();
                        conexao.AdicionarParametros("@codigo", usuario.codigo);
                        conexao.AdicionarParametros("@usuario", usuario.usuario);
                        conexao.AdicionarParametros("@senha", usuario.senha);
                        conexao.AdicionarParametros("@grupo", usuario.grupo = "1");
                        conexao.AdicionarParametros("@situacao", usuario.ativo);
                        conexao.AdicionarParametros("@empresa", usuario.empresa = "1");
                        //conexao.AdicionarParametros("@data_cadastro", usuario.data_cadastro);
                        //conexao.AdicionarParametros("@data_atualizacao", usuario.data_atualizacao);
                        conexao.AdicionarParametros("@maquina", usuario.maquina);
                        conexao.AdicionarParametros("@versao", usuario.versao);
                        //conexao.AdicionarParametros("@data_ult_login", usuario.data_ult_login);
                        StringBuilder sql = new StringBuilder();
                        sql.AppendLine("INSERT INTO Usuario (Usuario,Senha,Grupo,Empresa,Data_Cadastro, ");
                        sql.AppendLine("data_atualizacao,maquina,versao,data_ult_login) ");
                        sql.AppendLine("VALUES (@usuario,@senha,@grupo,@empresa,GETDATE(),GETDATE(),@maquina, ");
                        sql.AppendLine("@versao,GETDATE()) ");
                        sql.AppendLine("SELECT @@IDENTITY AS retorno");
                        string gravou = conexao.Manipular(CommandType.Text, Convert.ToString(sql)).ToString();
                        return gravou; //me retorna o código do registro gravado
                    }
                    catch (Exception ex)
                    {
                         return ex.Message;
                    }
                    break;

                case "atualizar":
                    try
                    {
                        conexao.LimparParametros();
                        conexao.AdicionarParametros("@codigo", usuario.codigo);
                        conexao.AdicionarParametros("@usuario", usuario.usuario);
                        conexao.AdicionarParametros("@senha", usuario.senha);
                        conexao.AdicionarParametros("@grupo", usuario.grupo);
                        conexao.AdicionarParametros("@situacao", usuario.ativo);
                        conexao.AdicionarParametros("@empresa", usuario.empresa);
                        //conexao.AdicionarParametros("@data_cadastro", usuario.data_cadastro); Não é necessário
                        //conexao.AdicionarParametros("@data_atualizacao", usuario.data_atualizacao); Não é necessário
                        conexao.AdicionarParametros("@maquina", usuario.maquina);
                        conexao.AdicionarParametros("@versao", usuario.versao);
                        //conexao.AdicionarParametros("@data_ult_login", usuario.data_ult_login); Não é necessário
                        StringBuilder sql = new StringBuilder();
                        sql.AppendLine("UPDATE Usuario SET Usuario = @Usuario, senha = @ Senha, ");
                        sql.AppendLine("Grupo = @grupo, Situacao = @situacao, Empresa = @empresa, ");
                        sql.AppendLine("Data_Atualizacao = GETDATE(), Maquina = @maquina, Versao = @versao, ");
                        sql.AppendLine("WHERE Codigo = @codigo ");
                        sql.AppendLine("SELECT Codigo FROM Usuario WHERE Usuario = @usuario");
                        string gravou = conexao.Manipular(CommandType.Text, Convert.ToString(sql)).ToString();
                        return gravou;
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    break;

                default:
                    return "Informe as palavras chave 'gravar' ou 'atualizar' para gravar ou atualizar um registro no banco";
                    break;
            }           
        }

        /*
        public string CarregarGrade(DataGridView grade)
        {
            string qtd_linhas = "0", sql = null;
            try
            {
                conexao.LimparParametros();
                sql = "SELECT Codigo AS 'Código', Grupo FROM Funcionario_Grupo";
                return qtd_linhas = conexao.PreencherGrade(grade, sql);
            }
            catch (Exception ex)
            {
                grade.Columns.Clear();
                return ex.Message;
            }
        }
        */
    }
}
