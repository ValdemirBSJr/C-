using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip; //adicionamos a dll que consta nesse projeto e as referencias a partir daqui
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.GZip;
using System.IO;
using System.Data.Common;
using System.Data.OleDb;
using System.Configuration; //precisa desa classe adicionado tbm em referencia
using Microsoft.Office.Interop.Excel;


namespace CATAPORA_BKP
{
    public partial class catapora : Form
    {


        public catapora()
        {
            InitializeComponent();

          
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)//Funciona!
        {
            //Esta funcionando, colhe informação digtada e a usa na inoutação de dados.
            //Aqui eu verifico se a aba um do tabcontrol está selecionada no momento que se clicar no enter, se sim ele efetua o botão busca por catapora

            if (keyData == Keys.Enter && tabControl1.SelectedIndex == 1)
            {
                this.btnBusca.PerformClick();
            }
           

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public String[] pegaArquivos; //variavel global que vai pegar os caminhos dos arquivos
       
        private void catapora_Load(object sender, EventArgs e) //método que carrega o form
        {
            Classe usuCad = new Classe();
            txtExecutor.Text = usuCad.UsuarioLogado;

            pctEmail.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
            pctPrint.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");

            lblBuscar.Visible = true; // campos da aba consulta
            lblBuscar.Text = "Clique no botão buscar";
            lblDfinal.Visible = false;
            lblDinicial.Visible = false;
            dtpFinal.Visible = false;
            dtpInicial.Visible = false;
            txtBusca.Visible = false;
            lblResultados.Visible = false;

            this.dtpCadastro.Value = DateTime.Now.Date; //aqui faz com que eles sempre peguem a data do dia
            this.dtpTratamento.Value = DateTime.Now.Date;
            this.dtpInicial.Value = DateTime.Now.Date;
            this.dtpFinal.Value = DateTime.Now.Date;

        }

        private void btnNovo_Click(object sender, EventArgs e) //método que prepara o form para um novo registro
        {
            txtNodesSaturados.Text = String.Empty;
            txtTicket.Text = String.Empty;
            pctEmail.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
            pctPrint.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
            txtNodesSaturados.Focus();
            txtID.Text = String.Empty;
            txtAnexoEmail.Text = String.Empty;
            txtAnexoPrint.Text = String.Empty;
        }

        private void btnAddPrint_Click(object sender, EventArgs e) //método que adiciona o print no form e prepara para salvar
        {
            try
            {
                DateTime dataSalvamento;
                dataSalvamento = DateTime.Now;

                string caminhoSalvo = PastaAPP.resgataPastaPadrao() + @"\arquivosControle\catapora\catapora" + dataSalvamento.ToString("HH-mm-ss_dd-MMM-yyyy") + ".zip";
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

                txtAnexoPrint.Text = caminhoSalvo;
                pctPrint.Load(System.Windows.Forms.Application.StartupPath + @"\image\outroformato.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o arquivo. Informe o código do erro: " + ex.Message, "ERRO AO SALVAR BKP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //########################### FUNCIONA COM UM ÚNICO ARQUIVO

            //if (ofdCompactar.ShowDialog() == DialogResult.OK)
            //{//tem que setar o multiselect como true nos atributos

            //    char delimitador = '\\'; //delimitador das pastas, vai separar pastas dos arquivos
            //    string nomeArquivoFim; //variavel que vai pegar o nome do arquivo pra salvar
            //    string[] nomeArquivo; //array que vai pegar separadamente cada pasta e por fim o nome do arquivo
            //    string nomeZip = ofdCompactar.FileName;
            //    nomeArquivo = nomeZip.Split(delimitador);
            //    nomeArquivoFim = nomeArquivo.Last();

            //    int TAMANHO_STREAM = 4096;

            //    FileStream objStreamDestino =
            //     new FileStream(System.Windows.Forms.Application.StartupPath + @"\image\Exemplo.zip", FileMode.Create, FileAccess.Write);
            //    //Arquivo que vai ser gerado               


            //    FileStream arquivo = new FileStream(ofdCompactar.FileName, FileMode.Open, FileAccess.Read);
            //    //Arquivo que será compactado

            //    ZipOutputStream objZipDestino = new ZipOutputStream(objStreamDestino);

            //    // objZipDestino.Password = "123456"; //coloca senha no zip
            //    objZipDestino.SetLevel(5);//nível de compactação. máximo é 9
            //    // Aqui informamos qual será a senha para acesso ao arquivo zip

            //    try
            //    {


            //        byte[] buffer = new byte[TAMANHO_STREAM];
            //        //Criando um array para servir como armazenador durante a iteração sobre o objeto.

            //        foreach (string arquivos in ofdCompactar.FileNames)
            //        {
            //            string[] pegaNomesFinal;
            //            pegaNomesFinal = arquivos.Split(delimitador);
            //            string final = pegaNomesFinal.Last();

            //            ZipEntry entrada = new ZipEntry(final); /* Criando uma nova entrada de arquivos, 
            //já já entenderemos melhor o que isso significa. 
            //Devemos passar como parâmetro o nome do arquivo que será inserido no .zip, 
            //NÃO devemos colocar o caminho do arquivo que será compactado somente o nome.*/

            //            objZipDestino.PutNextEntry(entrada);
            //            // Aqui adicionamos no arquivo destino à entrada de arquivo que criamos na linha acima.

            //            objZipDestino.Password = "123456";
            //            // Aqui informamos qual será a senha para acesso ao arquivo zip

            //            int bytesLidos = 0;

            //            do
            //            {

            //                bytesLidos = arquivo.Read(buffer, 0, TAMANHO_STREAM);
            //                /* lendo o arquivo a ser compactado, 
            //                os bytes lidos são colocados no array buffer e a da quantidade e 
            //               bytes lidos é inserida na variável bytesLidos o valor do terceiro 
            //               parâmetro deve ser o mesmo que colocamos no tamanho do array buffer*/


            //                objZipDestino.Write(buffer, 0, bytesLidos);/*escrevendo no arquivo zipado, 
            //        o buffer contém os dados que devem ser inseridos e a variável bytesLidos 
            //        informa ao método quantos bytes contidos no buffer ele deve realmente inserir.
            //         Tendo em vista que: digamos que só haja 2 bytes no arquivo de origem, 
            //         as duas primeiras posições do array buffer seriam preenchidas as outras
            //         permaneceriam vazias, você não quer que bytes vazios sejam inseridos no seu 
            //        .ZIP pois estes podem corrompe-lo, portando é de suma importância saber realmente 
            //        quantos bytes são relevantes dentro do array*/


            //            }

            //            while (bytesLidos > 0);
            //            // enquanto o número de bytes lidos é maior que zero faz-se o loop


            //            /*é importante entender que a informação é lida e escrita em blocos, nesse caso ele

            //            Lê 4096 bytes

            //            Insere 4096 bytes

            //            Lê 4096 bytes

            //            Insere 4096 bytes

            //            E assim vai até não haver mais bytes a serem lidos.

            //            */

            //        }






            //    }

            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Erro: " + ex.Message);
            //        //throw ex; // Aqui devemos tratar se algum erro ocorrer neste
            //        //caso estou repassando a bucha para o método que chamou.

            //    }

            //    finally
            //    {

            //        //fechando as comunicações.

            //        arquivo.Close();

            //        objZipDestino.Close();

            //        objStreamDestino.Close();


            //    }





            //}
        }

        

        private void pctPrint_MouseHover(object sender, EventArgs e) //método de criar o tooltip explicativo print
        {
            if (pctPrint.ImageLocation == System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png")
            {
                Classe info = new Classe(); // instancio um objeto que vai receber o tooltip

                ToolTip toolinfo = new ToolTip();

                toolinfo.SetToolTip(this.pctPrint, "Não há upstream salvo"); // aqui digo a mensagem que deve ser passada, as confs estão instanciadas na classe Classe

                info.retornaInfo(toolinfo);




            }

            else
            {
                //Aqui vai as mensagens quando o caminho for diferente

                Classe info = new Classe(); // instancio um objeto que vai receber o tooltip

                ToolTip toolinfo = new ToolTip();

                toolinfo.SetToolTip(this.pctPrint, "UPS Salvo: " + txtAnexoPrint.Text); // aqui digo a mensagem que deve ser passada, as confs estão instanciadas na classe Classe

                info.retornaInfo(toolinfo);
            }
        }

        private void pctEmail_MouseHover(object sender, EventArgs e) //método de criar o tooltip explicativo email
        {
            if (pctEmail.ImageLocation == System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png")
            {
                Classe info = new Classe(); // instancio um objeto que vai receber o tooltip

                ToolTip toolinfo = new ToolTip();

                toolinfo.SetToolTip(this.pctEmail, "Não há Downstream salvo"); // aqui digo a mensagem que deve ser passada, as confs estão instanciadas na classe Classe

                info.retornaInfo(toolinfo);




            }

            else
            {
                //Aqui vai as mensagens quando o caminho for diferente

                Classe info = new Classe(); // instancio um objeto que vai receber o tooltip

                ToolTip toolinfo = new ToolTip();

                toolinfo.SetToolTip(this.pctEmail, "DWS Salvo: " + txtAnexoEmail.Text); // aqui digo a mensagem que deve ser passada, as confs estão instanciadas na classe Classe

                info.retornaInfo(toolinfo);
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e) //evento que salva os registros
        {
            if (txtNodesSaturados.Text == String.Empty)
            {
                MessageBox.Show("Favor preencher o campo dos nodes saturados", "ERRO AO SALVAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                

                    RegistroCatapora registroCatapora = new RegistroCatapora(); //instancio o objeto que sera enviado para salvar no banco pelos métodos da classe conexao

                   // registroCatapora.CaminhoEmail = pctEmail.ImageLocation; //pega o caminho do arquivo do email
                    registroCatapora.CaminhoEmail = txtAnexoEmail.Text;
                    registroCatapora.CaminhoPrint = txtAnexoPrint.Text;

                    registroCatapora.Tratador = txtExecutor.Text;

                    registroCatapora.NodesTratados = txtNodesSaturados.Text;
                    registroCatapora.TicketAberto = txtTicket.Text;

                    registroCatapora.DataCadastro = dtpCadastro.Value.Date; //pega os valores do datetime o .date pega só a data sem horas
                    registroCatapora.DataTratamento = dtpTratamento.Value.Date;


                    Conexao conectar = new Conexao(); // instancio o objeto conexao para mandar os parametros por referencia

                    conectar.cadastraCatapora(registroCatapora);
                

                    txtNodesSaturados.Text = String.Empty;
                    txtTicket.Text = String.Empty;
                    pctEmail.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
                    pctPrint.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
                    txtNodesSaturados.Focus();
                    txtAnexoEmail.Text = String.Empty;
                    txtAnexoPrint.Text = String.Empty;
                
               
            }
            

        }

        private void btnAbrirPrint_Click(object sender, EventArgs e) //fazer teste de compactar
        {
            try
            {
                if (txtAnexoPrint.Text == String.Empty)
                {
                    MessageBox.Show("Não há print anexo neste processo!", "ERRO AO ABRIR UPS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    System.Diagnostics.Process.Start(txtAnexoPrint.Text); //Abre o arquivo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o anexo em questão. Verifique se possui privilégios de escrita/leitura para o mesmo ou especifique o seguinte erro ao programador: " + ex.Message, "ERRO AO ABRIR ARQUIVO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
           

        }

        private void btnAddEmail_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataSalvamento;
                dataSalvamento = DateTime.Now;

                string caminhoSalvo = PastaAPP.resgataPastaPadrao() + @"arquivosControle\catapora\catapora" + dataSalvamento.ToString("HH-mm-ss_dd-MMM-yyyy") + ".zip";
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

                    zipOutPut.SetLevel(7); //nível de compactação. 9 é o máximo
                    //zipOutPut.Password = "12345"; bota senha no zip

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

                txtAnexoEmail.Text = caminhoSalvo;
                pctEmail.Load(System.Windows.Forms.Application.StartupPath + @"\image\outroformato.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o arquivo. Informe o código do erro: " + ex.Message, "ERRO AO SALVAR BKP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNodesSaturados.Text == String.Empty || txtTicket.Text == String.Empty || txtAnexoEmail.Text == String.Empty)
            {
                MessageBox.Show("Para que este registro seja considerado aderente a política, os campos de nodes saturados, tickets abertos e email de tratamento devem ser preenchidos.", "ERRO AO ATUALIZAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                

                RegistroCatapora registroCatapora = new RegistroCatapora(); //instancio o objeto que sera enviado para salvar no banco pelos métodos da classe conexao

                //registroCatapora.CaminhoEmail = pctEmail.ImageLocation; //pega o caminho do arquivo do email
                registroCatapora.IdCatapora = Convert.ToInt16(txtID.Text);
                registroCatapora.CaminhoEmail = txtAnexoEmail.Text;
                registroCatapora.CaminhoPrint = txtAnexoPrint.Text;

                registroCatapora.Tratador = txtExecutor.Text;

                registroCatapora.NodesTratados = txtNodesSaturados.Text;
                registroCatapora.TicketAberto = txtTicket.Text;

                registroCatapora.DataCadastro = dtpCadastro.Value.Date; //pega os valores do datetime o .date pega só a data sem horas
                registroCatapora.DataTratamento = dtpTratamento.Value.Date;


                Conexao conectar = new Conexao(); // instancio o objeto conexao para mandar os parametros por referencia

                conectar.atualizaCatapora(registroCatapora);

                
                txtNodesSaturados.Focus();
            }

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty)
            {
                MessageBox.Show("Não foi possível apagar o registro. Deve haver um registro carregado no formulário.", "ERRO AO APAGAR O REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RegistroCatapora registroCatapora = new RegistroCatapora(); //instancio o objeto que sera enviado para salvar no banco pelos métodos da classe conexao

                registroCatapora.IdCatapora = Convert.ToInt32(txtID.Text); //transformo o que esta no campo id para inteiro e atribui ao item ID do catapora


                Conexao conectar = new Conexao(); // instancio o objeto conexao para mandar os parametros por referencia da classe conexao

                conectar.apagaCatapora(registroCatapora); //passo por parametro o objeto com os dados e chamo o metodo apagaCatapora que esta na classe conexao

                if (!String.IsNullOrEmpty(txtAnexoEmail.Text))
                {
                    File.Delete(txtAnexoEmail.Text); //Apaga o anexo relacionado se houver um
                }
                if (!String.IsNullOrEmpty(txtAnexoPrint.Text))
                {
                    File.Delete(txtAnexoPrint.Text); //Apaga o anexo relacionado se houver um
                }

                txtNodesSaturados.Text = String.Empty;
                txtTicket.Text = String.Empty;
                pctEmail.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
                pctPrint.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
                txtNodesSaturados.Focus();
                txtAnexoEmail.Text = String.Empty;
                txtAnexoPrint.Text = String.Empty;
                txtID.Text = string.Empty;
            }
        }

        private void rdbTudo_CheckedChanged(object sender, EventArgs e)
        {
            lblBuscar.Visible = true; // campos da aba consulta
            lblBuscar.Text = "Clique no botão buscar";
            lblDfinal.Visible = false;
            lblDinicial.Visible = false;
            dtpFinal.Visible = false;
            dtpInicial.Visible = false;
            txtBusca.Visible = false;
        }

        private void rdbNode_CheckedChanged(object sender, EventArgs e)
        {
            lblBuscar.Visible = true; // campos da aba consulta
            txtBusca.Visible = true;
            txtBusca.Text = String.Empty;
            lblBuscar.Text = "Digite abaixo o Node requerido:";

            lblDfinal.Visible = false;
            lblDinicial.Visible = false;
            dtpFinal.Visible = false;
            dtpInicial.Visible = false;
        }

        private void rdbTicket_CheckedChanged(object sender, EventArgs e)
        {
            lblBuscar.Visible = true; // campos da aba consulta
            txtBusca.Visible = true;
            txtBusca.Text = String.Empty;
            lblBuscar.Text = "Digite abaixo o Ticket requerido:";

            lblDfinal.Visible = false;
            lblDinicial.Visible = false;
            dtpFinal.Visible = false;
            dtpInicial.Visible = false;
        }

        private void rdbData_CheckedChanged(object sender, EventArgs e)
        {
            lblBuscar.Visible = false; // campos da aba consulta
            txtBusca.Visible = false;
            txtBusca.Text = String.Empty;
            

            lblDfinal.Visible = true;
            lblDinicial.Visible = true;
            dtpFinal.Visible = true;
            dtpInicial.Visible = true;
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            try
            {
                RegistroCatapora registroCatapora = new RegistroCatapora(); //instancio o objeto que sera enviado para salvar no banco pelos métodos da classe conexao
                Conexao conectar = new Conexao(); // instancio o objeto conexao para mandar os parametros por referencia da classe conexao


                int opcaoRadio;

                if (rdbTudo.Checked == true)
                {
                    opcaoRadio = 4;
                    //Conexao.consultaCatapora(registroCatapora, opcaoRadio); //aqui faz a consulta de acordo com cada validação

                    System.Data.DataTable dt = new System.Data.DataTable(); //aqui instancio o data table
                    OleDbDataAdapter da = new OleDbDataAdapter(); //Aqui o mais importante, o método retorna um dataadapter e eu instancio um novo aqui e pego por parametro o valor do que foi tratado no método
                    da = Conexao.consultaCatapora(registroCatapora, opcaoRadio); //passo o valor do radiobutton e o objeto que será utilizado na consulta

                    da.Fill(dt); //preenco o data adapter com os valores retornados

                    dataGridView1.DataSource = dt; //atualizo o datagrid view
                }

                if (rdbData.Checked == true)
                {
                    opcaoRadio = 1;
                    registroCatapora.DataInicial = dtpInicial.Value.Date; //Assim pega só a data
                    registroCatapora.DataFinal = dtpFinal.Value.Date;

                    System.Data.DataTable dt = new System.Data.DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da = Conexao.consultaCatapora(registroCatapora, opcaoRadio);

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                }

                if (rdbNode.Checked == true && txtBusca.Text != String.Empty)
                {
                    opcaoRadio = 3;
                    registroCatapora.NodeConsulta = txtBusca.Text;

                    System.Data.DataTable dt = new System.Data.DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da = Conexao.consultaCatapora(registroCatapora, opcaoRadio);

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }

                if (rdbTicket.Checked == true && txtBusca.Text != String.Empty)
                {
                    opcaoRadio = 2;
                    registroCatapora.TicketConsulta = txtBusca.Text;

                    System.Data.DataTable dt = new System.Data.DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da = Conexao.consultaCatapora(registroCatapora, opcaoRadio);

                    da.Fill(dt);

                    dataGridView1.DataSource = dt.DefaultView;
                }

                //verifico quantas linhas foram descobertas e dou devolutiva na label
                int resultados = dataGridView1.Rows.Count;
                resultados = resultados - 1;
                lblResultados.Visible = true;
                lblResultados.Text = "Foram encontrados " + resultados.ToString() + " registros.";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível realizar a busca. Favor informar o código do erro ao programador. Código: " + ex.Message, "ERRO AO REALIZAR A CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }



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

                OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT * FROM catapora WHERE IdCatapora LIKE'" + refRegistro + "'", conexaoBD);

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

                    this.txtID.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["IdCatapora"]);
                    this.dtpCadastro.Value = Convert.ToDateTime(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["dataCadCatapora"]);
                    this.dtpTratamento.Value = Convert.ToDateTime(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["dataTratCatapora"]);
                    this.txtExecutor.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["tratadorCatapora"]);
                    this.txtTicket.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["ticketCatapora"]);
                    this.txtNodesSaturados.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["nodeSaturadoCatapora"]);
                    this.txtAnexoEmail.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["caminhoEmailCatapora"]);
                    this.txtAnexoPrint.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["caminhoPrintCatapora"]);

                    this.tabControl1.SelectedTab = tabPage1; //aqui mostra a tab onde vai ser jogado as informações

                    if (txtAnexoEmail.Text == String.Empty)
                    {
                        pctEmail.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
                    }
                    else
                    {
                        pctEmail.Load(System.Windows.Forms.Application.StartupPath + @"\image\outroformato.png");
                    }

                    if (txtAnexoPrint.Text == String.Empty)
                    {
                        pctPrint.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
                    }
                    else
                    {
                        pctPrint.Load(System.Windows.Forms.Application.StartupPath + @"\image\outroformato.png");
                    }

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível executar a ação. Código do erro: "+ ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

        }

        private void btnAbrirEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAnexoEmail.Text == String.Empty)
                {
                    MessageBox.Show("Não há email anexo neste processo!", "ERRO AO ABRIR EMAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    System.Diagnostics.Process.Start(txtAnexoEmail.Text); //Abre o arquivo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o anexo em questão. Verifique se possui privilégios de escrita/leitura para o mesmo ou especifique o seguinte erro ao programador: " + ex.Message, "ERRO AO ABRIR ARQUIVO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
           
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null && e.ColumnIndex == 4) || (e.Value != null && e.ColumnIndex == 5) || (e.Value != null && e.ColumnIndex == 6)) //Colore as celulas do datagrid de acordo com os valores
            {
                if (e.Value.Equals(String.Empty))
                {
                    e.CellStyle.BackColor = Color.IndianRed;
                }

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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }


       



        }


        }




    

