using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net; //Necessario para usar webclient
using System.IO;
using System.Runtime.InteropServices;
using System.Data.Common;
using System.Data.OleDb;
using ICSharpCode.SharpZipLib.Zip; //adicionamos a dll que consta nesse projeto e as referencias a partir daqui
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.GZip;
using Microsoft.Office.Interop.Excel;

namespace CATAPORA_BKP
{


    public partial class Mos : Form
    {
        

        public Mos()
        {
            InitializeComponent();


        }


      

        private void Mos_Load(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("https://webmail.netservicos.com.br/owa/");

           // WebClient client = new WebClient();

            //WebRequest request = WebRequest.Create("https://webmail.netservicos.com.br/owa/");

           // client.Credentials = new NetworkCredential("N5669203", "Junho.2015");

           // Stream stream = client.OpenRead("https://webmail.netservicos.com.br/owa/");
           // StreamReader r = new StreamReader(stream);

           // string retorno = r.ReadToEnd();

            //string retorno = webBrowser1.DocumentText;

            //richTextBox1.Text = retorno;

            //Abaixo temos o código que muda a cor da barra
            //1 = normal (green); 2 = error (red); 3 = warning (yellow).

            pcbSolicitacao.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
            pcbDevolutiva.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");

            dtpColeta.Value = DateTime.Now.Date;
            dtpTratamento.Value = DateTime.Now.Date;
            dtpDataInicialConsultaMOS.Value = DateTime.Now.AddDays(-1);
            dtpDataFinalConsultaMOS.Value = DateTime.Now.Date;

            
        }

        

        private void lnkMOS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            webBrowser1.Visible = true;
            webBrowser2.Visible = false;
            webBrowser3.Visible = false;
           
        }

