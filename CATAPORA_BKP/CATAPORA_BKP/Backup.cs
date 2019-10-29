using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration; //precisa desa classe adicionado tbm em referencia
using System.IO;
using System.Data.Common;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;
using ICSharpCode.SharpZipLib.Zip; //adicionamos a dll que consta nesse projeto e as referencias a partir daqui
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.GZip;
using System.Diagnostics;

namespace CATAPORA_BKP
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)//Funciona!
        {
            //Esta funcionando, colhe informação digtada e a usa na inoutação de dados.
            //Aqui eu verifico se a aba um do tabcontrol está selecionada no momento que se clicar no enter, se sim ele efetua o botão busca por catapora

            if (keyData == Keys.Enter)
            {
                this.btnConsultaBKP.PerformClick();
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected string indicesEQUIPAMENTOS()
        { //Aqui pego os indices dos equipamentos marcados

            List<String> retornaIndices = new List<String>();
            string resultados = String.Empty;

            for (int i = 0; i <= (clbEquipamentos.Items.Count - 1); i++)
            {

                if (clbEquipamentos.GetItemChecked(i))
                {
                    retornaIndices.Add(Convert.ToString(i));
                }

            }

            resultados = String.Join(";", retornaIndices);

            return resultados;
        }

        private void Backup_Load(object sender, EventArgs e)
        {
            //clbEquipamentos.Items.Add("Exemplo1");
            //clbEquipamentos.Items.Add("Exemplo2", true);
            List<String> equipamentosResgatados = new List<String>(PastaAPP.retornaEquipamentos());

            foreach (string equips in equipamentosResgatados)
            {
                //Povoa o listBox com os itens resgatados
                clbEquipamentos.Items.Add(equips);
            }

            this.dtpDataBKP.Value = DateTime.Now.Date;
            this.dtpFinal.Value = DateTime.Now.Date;
            this.dtpInicio.Value = DateTime.Now.Date.AddDays(-1);

            chbSenhaBkp.Enabled = true;
            txtSenhaBkp.Enabled = true;
            btnGeraSenha.Enabled = true;

        }

        private void ckbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTodos.Checked == true)
            {//verifico se está marcado se estiver, conta quantos equipamentos tem e marca todos
                for (int i = 0; i < clbEquipamentos.Items.Count; i++)
                {
                    clbEquipamentos.SetItemChecked(i, true);
                }

                lblqItens.Text = clbEquipamentos.Items.Count.ToString();
            }

            if (ckbTodos.Checked == false)
            {//verifico se está não está marcados, conta quantos equipamentos tem e desmarca todos
                for (int i = 0; i < clbEquipamentos.Items.Count; i++)
                {
                    clbEquipamentos.SetItemChecked(i, false);
                }

                lblqItens.Text = "0";
            }
            
        }

        private void btnSalvarBKP_Click(object sender, EventArgs e)
        {//Aqui vai codigo pra percorrer os itens do checkedbox e ver quais estão marcados e desmarcados
            int i;
            StringBuilder equipamentosMarcados = new StringBuilder();
            StringBuilder equipamentosDesmarcados = new StringBuilder();


          //  equipamentosMarcados.Append("Itens selecionados: \n");
            //equipamentosDesmarcados.Append("Itens não selecionados: \n");


            for (i = 0; i <= (clbEquipamentos.Items.Count - 1); i++)
            {
                if (clbEquipamentos.GetItemChecked(i))
                {
                   // equipamentosMarcados.Append("Item " + (i + 1).ToString() + ": " + clbEquipamentos.Items[i].ToString() + ".\n");
                    equipamentosMarcados.Append(clbEquipamentos.Items[i].ToString() + ";");
                    txtEquipamentos.Text = equipamentosMarcados.ToString();
                }

                if (!clbEquipamentos.GetItemChecked(i))
                {
                   // equipamentosDesmarcados.Append("Item " + (i + 1).ToString() + ": " + clbEquipamentos.Items[i].ToString() + ".\n");
                    equipamentosDesmarcados.Append(clbEquipamentos.Items[i].ToString() + ";");
                }
            }

            //MessageBox.Show(equipamentosMarcados.ToString() + equipamentosDesmarcados.ToString());

            

            if (txtCaminho.Text == String.Empty ||  (txtSenhaBkp.Text == String.Empty && chbSenhaBkp.Checked == true) ||clbEquipamentos.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Selecione um arquivo de Backup para salvar e marque os equipamentos válidos para serem salvos. Necessário também por senha do arquivo .zip");
            }
            else
            {
                Classe usuCad = new Classe(); //instancio pra pegar o usuario cadastrado

                RegistroBKP registroBKP = new RegistroBKP();

                registroBKP.UsuarioBKP = usuCad.UsuarioLogado;
                registroBKP.DataCadBKP = dtpDataBKP.Value.Date;
                registroBKP.CaminhoBKP = txtCaminho.Text;
                

                if (equipamentosDesmarcados.ToString() != String.Empty)
                {
                    txtEquipamentos.Text = equipamentosMarcados.ToString();
                    registroBKP.AderenteBKP = equipamentosDesmarcados.ToString();
                }
                else
                {
                    txtEquipamentos.Text = equipamentosMarcados.ToString();
                    registroBKP.AderenteBKP = "SIM";
                }
                registroBKP.EquipamentosBKP = txtEquipamentos.Text;

               //aqui nessa função que tá lá no topo dessa mesma classe, eu pego os indices e salvo numa lista do tipo string
                registroBKP.IndicesBKP = indicesEQUIPAMENTOS();
                txtIndices.Text = registroBKP.IndicesBKP;
                registroBKP.SenhaBKP = txtSenhaBkp.Text;

                Conexao conectar = new Conexao();

                conectar.cadastraBKP(registroBKP);


                txtCaminho.Text = String.Empty;
                txtEquipamentos.Text = String.Empty;
                pcbOK.Image = null;
                txtIdbkp.Text = String.Empty;
                txtIndices.Text = String.Empty;
                txtSenhaBkp.Text = String.Empty;

                ckbTodos.Checked = false;

            }


        }

        private void btnAddBKP_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataSalvamento;
                dataSalvamento = DateTime.Now;

                string caminhoSalvo = PastaAPP.resgataPastaPadrao() + @"\arquivosControle\bkp\bkp" + dataSalvamento.ToString("HH-mm-ss_dd-MMM-yyyy") + ".zip";
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

                   
                    
                       
                        

                    //ZipEntry arquivoSalvo = new ZipEntry(nomeArquivoFim);//Aqui vai o arquivo que será salvo
                    //zipOutPut.PutNextEntry(arquivoSalvo); //aqui seto ele no arquivo

                    zipOutPut.Finish(); //finaliza o arquivo
                    zipOutPut.Close(); //fecha o arquivo

                    ZipFile arquivoZip = new ZipFile(caminhoSalvo); //aqui converto o arquivo criado para zip da biblioteca

                    //abaixo crio o condicional para salvar a senha
                    if (chbSenhaBkp.Checked == true && !String.IsNullOrWhiteSpace(txtSenhaBkp.Text))
                    {
                        arquivoZip.Password = txtSenhaBkp.Text;
                    }
                    if (chbSenhaBkp.Checked == true && String.IsNullOrWhiteSpace(txtSenhaBkp.Text))
                    {//se nao tiver marcado, chama a função do botão e atribui
                        btnGeraSenha.PerformClick();
                        arquivoZip.Password = txtSenhaBkp.Text;
                    }

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

                txtCaminho.Text = caminhoSalvo;

                pcbOK.Load(System.Windows.Forms.Application.StartupPath + @"/image/Check.png");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o arquivo. Informe o código do erro: " + ex.Message, "ERRO AO SALVAR BKP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOpcaoBuscabkp.Checked == false)
            {
                label3.Visible = true;
                label4.Visible = true;
                dtpInicio.Visible = true;
                dtpFinal.Visible = true;
            }

            if (chkOpcaoBuscabkp.Checked == true)
            {
                label3.Visible = false;
                label4.Visible = false;
                dtpInicio.Visible = false;
                dtpFinal.Visible = false;
            }
        }

        private void btnAbrirBKP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCaminho.Text == String.Empty)
                {
                    MessageBox.Show("Não há backup anexo neste processo!", "ERRO AO ABRIR BKP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    System.Diagnostics.Process.Start(txtCaminho.Text); //Abre o arquivo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o anexo em questão. Verifique se possui privilégios de escrita/leitura para o mesmo ou especifique o seguinte erro ao programador: " + ex.Message, "ERRO AO ABRIR ARQUIVO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCaminho.Text = String.Empty;
            txtEquipamentos.Text = String.Empty;
            pcbOK.Image = null;
            txtIdbkp.Text = String.Empty;
            txtIndices.Text = String.Empty;
            txtSenhaBkp.Text = String.Empty;

            ckbTodos.Checked = false;
            chbSenhaBkp.Enabled = true;
            txtSenhaBkp.Enabled = true;
            btnGeraSenha.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int i;
            StringBuilder equipamentosMarcados = new StringBuilder();
            StringBuilder equipamentosDesmarcados = new StringBuilder();


            //  equipamentosMarcados.Append("Itens selecionados: \n");
            //equipamentosDesmarcados.Append("Itens não selecionados: \n");


            for (i = 0; i <= (clbEquipamentos.Items.Count - 1); i++)
            {
                if (clbEquipamentos.GetItemChecked(i))
                {
                    // equipamentosMarcados.Append("Item " + (i + 1).ToString() + ": " + clbEquipamentos.Items[i].ToString() + ".\n");
                    equipamentosMarcados.Append(clbEquipamentos.Items[i].ToString() + ";");
                    txtEquipamentos.Text = equipamentosMarcados.ToString();
                }

                if (!clbEquipamentos.GetItemChecked(i))
                {
                    // equipamentosDesmarcados.Append("Item " + (i + 1).ToString() + ": " + clbEquipamentos.Items[i].ToString() + ".\n");
                    equipamentosDesmarcados.Append(clbEquipamentos.Items[i].ToString() + ";");
                }
            }


            if (txtCaminho.Text == String.Empty || (txtSenhaBkp.Text == String.Empty && chbSenhaBkp.Checked == true) || clbEquipamentos.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Selecione um arquivo de Backup para salvar ou marque os equipamentos válidos para serem salvos. Se marcou que o anexo tem senha, favor colocar uma senha.");
            }
            else
            {
                Classe usuCad = new Classe(); //instancio pra pegar o usuario cadastrado

                RegistroBKP registroBKP = new RegistroBKP();

                registroBKP.IdBKP = Convert.ToInt16(txtIdbkp.Text);
                registroBKP.CaminhoBKP = txtCaminho.Text;
                registroBKP.DataCadBKP = dtpDataBKP.Value.Date;
                registroBKP.EquipamentosBKP = txtEquipamentos.Text;
                registroBKP.UsuarioBKP = usuCad.UsuarioLogado;

                if (equipamentosDesmarcados.ToString() != String.Empty)
                {
                    txtEquipamentos.Text = equipamentosMarcados.ToString();
                    registroBKP.AderenteBKP = equipamentosDesmarcados.ToString();
                }
                else
                {
                    txtEquipamentos.Text = equipamentosMarcados.ToString();
                    registroBKP.AderenteBKP = "SIM";
                }
                registroBKP.EquipamentosBKP = txtEquipamentos.Text;
                registroBKP.IndicesBKP = indicesEQUIPAMENTOS();
                txtIndices.Text = registroBKP.IndicesBKP;
                registroBKP.SenhaBKP = txtSenhaBkp.Text;
                chbSenhaBkp.Enabled = false;
                txtSenhaBkp.Enabled = false;
                btnGeraSenha.Enabled = false;

                Conexao conectar = new Conexao();

                conectar.atualizaBKP(registroBKP);

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtIdbkp.Text == String.Empty)
            {
                MessageBox.Show("Não foi possível apagar o registro de backup. Deve haver um registro carregado no formulário.", "ERRO AO APAGAR O REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RegistroBKP registroBKP = new RegistroBKP();

                registroBKP.IdBKP = Convert.ToInt16(txtIdbkp.Text);

                Conexao conectar = new Conexao();

                conectar.apagaBKP(registroBKP);

                if (!String.IsNullOrEmpty(txtCaminho.Text))
                {
                    File.Delete(txtCaminho.Text);
                }

                txtIdbkp.Text = String.Empty;
                txtCaminho.Text = String.Empty;
                txtEquipamentos.Text = String.Empty;
                ckbTodos.Checked = false;
                pcbOK.Image = null;
                txtIndices.Text = String.Empty;
                txtSenhaBkp.Text = String.Empty;

            }
        }

        private void btnConsultaBKP_Click(object sender, EventArgs e)
        {
            try
            {
                RegistroCatapora registroCatapora = new RegistroCatapora();
                RegistroBKP registroBKP = new RegistroBKP();
                Conexao conectar = new Conexao();

                int checkOpcao; //0 = tudo, 1 = por data

                if (chkOpcaoBuscabkp.Checked == true)
                {
                    checkOpcao = 0;

                    System.Data.DataTable dt = new System.Data.DataTable(); //aqui instancio o data table
                    OleDbDataAdapter da = new OleDbDataAdapter(); //Aqui o mais importante, o método retorna um dataadapter e eu instancio um novo aqui e pego por parametro o valor do que foi tratado no método
                    da = Conexao.consultaBKP(registroCatapora, checkOpcao); //passo o valor do radiobutton e o objeto que será utilizado na consulta

                    da.Fill(dt); //preenco o data adapter com os valores retornados

                    dataGridView1.DataSource = dt; //atualizo o datagrid view

                }

                if (chkOpcaoBuscabkp.Checked == false)
                {
                    checkOpcao = 1;

                    registroCatapora.DataInicial = dtpInicio.Value.Date; //Assim pega só a data
                    registroCatapora.DataFinal = dtpFinal.Value.Date;


                    System.Data.DataTable dt = new System.Data.DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da = Conexao.consultaBKP(registroCatapora, checkOpcao);

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }

                //verifico quantos registros foram retornados
                int resultados = dataGridView1.Rows.Count;
                resultados = resultados - 1;
                lblResultados.Visible = true;
                lblResultados.Text = "Foram encontrados " + resultados.ToString() + " registros.";

            }
            catch(Exception ex)
            {
                MessageBox.Show("Não foi possível realizar a busca. Favor informar o código do erro ao programador. Código: " + ex.Message, "ERRO AO REALIZAR A CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ckbTodos.Checked = true;
                int i;
                StringBuilder equipamentosMarcados = new StringBuilder();
                StringBuilder equipamentosDesmarcados = new StringBuilder();


                //  equipamentosMarcados.Append("Itens selecionados: \n");
                //equipamentosDesmarcados.Append("Itens não selecionados: \n");


                for (i = 0; i <= (clbEquipamentos.Items.Count - 1); i++)
                {
                    if (clbEquipamentos.GetItemChecked(i))
                    {
                        // equipamentosMarcados.Append("Item " + (i + 1).ToString() + ": " + clbEquipamentos.Items[i].ToString() + ".\n");
                        equipamentosMarcados.Append(clbEquipamentos.Items[i].ToString() + ";");
                        txtEquipamentos.Text = equipamentosMarcados.ToString();
                    }

                    if (!clbEquipamentos.GetItemChecked(i))
                    {
                        // equipamentosDesmarcados.Append("Item " + (i + 1).ToString() + ": " + clbEquipamentos.Items[i].ToString() + ".\n");
                        equipamentosDesmarcados.Append(clbEquipamentos.Items[i].ToString() + ";");
                    }
                }


                int linha, coluna;
                //acima, setamos variaveis que irão receber valores das linhas e colunas para triangular os cliques na coluna

                string refRegistro;
                //acima iremos colher exatamente o primeiro campo da coluna, ou seja o id

                linha = dataGridView1.CurrentRow.Index;
                coluna = dataGridView1.CurrentCell.ColumnIndex;

                refRegistro = dataGridView1.Rows[linha].Cells[coluna].Value.ToString(); //pego o valor exato do primeiro item de cada linha

                OleDbConnection conexaoBD = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb");

                OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT * FROM backup WHERE idbkp LIKE'" + refRegistro + "'", conexaoBD);

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

                    this.txtIdbkp.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["idbkp"]);
                    this.dtpDataBKP.Value = Convert.ToDateTime(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["dataCadBkp"]);
                    this.txtCaminho.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["caminhobkp"]);
                    this.txtEquipamentos.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["equipamentosBkp"]);
                    string aderenteBKP = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["aderenteBkp"]);
                    this.txtIndices.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["indicesBkp"]);
                    this.txtSenhaBkp.Text = Convert.ToString(ds.Tables["retornoConsulta"].Rows[posicaoAtual]["senhaBkp"]);
                    //abaixo carrega o checklist conforme o registro

                    if (aderenteBKP == "SIM")
                    {
                        //se for aderente tem todos os equipamentos, logo carrega todos
                        ckbTodos.Checked = true;
                    }
                    else
                    {//se nao, zera ele e marca os especificos
                        ckbTodos.Checked = false;

                        List<String> equipamentosResgatados = new List<String>(txtIndices.Text.Split(';'));

                        foreach (string equips in equipamentosResgatados)
                        {
                            clbEquipamentos.SetItemChecked(Convert.ToInt16(equips), true);
                        }


                        
                        
                    }


                    if (txtCaminho.Text == String.Empty)
                    {
                        pcbOK.Image = null;
                    }

                    else
                    {
                        pcbOK.Load(System.Windows.Forms.Application.StartupPath + @"/image/Check.png");
                    }

                }

                chbSenhaBkp.Enabled = false;
                txtSenhaBkp.Enabled = false;
                btnGeraSenha.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível executar a ação. Código do erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chbSenhaBkp_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSenhaBkp.Checked == true)
            {
                txtSenhaBkp.Enabled = true;
                btnGeraSenha.Enabled = true;
            }
            else
            {
                txtSenhaBkp.Text = String.Empty;
                txtSenhaBkp.Enabled = false;
                btnGeraSenha.Enabled = false;
            }
        }

        private void btnGeraSenha_Click(object sender, EventArgs e)
        {
            //Aqui geramos uma senha aleatória para a arquivo zip
            int tamanho = 5; //nosso campo só recebe 5 caracteres
            string senha = string.Empty;
            

            for (int i = 0; i < tamanho; i++)
            {
                Random aleatorio = new Random(); //uso classe do C# random que vai gerar valor aleatório

                int codigo = Convert.ToInt32(aleatorio.Next(48, 122).ToString());

                if ((codigo >= 48 && codigo <= 57) || (codigo >= 97 && codigo <= 122))
                {
                     

                    string _char = ((char)codigo).ToString();
                    if (!senha.Contains(_char))
                    {
                        senha += _char;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    i--;
                }
            }

            //MessageBox.Show("A Senha é: " + senha);
            txtSenhaBkp.Text = senha;
        }

        private void txtSenhaBkp_DoubleClick(object sender, EventArgs e)
        {
            this.btnGeraSenha.PerformClick(); //se der dois cliques no campo, chama a função do butão gera senha
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
            if ((e.Value != null && e.ColumnIndex == 4)) //Colore as celulas do datagrid de acordo com os valores
            {
                if (e.Value.Equals("SIM"))
                {
                    e.CellStyle.BackColor = Color.LawnGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.IndianRed;
                }


            }

            if ((e.Value != null && e.ColumnIndex == 7)) //Colore as celulas do datagrid de acordo com os valores
            {
                if (e.Value.Equals(String.Empty))
                {
                    e.CellStyle.BackColor = Color.IndianRed;
                }
            }
        }

        private void clbEquipamentos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Aqui contamos dinamicamente os itens marcados e jogamos na label de resultados
            int contador = clbEquipamentos.CheckedItems.Count;

            if (e.NewValue == CheckState.Checked)
            {
                ++contador;
            }

            if (e.NewValue == CheckState.Unchecked)
            {
                --contador;
            }

            lblqItens.Text = contador.ToString();

        }

 



    }
}
