using LojaWeb.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LojaWeb.Data
{
    public class Conexao
    {
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        private SqlConnection CriarConexao()
        {
            return new SqlConnection(Settings.Default.stringConexao);
        }

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        public object Manipular(CommandType commandType, string nomeTextoSql)  //inserir, alterar e excluir
        {
            SqlConnection sqlConnection = CriarConexao();  //Criar a conexão
            try
            {
                sqlConnection.Open(); //Abir conexão            
                SqlCommand sqlCommand = sqlConnection.CreateCommand(); //comando que vai levar os dados para o banco                
                sqlCommand.CommandType = commandType;//coloca dados dos parametros dentro do comando para levar para o banco
                sqlCommand.CommandText = nomeTextoSql;
                sqlCommand.CommandTimeout = 600; //o sistema fecha a conexão e exibe um erro (tempo em segunndos = 10 minutos)                
                foreach (SqlParameter sqlParameter in sqlParameterCollection)//Adicionar os parâmetros no comando. Foreach = para cada.
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }
                return sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Dispose();
            }
        }

        public DataTable Consultar(CommandType commandType, string nomeTextoSql) //Consultar registros no banco de dados
        {
            SqlConnection sqlConnection = CriarConexao(); //Criar a conexão  
            try
            {
                sqlConnection.Open(); //Abir conexão
                SqlCommand sqlCommand = sqlConnection.CreateCommand(); //criar o comando que vai levar os dados para o banco                
                sqlCommand.CommandType = commandType; //coloca dados dos parametros dentro do comando para levar para o banco
                sqlCommand.CommandText = nomeTextoSql;
                sqlCommand.CommandTimeout = 500; //o sistema fecha a conexão e exibe um erro(tempo em segundos)
                foreach (SqlParameter sqlParameter in sqlParameterCollection) //Adicionar os parâmetros no comando. Foreach = para cada.
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Dispose();
            }
        }

        //public void PreencherCombo(ComboBox combo, string tabela, string colunaId, string colunaDescricao, string valor = null)
        //{
        //    try
        //    {
        //        string sql = "SELECT * FROM " + tabela + " ORDER BY Codigo ASC";
        //        DataTable dt = Consultar(CommandType.Text, sql);
        //        if (dt.Rows.Count > 0)
        //        {
        //            DataRow row = dt.NewRow();
        //            row[colunaDescricao] = "";
        //            dt.Rows.InsertAt(row, 0); //insiro o valor nulo na combo
        //            combo.DataSource = dt;
        //            combo.ValueMember = colunaId;
        //            combo.DisplayMember = colunaDescricao;
        //            if (valor != null)
        //            {
        //                combo.SelectedValue = valor;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Não foi possível carregar combo! Detalhes: " + ex, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //public string PreencherGrade(DataGridView grade, string sql)
        //{
        //    string qtdLinhas = "0";
        //    try
        //    {
        //        DataTable dt = Consultar(CommandType.Text, sql);
        //        grade.DataSource = dt;
        //        grade.DataMember = dt.TableName;
        //        grade.Update();
        //        grade.Refresh();
        //        qtdLinhas = Convert.ToString(grade.Rows.Count); //Verifico a quantidade de registros retornado
        //        return qtdLinhas;
        //        //limpar grade se necessário: grade.Columns.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        grade.Columns.Clear();
        //        return ex.Message;
        //    }
        //}
    }
}