        private void lnkDatacenter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            webBrowser1.Visible = false;
            webBrowser2.Visible = true;
            webBrowser3.Visible = false;
           
        }

        private void lnkGerencia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            webBrowser1.Visible = false;
            webBrowser2.Visible = false;
            webBrowser3.Visible = true;
        }

        private void btnMos_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtMos.Text); //abro a página e só reabilito os botoes depois que elas carregam
            btnMos.Enabled = false;
            txtMos.Enabled = false;
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate(txtDatacenter.Text);
            btnData.Enabled = false;
            txtDatacenter.Enabled = false;

        }

        private void btnGerencia_Click(object sender, EventArgs e)
        {
            webBrowser3.Navigate(txtGerencia.Text);
            btnGerencia.Enabled = false;
            txtGerencia.Enabled = false;

        }

        private void webBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btnGerencia.Enabled = true;
            txtGerencia.Enabled = true;

        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            txtDatacenter.Enabled = true;
            btnData.Enabled = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btnMos.Enabled = true;
            txtMos.Enabled = true;

            String retorno = webBrowser1.DocumentText;
            richTextBox1.Text = retorno;

            //var busca = webBrowser1.Document.GetElementsByTagName("a");

            //foreach (HtmlElement ele in busca)
            //{
            //    //localiza os links na página

            //    DataTable tabela = new DataTable();


            //}
        }

        private void btnAbrirEmail_Click(object sender, EventArgs e)
        {

        }

        private void btnAddEmail_Click(object sender, EventArgs e)
        {

        }

        private void pctEmail_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnAbrirPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPrint_Click(object sender, EventArgs e)
        {

        }

        private void pctPrint_MouseHover(object sender, EventArgs e)
        {

        }

        private void txtQtdeLigacoes_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Aqui faz com que ele aceite apenas números no campo

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void rbAderente_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void dbData_CheckedChanged(object sender, EventArgs e)
        {
            if (dbData.Checked == true)
            {
                lblDataInicial.Visible = true;
                lblDataFinal.Visible = true;
                dtpDataInicialConsultaMOS.Visible = true;
                dtpDataFinalConsultaMOS.Visible = true;
                lblContratoConsulta.Visible = false;
                txtContratoConsulta.Visible = false;
            }
            if (dbData.Checked == false)
            {
                lblDataInicial.Visible = false;
                lblDataFinal.Visible = false;
                dtpDataInicialConsultaMOS.Visible = false;
                dtpDataFinalConsultaMOS.Visible = false;
                lblContratoConsulta.Visible = true;
                txtContratoConsulta.Visible = true;
            }
        }

        private void rdTudo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTudo.Checked == true)
            {
                lblDataInicial.Visible = false;
                lblDataFinal.Visible = false;
                dtpDataInicialConsultaMOS.Visible = false;
                dtpDataFinalConsultaMOS.Visible = false;
                lblContratoConsulta.Visible = false;
                txtContratoConsulta.Visible = false;
            }
        }

        private void rdContrato_CheckedChanged(object sender, EventArgs e)
        {
            if (rdContrato.Checked == true)
            {
                lblContratoConsulta.Visible = true;
                txtContratoConsulta.Visible = true;
            }
        }

        private void btnNovoMOS_Click(object sender, EventArgs e)
        {
            txtIdMOS.Text = String.Empty;
            txtQtdeLigacoes.Text = String.Empty;
            txtContratosMOS.Text = String.Empty;
            txtDevoluticaCaminho.Text = String.Empty;
            txtSolicitacaoCaminho.Text = String.Empty;
            dtpColeta.Value = DateTime.Now.Date;
            dtpTratamento.Value = DateTime.Now.Date;
            txtQtdeLigacoes.Focus();

            pcbSolicitacao.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
            pcbDevolutiva.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");

            rbAderente.Checked = false;
            rbNecessario.Checked = false;
            rdCritico.Checked = false;

            btnSalvarMOS.Enabled = true;

        }

        private void btnSalvarMOS_Click(object sender, EventArgs e)
        {
            if ((txtSolicitacaoCaminho.Text == String.Empty || txtQtdeLigacoes.Text == String.Empty || txtContratosMOS.Text == String.Empty) || (rbAderente.Checked == false && rbNecessario.Checked == false && rdCritico.Checked == false))
            {
                MessageBox.Show("Favor preencher os campos do MOS corretamente", "ERRO AO SALVAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RegistroMos registroMos = new RegistroMos();

                registroMos.Contratos = txtContratosMOS.Text.Trim();
                registroMos.QtdeLigacoes = txtQtdeLigacoes.Text.Trim();
                registroMos.CaminhoSolicitacao = txtSolicitacaoCaminho.Text.Trim();
                registroMos.CaminhoDevolutiva = txtDevoluticaCaminho.Text.Trim();
                
                registroMos.DataCadastro = dtpColeta.Value.Date;
                registroMos.DataTratamento = dtpTratamento.Value.Date;

                string ofensor = "";

                if (rbAderente.Checked == true)
                {
                    ofensor = "ADERENTE";
                }

                if (rbNecessario.Checked == true)
                {
                    ofensor = "NECESSARIO";
                }

                if (rdCritico.Checked == true)
                {
                    ofensor = "CRITICO";
                }

                registroMos.Ofensor = ofensor;

                Classe usuCad = new Classe();
                registroMos.Tratador = usuCad.UsuarioLogado;

                Conexao conectar = new Conexao(); // instancio o objeto conexao para mandar os parametros por referencia

                conectar.cadastraMOS(registroMos);

                this.btnNovoMOS.PerformClick(); //limpa os campos como se fosse um registro novo

            }


        }

        private void btnConsultaMOS_Click(object sender, EventArgs e)
        {
            RegistroMos registroMos =  new RegistroMos();
            Conexao conectar = new Conexao();

            int opcaoRadio;
            //0 = data, 1 = contrato, 2 = tudo

            try
            {
                if (dbData.Checked == true)
                {
                    opcaoRadio = 0;

                    registroMos.DataInicial = dtpDataInicialConsultaMOS.Value.Date;
                    registroMos.DataFinal = dtpDataFinalConsultaMOS.Value.Date;

                    System.Data.DataTable dt = new System.Data.DataTable(); //aqui instancio o data table
                    OleDbDataAdapter da = new OleDbDataAdapter(); //Aqui o mais importante, o método retorna um dataadapter e eu instancio um novo aqui e pego por parametro o valor do que foi tratado no método
                    da = Conexao.consultaMOS(registroMos, opcaoRadio); //passo o valor do radiobutton e o objeto que será utilizado na consulta

                    da.Fill(dt); //preenco o data adapter com os valores retornados

                    dataGridView1.DataSource = dt; //atualizo o datagrid view

                }

                if (rdContrato.Checked == true)
                {
                    opcaoRadio = 1;
                    registroMos.ContratoConsulta = txtContratoConsulta.Text.Trim();

                    System.Data.DataTable dt = new System.Data.DataTable(); //aqui instancio o data table
                    OleDbDataAdapter da = new OleDbDataAdapter(); //Aqui o mais importante, o método retorna um dataadapter e eu instancio um novo aqui e pego por parametro o valor do que foi tratado no método
                    da = Conexao.consultaMOS(registroMos, opcaoRadio); //passo o valor do radiobutton e o objeto que será utilizado na consulta

                    da.Fill(dt); //preenco o data adapter com os valores retornados

                    dataGridView1.DataSource = dt; //atualizo o datagrid view
                }

                if (rdTudo.Checked == true)
                {
                    opcaoRadio = 2;
                    System.Data.DataTable dt = new System.Data.DataTable(); //aqui instancio o data table
                    OleDbDataAdapter da = new OleDbDataAdapter(); //Aqui o mais importante, o método retorna um dataadapter e eu instancio um novo aqui e pego por parametro o valor do que foi tratado no método
                    da = Conexao.consultaMOS(registroMos, opcaoRadio); //passo o valor do radiobutton e o objeto que será utilizado na consulta

                    da.Fill(dt); //preenco o data adapter com os valores retornados

                    dataGridView1.DataSource = dt; //atualizo o datagrid view
                }

                int resultados = dataGridView1.Rows.Count - 1;
                
                lblResultados.Text =  resultados.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao efetuar a consulta do MOS! Favor informar o descritivo do erro ao desenvolvedor. Erro:  " + ex.Message, "ERRO AO EFETUAR CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int linha, coluna;
                //acima, setamos variaveis que irão receber valores das linhas e colunas para triangular os cliques na coluna

                string refRegistro;
                //acima iremos colher exatamente o primeiro campo da coluna, ou seja o id

                linha = dataGridView1.CurrentRow.Index;
                coluna = dataGridView1.CurrentCell.ColumnIndex;

                refRegistro = dataGridView1.Rows[linha].Cells[coluna].Value.ToString(); //pego o valor exato do primeiro item de cada linha

                OleDbConnection conexaoBD = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb");

                OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT * FROM mos WHERE mosid LIKE'" + refRegistro + "'", conexaoBD);

                DataSet ds = new DataSet();

                //preenche o dataset com os dados da tabela tblchip
                adaptador.Fill(ds, "retornoConsulta");

                //abaixo verifico se existe algum registro, se existir retorno na aba de visualização, senao envio a mensagem informando

                if (ds.Tables["retornoConsulta"].Rows.Count < 0)
                {
                    MessageBox.Show("Não foram encontrados resultados para a sua pesquisa", "REGISTRO NÃO ENCONTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    int posicaoAtual = 0;
                    //essa posição diz respeito ao primeiro registro retornado. como iremos retornar o ID é exatamente isto que queremos

                    this.txtIdMOS.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["mosid"]);
                    this.dtpColeta.Value = Convert.ToDateTime(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["datacoleta"]);
                    this.dtpTratamento.Value = Convert.ToDateTime(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["datatratamento"]);
                    this.txtQtdeLigacoes.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["qtdeligacoes"]);
                    this.txtContratosMOS.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["contratos"]);
                    this.txtSolicitacaoCaminho.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["caminhosolicitacao"]);
                    this.txtDevoluticaCaminho.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["caminhodevolutiva"]);
                    string ofensor = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["ofensor"]);

                    //Abaixo código pra selecionar ofensor salvo

                    if (ofensor == "ADERENTE")
                    {
                        rbAderente.Checked = true;
                    }

                    if (ofensor == "NECESSARIO")
                    {
                        rbNecessario.Checked = true;
                    }

                    if (ofensor == "CRITICO")
                    {
                        rdCritico.Checked = true;
                    }

                    //Código pra carregar os pcb

                    if (txtSolicitacaoCaminho.Text == String.Empty)
                    {
                        pcbSolicitacao.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
                    }
                    else
                    {
                        pcbSolicitacao.Load(System.Windows.Forms.Application.StartupPath + @"\image\outroformato.png");
                    }

                    if (txtDevoluticaCaminho.Text == String.Empty)
                    {
                        pcbDevolutiva.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
                    }
                    else
                    {
                        pcbDevolutiva.Load(System.Windows.Forms.Application.StartupPath + @"\image\outroformato.png");
                    }

                    btnSalvarMOS.Enabled = false;   

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível executar a ação. Código do erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirMOS_Click(object sender, EventArgs e)
        {
            if (txtIdMOS.Text == String.Empty)
            {
                MessageBox.Show("Não foi possível apagar o registro. Deve haver um registro carregado no formulário.", "ERRO AO APAGAR O REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RegistroMos registroMos = new RegistroMos(); //instancio o objeto que sera enviado para salvar no banco pelos métodos da classe conexao

                registroMos.IdMos = Convert.ToInt32(txtIdMOS.Text); //transformo o que esta no campo id para inteiro e atribui ao item ID do catapora


                Conexao conectar = new Conexao(); // instancio o objeto conexao para mandar os parametros por referencia da classe conexao

                conectar.apagaMOS(registroMos); //passo por parametro o objeto com os dados e chamo o metodo apagaCatapora que esta na classe conexao

                if (!String.IsNullOrEmpty(txtSolicitacaoCaminho.Text))
                {
                    File.Delete(txtSolicitacaoCaminho.Text); //Apaga o anexo relacionado se houver um
                }
                if (!String.IsNullOrEmpty(txtDevoluticaCaminho.Text))
                {
                    File.Delete(txtDevoluticaCaminho.Text); //Apaga o anexo relacionado se houver um
                }

                btnNovoMOS.PerformClick();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null && e.ColumnIndex == 7)) //Colore as celulas do datagrid de acordo com os valores
            {
                if (e.Value.Equals("ADERENTE"))
                {
                    e.CellStyle.BackColor = Color.LawnGreen;
                }

                if (e.Value.Equals("NECESSARIO"))
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }

                if (e.Value.Equals("CRITICO"))
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void btnEditarMOS_Click(object sender, EventArgs e)
        {
            if (txtIdMOS.Text == String.Empty || txtContratosMOS.Text == String.Empty || txtQtdeLigacoes.Text == String.Empty)
            {
                MessageBox.Show("Para que este registro seja considerado aderente a política, os campos de id MOS, contratos e Qtde. de ligações devem ser preenchidos.", "ERRO AO ATUALIZAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RegistroMos registroMos = new RegistroMos();

                registroMos.IdMos = Convert.ToInt16(txtIdMOS.Text.Trim());
                registroMos.Contratos = txtContratosMOS.Text.Trim();
                registroMos.QtdeLigacoes = txtQtdeLigacoes.Text.Trim();
                registroMos.CaminhoSolicitacao = txtSolicitacaoCaminho.Text.Trim();
                registroMos.CaminhoDevolutiva = txtDevoluticaCaminho.Text.Trim();

                registroMos.DataCadastro = dtpColeta.Value.Date;
                registroMos.DataTratamento = dtpTratamento.Value.Date;

                string ofensor = "";

                if (rbAderente.Checked == true)
                {
                    ofensor = "ADERENTE";
                }

                if (rbNecessario.Checked == true)
                {
                    ofensor = "NECESSARIO";
                }

                if (rdCritico.Checked == true)
                {
                    ofensor = "CRITICO";
                }

                registroMos.Ofensor = ofensor;

                Classe usuCad = new Classe();
                registroMos.Tratador = usuCad.UsuarioLogado;

                Conexao conectar = new Conexao(); // instancio o objeto conexao para mandar os parametros por referencia

                conectar.atualizaMOS(registroMos);

                


            }
        }

        private void btnAddSolicitacao_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataSalvamento;
                dataSalvamento = DateTime.Now;

                string caminhoSalvo = PastaAPP.resgataPastaPadrao() + @"\arquivosControle\mos\mos" + dataSalvamento.ToString("HH-mm-ss_dd-MMM-yyyy") + ".zip";
                //################### FUNCIONA ######################

                if (ofdCompactar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    char delimitador = '\\'; //delimitador das pastas, vai separar pastas dos arquivos
                    string nomeArquivoFim; //variavel que vai pegar o nome do arquivo pra salvar
                    string[] nomeArquivo; //array que vai pegar separadamente cada pasta e por fim o nome do arquivo
                    string nomeZip = ofdCompactar.FileName;
                    nomeArquivo = nomeZip.Split(delimitador);
                    nomeArquivoFim = nomeArquivo.Last();


                    ZipOutputStream zipOutPut = new ZipOutputStream(File.Create(caminhoSalvo)); //cria um arquivo zipado na pasta para ser incluido dentro arquivos

                    zipOutPut.SetLevel(6); //nível de compactação. 9 é o máximo
                    //zipOutPut.Password = "12345"; //bota senha no zip

                    //ZipEntry arquivoSalvo = new ZipEntry(nomeArquivoFim);//Aqui vai o arquivo que será salvo
                    //zipOutPut.PutNextEntry(arquivoSalvo); //aqui seto ele no arquivo

                    zipOutPut.Finish(); //finaliza o arquivo
                    zipOutPut.Close(); //fecha o arquivo

                    ZipFile arquivoZip = new ZipFile(caminhoSalvo); //aqui converto o arquivo criado para zip da biblioteca

                    arquivoZip.BeginUpdate(); //inicia a criação do ZIP



                    // arquivoZip.NameTransform = new ZipNameTransform(nomeZip.Substring(1, nomeZip.LastIndexOf("/")));
                    foreach (string arquivos in ofdCompactar.FileNames)
                    {

                        string[] pegaNomesFinal;
                        pegaNomesFinal = arquivos.Split(delimitador);
                        string final = pegaNomesFinal.Last();

                        arquivoZip.Add(arquivos.ToString(), final); //primeiro parametro é o caminho do arquivo, segundo o arquivo em si
                    }

                    arquivoZip.CommitUpdate();

                    arquivoZip.Close();

                }

              txtSolicitacaoCaminho.Text = caminhoSalvo;
                pcbSolicitacao.Load(System.Windows.Forms.Application.StartupPath + @"\image\outroformato.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o arquivo. Informe o código do erro: " + ex.Message, "ERRO AO SALVAR MOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAbrirSolicitacao_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSolicitacaoCaminho.Text == String.Empty)
                {
                    MessageBox.Show("Não há arquivo anexo neste processo!", "ERRO AO ABRIR MOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    System.Diagnostics.Process.Start(txtSolicitacaoCaminho.Text); //Abre o arquivo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o anexo em questão. Verifique se possui privilégios de escrita/leitura para o mesmo ou especifique o seguinte erro ao programador: " + ex.Message, "ERRO AO ABRIR ARQUIVO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDevolutiva_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataSalvamento;
                dataSalvamento = DateTime.Now;

                string caminhoSalvo = PastaAPP.resgataPastaPadrao() + @"\arquivosControle\mos\mos" + dataSalvamento.ToString("HH-mm-ss_dd-MMM-yyyy") + ".zip";
                //################### FUNCIONA ######################

                if (ofdCompactar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    char delimitador = '\\'; //delimitador das pastas, vai separar pastas dos arquivos
                    string nomeArquivoFim; //variavel que vai pegar o nome do arquivo pra salvar
                    string[] nomeArquivo; //array que vai pegar separadamente cada pasta e por fim o nome do arquivo
                    string nomeZip = ofdCompactar.FileName;
                    nomeArquivo = nomeZip.Split(delimitador);
                    nomeArquivoFim = nomeArquivo.Last();


                    ZipOutputStream zipOutPut = new ZipOutputStream(File.Create(caminhoSalvo)); //cria um arquivo zipado na pasta para ser incluido dentro arquivos

                    zipOutPut.SetLevel(6); //nível de compactação. 9 é o máximo
                    //zipOutPut.Password = "12345"; //bota senha no zip

                    //ZipEntry arquivoSalvo = new ZipEntry(nomeArquivoFim);//Aqui vai o arquivo que será salvo
                    //zipOutPut.PutNextEntry(arquivoSalvo); //aqui seto ele no arquivo

                    zipOutPut.Finish(); //finaliza o arquivo
                    zipOutPut.Close(); //fecha o arquivo

                    ZipFile arquivoZip = new ZipFile(caminhoSalvo); //aqui converto o arquivo criado para zip da biblioteca

                    arquivoZip.BeginUpdate(); //inicia a criação do ZIP



                    // arquivoZip.NameTransform = new ZipNameTransform(nomeZip.Substring(1, nomeZip.LastIndexOf("/")));
                    foreach (string arquivos in ofdCompactar.FileNames)
                    {

                        string[] pegaNomesFinal;
                        pegaNomesFinal = arquivos.Split(delimitador);
                        string final = pegaNomesFinal.Last();

                        arquivoZip.Add(arquivos.ToString(), final); //primeiro parametro é o caminho do arquivo, segundo o arquivo em si
                    }

                    arquivoZip.CommitUpdate();

                    arquivoZip.Close();

                }

                txtDevoluticaCaminho.Text = caminhoSalvo;
                pcbDevolutiva.Load(System.Windows.Forms.Application.StartupPath + @"\image\outroformato.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o arquivo. Informe o código do erro: " + ex.Message, "ERRO AO SALVAR MOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbrirDevolutiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDevoluticaCaminho.Text == String.Empty)
                {
                    MessageBox.Show("Não há arquivo anexo neste processo!", "ERRO AO ABRIR MOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    System.Diagnostics.Process.Start(txtDevoluticaCaminho.Text); //Abre o arquivo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o anexo em questão. Verifique se possui privilégios de escrita/leitura para o mesmo ou especifique o seguinte erro ao programador: " + ex.Message, "ERRO AO ABRIR ARQUIVO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog salvar = new SaveFileDialog();

                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//crio uma instancia do Excel


                Workbook wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet); //Crio uma pasta do excel
                Worksheet ws = (Worksheet)wb.Worksheets.get_Item(1); //Crio uma planilha;
                int i = 0;
                int j = 0;

                // passa as celulas do DataGridView para a Pasta do Excel
                for (i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dataGridView1[j, i];
                        ws.Cells[i + 1, j + 1] = cell.Value;


                    }
                }



                // define algumas propriedades da caixa salvar
                salvar.Title = "Exportar para Excel";
                salvar.Filter = "Arquivo do Excel *.xlsx | *.xlsx";
                salvar.ShowDialog(); // mostra

                // salva o arquivo
                wb.SaveAs(salvar.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //encerro a Instancia do excel
                excel.Quit();

                MessageBox.Show("Exportado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exportar planilha do Excel. Código do erro: " + ex.Message, "ERRO AO EXPORTAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



       

        

        
    }
}
