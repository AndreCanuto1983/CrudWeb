using LojaWeb.Business;
using LojaWeb.Data;
using LojaWeb.Entity;
using LojaWeb.View;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace LojaWeb.Functions
{
    public class Funcoes
    {
        Conexao conexao = new Conexao();
        public string GetVersion()
        {
            //pego a versão do assembyInfo, é implementada a cada compilada do sistema
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        public string VerificarMaquina()
        {
            //pego nome da máquina que está acessando o sistema
            string maquina = Environment.MachineName;
            return maquina;
        }
        /*
        public void Alerta(Page tela, string css, string msg)
        {
            tela.DivAlert.Attributes["class"] = css; //defino css da div
            tela.DivAlert.InnerText = msg; //defino a mensagem da div

            //como utilizar o sistema de mensagem:
            // use na tela.aspx dentro do body: <div runat="server" id="DivAlert" onclick="fecharAlerta()"></div> <!--Utilizo para mastrar mensagens-->
            // use na tela.aspx <script type="text/javascript" src="Js/Validacoes.js"> </script> <!--Obrigatório usar para fechar o alerta -->
            // use "alerta posicao successo" p/ msg de sucesso: azul, onde, alerta é a msg, posiciona = ajusta a msg e sucesso é a cor azul
            // use "alerta posicao atencao" p/ msg de alerta: amarela
            // use "alerta posicao perigo" p/ msg de atenção: vermelha
            // use "alerta posicao info" p/ msg de informação: azul
        }
        */
        public void ApenasNumerosTracos(KeyPressEventArgs e)
        {
            // Aceita apenas Numeros, BackSpace, Espaço, enter, tab e traço "-".
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Escape) && !(e.KeyChar == (char)Keys.Enter) && !(e.KeyChar == (char)Keys.Tab) && !(e.KeyChar == '-'))
            {
                e.Handled = true; //usado para não emitir som             
                MessageBox.Show("É permitido apenas números e traços!");  //Se pressionar alguma letra exibirá uma mensagem
            }
        }
        public void ApenasNumeros(KeyPressEventArgs e)
        {
            // Aceita apenas Numeros, BackSpace, Espaço, enter e tab
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Escape) && !(e.KeyChar == (char)Keys.Enter) && !(e.KeyChar == (char)Keys.Tab))
            {
                e.Handled = true;
                MessageBox.Show("Digite apenas números!");  //Se pressionar alguma letra exibirá uma mensagem
            }
        }
        public void ApenasNumerosVirgula(KeyPressEventArgs e)
        {
            // Aceita apenas Numeros, BackSpace, Espaço, enter, tab e virgula.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Escape) && !(e.KeyChar == (char)Keys.Enter) && !(e.KeyChar == (char)Keys.Tab) && !(e.KeyChar == ','))
            {
                e.Handled = true; //usado para não emitir som             
                MessageBox.Show("É permitido apenas números e virgula!");  //Se pressionar alguma letra exibirá uma mensagem
            }
        }
        public void ApenasNumerosPonto(KeyPressEventArgs e)
        {
            // Aceita apenas Numeros, BackSpace, Espaço, enter, tab e virgula.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Escape) && !(e.KeyChar == (char)Keys.Enter) && !(e.KeyChar == (char)Keys.Tab) && !(e.KeyChar == '.'))
            {
                e.Handled = true; //usado para não emitir som             
                MessageBox.Show("É permitido apenas números e ponto(.)!");  //Se pressionar alguma letra exibirá uma mensagem
            }
        }
        public void ApenasLetras(KeyPressEventArgs e)
        {
            //permite digitar apenas letras, backspace, shift direito e esquerdo, espaço e tab no campo
            if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar)) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space) && !(e.KeyChar == (char)Keys.LShiftKey) && !(e.KeyChar == (char)Keys.RShiftKey) && !(e.KeyChar == (char)Keys.Tab))
            {
                e.Handled = true;
                MessageBox.Show("Digite apenas letras!");
            }
        }
        public void ApenasLetrasAsteristicos(KeyPressEventArgs e)
        {
            //permite digitar apenas letras, backspace, shift direito e esquerdo, espaço e tab no campo
            if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar)) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space) && !(e.KeyChar == (char)Keys.LShiftKey) && !(e.KeyChar == (char)Keys.RShiftKey) && !(e.KeyChar == (char)Keys.Tab) && !(e.KeyChar == '*'))
            {
                e.Handled = true;
                MessageBox.Show("Digite apenas letras!");
            }
        }
        /*
        public void LetrasMaiusculas(KeyPressEventArgs e, TextBox campo)
        {
            //deixa o textbox com letras maiúsculas
            if (Char.IsLower(e.KeyChar))
            {
                e.Handled = true;
                campo.SelectedText = Char.ToUpper(e.KeyChar).ToString();  //Converte o texto para caixa alta
            }
        }
        */
        public void Sair(KeyEventArgs e, Form tela)
        {
            // Se apertar Esc sai da tela
            if (e.KeyValue.Equals(27)) //27 se refere ao Escape (Esc)
            {
                e.Handled = true; //usado para não emitir som             
                tela.Dispose();
            }
        }
        public string ConverterVirgulaParaPonto(string texto)
        {
            // Pode ser usado para concatenar também:  string sVariavelNova = sVariavel.Replace(" ", "-").Replace("!", "?");
            texto = texto.Replace(",", ".");
            return texto;
        }
        public string ConverterPontoParaVirgula(string texto)
        {
            texto = texto.Replace(".", ",");
            return texto;
        }
        /*
        public void VerificarDigitoDecimal(KeyPressEventArgs e, TextBox campo)
        {
            //se tiver ponto no campo eu converto para virgula
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = '.';
            }
            //Verifica se já existe mais de um ponto na string
            if ((campo.Text.Contains(".") && (e.KeyChar == '.')))
            {
                e.Handled = true; // Caso exista, aborte. Trava o campo
            }
        }
        */
        public bool VerificaEmail(string strEmail)
        {
            //vericar se e-mail está no formato padrão
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public byte[] ConverterFoto(PictureBox img)
        {
            //converter foto para vetor de byte para inserção no banco
            using (var stream = new System.IO.MemoryStream())
            {
                img.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                byte[] foto = new byte[stream.Length];
                stream.Read(foto, 0, System.Convert.ToInt32(stream.Length));
                return foto;
            }
        }
        /*

        public Image DesconverterFoto(byte[] foto)
        {
            //desconverto a foto para mostrar na tela
            Image img = null;
            MemoryStream ms = new MemoryStream(foto);
            byte[] fotoRetorno = new byte[0];
            if (ms.Equals(fotoRetorno))
            {
                img = Image.FromStream(ms);
            }
            return img;
            //if (leitor["Foto"] != DBNull.Value) //verifico se o retorno é null
            //{
            //    recupero a foto na linha abaixo
            //    Image img = null;
            //    byte[] foto = null;
            //    foto = (byte[])leitor["Foto"];
            //    MemoryStream ms = new MemoryStream(foto);
            //    img = Image.FromStream(ms);
            //    func.foto = img;
            //    fim recuperação imagem     
            //}
        }
        */
        public void PesquisarImagem(OpenFileDialog oFileDialog, PictureBox imagem)
        {
            // valido a foto para exibir na tela
            oFileDialog.Filter = "Foto JPG|*.jpg|Foto JPEG|*.jpeg|Foto PNG|*.png|Foto bmp|*.bmp";

            DialogResult result = oFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string name = oFileDialog.FileName;

                if ((name == "openFileDialog") || (name == null))
                {
                    imagem.ImageLocation = @"E:\Sistema\Repositorio\Loja\IMAGENS\PNG\usuario.png";
                    //openFileDialog.FileName = "";
                }
                else
                {
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(name);
                    System.Drawing.Bitmap bmp2 = new System.Drawing.Bitmap(bmp, imagem.Size); //pego a btnImagem e object tamanho
                    imagem.Image = bmp2; // carrego o picturebox com a imagem
                }
            }
            else
            {
                oFileDialog.FileName = "";
                imagem.ImageLocation = @"E:\Sistema\Repositorio\Loja\IMAGENS\PNG\usuario.png";
            }
            /*
                                       EXEMPLO DE TIPO DE ARQUIVOS
            dlg.Filter = "Word Documents|*.doc|Excel Worksheets|*.xls|PowerPoint Presentations|*.ppt" +
            "|Office Files|*.doc;*.xls;*.ppt" +
            "|All Files|*.*";

            * open file dialog é um componete encontrado no toolbox para abrir a caixa de dialogo do windows
            * pbImagem.ImageLocation = @"D:\Loja\Imagens\usuario1.png"; pega a imagem
            * Para gravar as fotos dentro da pasta >> D:\Loja\Fotos\
            * picImagem.Image.Save(@"D:\Loja\Fotos\" + codigo + ".jpg");  
            */
        }
        public void MarcarEmpresas(CheckedListBox list)
        {
            for (int count = contador - 1; count > -1; count--) //coloco contador -1 para desconsiderar a opção todos do listbox
            {
                list.SetItemChecked(count, true);
            }
        }
        public void DesmarcarEmpresas(CheckedListBox list)
        {
            for (int count = contador - 1; count > -1; count--) //coloco contador -1 para desconsiderar a opção todos do listbox
            {
                list.SetItemChecked(count, false);
            }
        }
        /*
        public void VerificarLogado(Login login)
        {
            try
            {
                string sql = string.Empty;
                conexao.LimparParametros();
                conexao.AdicionarParametros("@maquina", login.maquina);
                sql = "SELECT * FROM Temp WHERE maquina = @maquina";
                DataTable dt = conexao.Consultar(CommandType.Text, sql);
                foreach (DataRow dr in dt.Rows)
                {
                    login.codigo = Convert.ToInt64(dr["Codigo"]);
                    login.usuario = dr["Usuario"].ToString();
                    login.situacao = Convert.ToInt32(dr["Situacao"]);
                    login.grupo = dr["Grupo"].ToString();
                    login.empresa = dr["Empresa"].ToString();
                    login.maquina = dr["Maquina"].ToString();
                    login.versao = dr["Versao"].ToString();
                    login.data_ult_login = Convert.ToDateTime(dr["Data"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível verificar o usuário logado. Detalhes: " + ex, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        public void ExcluirTemp(Login login)
        {
            try
            {
                conexao.LimparParametros();
                conexao.AdicionarParametros("@usuario", login.usuario);
                conexao.AdicionarParametros("@maquina", login.maquina);
                string sql = "DELETE FROM Temp WHERE Maquina = @maquina AND Usuario = @usuario";
                conexao.Manipular(CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível verificar usuário logado. Detalhes: " + ex, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        */
        public int contador;
        public int PreencherListEmpresa(CheckedListBox lista_empresa, Login login)
        {
            int count = 0;
            try
            {
                string sql = string.Empty;
                //conexao.LimparParametros();
                //conexao.AdicionarParametros("@codigo", logado.codigo);
                //sql = "SELECT EG.Codigo AS Código, F.Codigo AS 'Funcionário',";
                //sql = sql + "E.Fantasia AS 'Empresa Gerencial' FROM Funcionario_Empresa_Gerencial EG ";
                //sql = sql + "LEFT JOIN Funcionario F ON EG.Funcionario = F.Codigo ";
                //sql = sql + "LEFT JOIN Empresa E ON EG.Empresa = E.Codigo ";
                //sql = sql + "WHERE E.Inativo = 'N' AND F.Codigo = @codigo";
                sql = "SELECT Codigo, Fantasia FROM Empresa";
                DataTable dt = conexao.Consultar(CommandType.Text, sql);
                foreach (DataRow dr in dt.Rows) //outra maneira de preencher o checkedlistbox
                {
                    lista_empresa.DataSource = dt;
                    lista_empresa.ValueMember = "Codigo";
                    lista_empresa.DisplayMember = "Fantasia";
                    count = count + 1;
                }
                contador = count;
                //foreach (DataRow dr in dt.Rows) //outra maneira de preencher o checkedlistbox
                //{
                //    lista_empresa.Items.Add(dr["Codigo"].ToString() + " - " + dr["Fantasia"].ToString());
                //    lista_empresa.SetItemChecked(count, false);
                //    count = count + 1;
                //}
                //contador = count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível verificar o usuário logado. Falha: " + ex, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return contador;
        }
        public void MarcarEmpresaGerencial(CheckedListBox lista_empresa, string Codigo_Funcionario)
        {
            try
            {
                int count = 0, gerencial = 0;
                conexao.LimparParametros();
                conexao.AdicionarParametros("@codigo", Codigo_Funcionario);
                string sql = "SELECT EG.Codigo AS 'Cód. Registro', E.Codigo AS 'Cód. Empresa', E.Fantasia AS Empresa";
                sql = sql + " FROM Funcionario_Empresa_Gerencial EG";
                sql = sql + " LEFT JOIN Funcionario F ON EG.Funcionario = F.Codigo";
                sql = sql + " LEFT JOIN Empresa E ON EG.Empresa = E.Codigo";
                sql = sql + " WHERE E.Inativo = 'N' AND F.Codigo = @codigo";
                DataTable dt = conexao.Consultar(CommandType.Text, sql);
                foreach (DataRow dr in dt.Rows)
                {
                    gerencial = Convert.ToInt32(dr["Cód. Empresa"]);
                    if (gerencial > 0) //se a empresa gerencial for = S então marco ela
                    {
                        lista_empresa.SetItemChecked(gerencial - 1, true);
                    }
                    else
                    {
                        lista_empresa.SetItemChecked(gerencial, false);
                    }
                    count = count + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar dados. Detalhes: " + ex, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /*
        public void VerificarAniversario(DateTimePicker dtNascimento, DateTimePicker dtCadastro, Label informativa, RadioButton Demitido)
        {
            if ((dtNascimento.Value.Month == DateTime.Now.Month) && (dtNascimento.Value.Year <= DateTime.Now.Year) && (Demitido.Checked == false))
            {
                informativa.Visible = true;
                informativa.Text = string.Empty;
                informativa.Text = "Funcionário Aniversariante do mês!";
            }
        }
        */
    }
}