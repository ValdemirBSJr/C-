using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.Common;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;


namespace CHIPS_MULTI
{
    public partial class frmClaro : Form
    {
        public frmClaro()
        {
            InitializeComponent();
        }

        //variaveis globais

        string meubanco = "BD_DADOS.mdb";
        int posicaoAtual = 0;
        string caminhoparcialPasta;
        string nomeArquivoFinalSalvo;
        string nomeArquivoFinalSalvoDemanda;
        string anexo;
        string caminhodoAnexo;
        string anexodemanda;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)//Funciona!
        {
            //Esta funcionando, colhe informação digtada e a usa na inoutação de dados.
            //Aqui eu verifico se a aba um do tabcontrol está selecionada no momento que se clicar no enter, se sim ele efetua o botão busca por OS

            if (keyData == Keys.Enter && tabControl1.SelectedIndex == 0)
            {
                this.btnBuscar.PerformClick();
            }
            else if (keyData == Keys.Enter && tabControl1.SelectedIndex == 1)
            {
                this.btnbusca.PerformClick();
            }
            if (keyData == Keys.Enter && tabControl1.SelectedIndex == 2)
            {
                this.btnBuscaDemanda.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData); 
        }


        


        private void frmClaro_Load(object sender, EventArgs e)
        {
            txtContrato.Focus();

            //Preenche os combobox
            cbStatus.Items.Add(" ");
            cbStatus.Items.Add("BAIXADO");
            cbStatus.Items.Add("CANCELADO");

            cbCHIP.Items.Add(" ");
            cbCHIP.Items.Add("MICRO");
            cbCHIP.Items.Add("NANO");
            cbCHIP.Items.Add("PADRAO");

            //seta configuração da picturebox
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            imgAnexo.SizeMode = PictureBoxSizeMode.StretchImage;

            OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb");
            OleDbCommand comando = new OleDbCommand();
            comando.Connection = conexao;
            conexao.Open();

            //vamos testar se o banco existe no local certo
            if (!File.Exists("BD_DADOS.mdb") || (conexao.State == ConnectionState.Closed))
            {
                MessageBox.Show("Desculpe, arquivo do banco de dados não existe ou não está conectado! Verifique se ele está na mesma pasta da aplicação ou se está com o nome correto. Nome do banco registrado em sistema: " + meubanco + ".", "ERRO AO CONECTAR AO BANCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCHIP.Enabled = false;
                txtContrato.Enabled = false;
                txtOS.Enabled = false;
                cbCHIP.Items.Clear();
                cbStatus.Items.Clear();
                txtAnexo.Enabled = false;
                txtObs.Enabled = false;
                dtTempo.Enabled = false;
                txtIdChip.Enabled = false;
            }



            conexao.Close();

            //string usuarioLogado = Environment.UserName; //Pega só a conta do usuário
            //string usuarioLogado = System.Security.Principal.WindowsIdentity.GetCurrent().Name; //PEga nome do computador e do usuario
            //txtUsuario.Text = usuarioLogado;
            //Trabalhando com datetimepiker:
            /* dateTimePicker1.Format = DateTimePickerFormat.Custom;
             dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";*/

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            string usuarioLogado = Environment.UserName; //Pega só a conta do usuário

            txtUsuario.Text = usuarioLogado;

            string ConsultaSql = "INSERT INTO tblchip (CONTRATO, OS, STATUS_NET_SMS, TIPO_CHIP, ENTREGA, ORIGEM_CHIP, ANEXO, OBS, ID_CHIP, USUARIO) VALUES (@CONT, @OSS, @STAT, @TIP, @ENTR, @ORI, @ANE, @OB, @IDC, @USER)";


            OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb");
            OleDbCommand comando = new OleDbCommand();


            comando.Connection = conexao;
            comando.CommandText = ConsultaSql;
            comando.Parameters.AddWithValue("@CONT", txtContrato.Text);
            comando.Parameters.AddWithValue("@OSS", txtOS.Text);
            comando.Parameters.AddWithValue("@STAT", cbStatus.Text);
            comando.Parameters.AddWithValue("@TIP", cbCHIP.Text);
            comando.Parameters.AddWithValue("@ENTR", dtTempo.Value.ToShortDateString()); //para adicionar datas no datetime picker: dateTimePicker1.Value = DateTime.Now.AddDays(1)
            comando.Parameters.AddWithValue("@ORI", txtCHIP.Text);
            comando.Parameters.AddWithValue("@ANE", txtAnexo.Text);
            comando.Parameters.AddWithValue("@OB", txtObs.Text);
            comando.Parameters.AddWithValue("@IDC", txtIdChip.Text);
            comando.Parameters.AddWithValue("@USER", txtUsuario.Text);

            try
            {
                if (txtIdChip.Text == String.Empty || txtOS.Text == String.Empty || txtContrato.Text == String.Empty)
                {
                    MessageBox.Show("Favor preencher os campos corretamente. Os campos referentes a ordem de serviço, contrato NET SMS, origem do Chip, Data de entrega e Id do Chip são obrigatórios!", "ERRO AO SALVAR");

                }
                else
                {
                    
                    conexao.Open();

                    comando.ExecuteNonQuery();

                    conexao.Close();

                    File.Copy(anexo, nomeArquivoFinalSalvo); //Aqui eu crio uma copia do arquivo em anexo

                    MessageBox.Show("Entrega de chip cadastrada com sucesso!", "CADASTRO DE CHIP EFETUADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtCHIP.Text = String.Empty;
                    txtContrato.Text = String.Empty;
                    txtOS.Text = String.Empty;
                    cbCHIP.SelectedIndex = -1; //seleciona o primeiro item da combobox
                    cbStatus.SelectedIndex = -1;
                    txtAnexo.Text = String.Empty;
                    txtObs.Text = String.Empty;
                    dtTempo.Text = String.Empty;
                    txtIdChip.Text = String.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o registro! Favor verificar se há algum valor repetido/errado ou contate o administrador e informe o seguinte código de erro: " + ex.Message, "ERRO AO SALVAR/REGISTRAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnbusca_Click(object sender, EventArgs e)
        {

            OleDbDataAdapter da = new OleDbDataAdapter();

            string liga = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb";

            OleDbConnection conexao = new OleDbConnection(liga);
            if (radioButton1.Checked == true)
            {
                try
                {
                    string ConsultaSql = "SELECT * FROM tblchip WHERE CONTRATO=" + txtCon.Text;
                    da = new OleDbDataAdapter(ConsultaSql, liga);

                    System.Data.DataTable tabelaDadosTemp = new System.Data.DataTable();


                    da.Fill(tabelaDadosTemp);
                    dataGridView1.DataSource = tabelaDadosTemp.DefaultView;

                    if (tabelaDadosTemp.Rows.Count == 1)
                    {
                        lblResultado2.Text = "Foi encontrado um registro para o critério digitado.";
                    }
                    if (tabelaDadosTemp.Rows.Count > 1)
                    {
                        lblResultado2.Text = "Foram encontrados " + tabelaDadosTemp.Rows.Count.ToString() + " registros para o critério digitado.";
                    }

                }


                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível localizar o registro solicitado. Verifique se o critério de busca condiz com o valor informado ou se o valor informado esta correto. Se o erro persistir, informe ao administrador o seguinte código de erro: " + ex.Message, "ERRO AO LOCALIZAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (radioButton2.Checked == true)
            {
                try
                {
                    if (txtCon.Text == string.Empty)
                    {
                        DateTime DatadeBusca = new DateTime();
                        DatadeBusca = DateTime.Now;
                        string ColocaData = DatadeBusca.ToShortDateString();
                        txtCon.Text = ColocaData;
                    }

                    string ConsultaSql = "SELECT * FROM tblchip WHERE ENTREGA=#" + txtCon.Text + "#";
                    da = new OleDbDataAdapter(ConsultaSql, liga);

                    System.Data.DataTable tabelaDadosTemp = new System.Data.DataTable();


                    da.Fill(tabelaDadosTemp);
                    dataGridView1.DataSource = tabelaDadosTemp.DefaultView;

                    if (tabelaDadosTemp.Rows.Count == 1)
                    {
                        lblResultado2.Text = "Foi encontrado um registro para o critério digitado.";
                    }
                    if (tabelaDadosTemp.Rows.Count > 1)
                    {
                        lblResultado2.Text = "Foram encontrados " + tabelaDadosTemp.Rows.Count.ToString() + " registros para o critério digitado.";
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível localizar o registro solicitado. Verifique se o critério de busca condiz com o valor informado ou se o valor informado esta correto. Se o erro persistir, informe ao administrador o seguinte código de erro: " + ex.Message, "ERRO AO LOCALIZAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (radioButton3.Checked == true)
            {
                try
                {
                    string ConsultaSql = "SELECT * FROM tblchip WHERE OS=" + txtCon.Text;
                    da = new OleDbDataAdapter(ConsultaSql, liga);

                    System.Data.DataTable tabelaDadosTemp = new System.Data.DataTable();


                    da.Fill(tabelaDadosTemp);
                    dataGridView1.DataSource = tabelaDadosTemp.DefaultView;

                    if (tabelaDadosTemp.Rows.Count == 1)
                    {
                        lblResultado2.Text = "Foi encontrado um registro para o critério digitado.";
                    }
                    if (tabelaDadosTemp.Rows.Count > 1)
                    {
                        lblResultado2.Text = "Foram encontrados " + tabelaDadosTemp.Rows.Count.ToString() + " registros para o critério digitado.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível localizar o registro solicitado. Verifique se o critério de busca condiz com o valor informado ou se o valor informado esta correto. Se o erro persistir, informe ao administrador o seguinte código de erro: " + ex.Message, "ERRO AO LOCALIZAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (radioButton4.Checked == true)
            {
                try
                {
                    string ConsultaSql = "SELECT * FROM tblchip" + txtCon.Text;
                    da = new OleDbDataAdapter(ConsultaSql, liga);

                    System.Data.DataTable tabelaDadosTemp = new System.Data.DataTable();


                    da.Fill(tabelaDadosTemp);
                    dataGridView1.DataSource = tabelaDadosTemp.DefaultView;

                    if (tabelaDadosTemp.Rows.Count == 1)
                    {
                        lblResultado2.Text = "Foi encontrado um registro para o critério digitado.";
                    }
                    if (tabelaDadosTemp.Rows.Count > 1)
                    {
                        lblResultado2.Text = "Foram encontrados " + tabelaDadosTemp.Rows.Count.ToString() + " registros para o critério digitado.";
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível localizar o registro solicitado. Verifique se o critério de busca condiz com o valor informado ou se o valor informado esta correto. Se o erro persistir, informe ao administrador o seguinte código de erro: " + ex.Message, "ERRO AO LOCALIZAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {


            string ConsultaSql = "UPDATE tblchip SET CONTRATO=@CONT, OS=@OSS, STATUS_NET_SMS=@STAT, TIPO_CHIP=@TIP, ENTREGA=@ENTR, ORIGEM_CHIP=@ORI, ANEXO=@ANE, OBS= @OB, ID_CHIP=@IDC, USUARIO=@USER WHERE OS=" + txtOS.Text;


            OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb");
            OleDbCommand comando = new OleDbCommand();


            comando.Connection = conexao;
            comando.CommandText = ConsultaSql;
            comando.Parameters.AddWithValue("@CONT", txtContrato.Text);
            comando.Parameters.AddWithValue("@OSS", txtOS.Text);
            comando.Parameters.AddWithValue("@STAT", cbStatus.Text);
            comando.Parameters.AddWithValue("@TIP", cbCHIP.Text);
            comando.Parameters.AddWithValue("@ENTR", dtTempo.Value.ToShortDateString()); //para adicionar datas no datetime picker: dateTimePicker1.Value = DateTime.Now.AddDays(1)
            comando.Parameters.AddWithValue("@ORI", txtCHIP.Text);
            comando.Parameters.AddWithValue("@ANE", txtAnexo.Text);
            comando.Parameters.AddWithValue("@OB", txtObs.Text);
            comando.Parameters.AddWithValue("@IDC", txtIdChip.Text);
            comando.Parameters.AddWithValue("@USER", txtUsuario.Text);

            try
            {
                if (txtIdChip.Text == String.Empty || txtOS.Text == String.Empty || txtContrato.Text == String.Empty || txtCHIP.Text == String.Empty)
                {
                    MessageBox.Show("Não foi possível atualizar o registro. Verifique se foram feitas atualizações válidas.", "ERRO AO EDITAR");

                }
                else
                {
                    conexao.Open();

                    comando.ExecuteNonQuery();

                    conexao.Close();
                    MessageBox.Show("Edição do registro cadastrado com sucesso!", "ATUALIZAÇÃO DE REGISTRO EFETUADA", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível atualizar o registro! Favor verificar se há algum valor repetido/errado ou contate o administrador e informe o seguinte código de erro: " + ex.Message, "ERRO AO SALVAR/REGISTRAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {


            txtCHIP.Text = String.Empty;
            txtContrato.Text = String.Empty;
            cbCHIP.SelectedIndex = -1; //seleciona o primeiro item da combobox
            cbStatus.SelectedIndex = -1;
            txtAnexo.Text = String.Empty;
            txtObs.Text = String.Empty;
            dtTempo.Text = String.Empty;
            txtIdChip.Text = String.Empty;




            OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb");

            OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT * FROM tblchip WHERE OS like '" + txtOS.Text + "%" + "'", conexao);
            DataSet ds = new DataSet();

            //preenche o dataset com os dados da tabela tblchip
            adaptador.Fill(ds, "tblchip");

            //verifica se existem linhas na tabela. Caso não exista é emitido uma mensagem avisando que não existem dados.
            if (ds.Tables["tblchip"].Rows.Count < 0)
            {
                MessageBox.Show("Não foram encontrados resultados para a sua pesquisa");
                lblResultado.Text = "Nenhum registro encontrado para OS digitada";
            }
            else
            {

                posicaoAtual = 0;
                this.txtContrato.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["CONTRATO"]); // preenche o campo txt com o valor da primeira linha da tabela e a coluna
                this.txtOS.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["OS"]);
                this.cbStatus.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["STATUS_NET_SMS"]);
                this.cbCHIP.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["TIPO_CHIP"]);
                this.dtTempo.Value = Convert.ToDateTime(ds.Tables["tblchip"].Rows[posicaoAtual]["ENTREGA"]);
                this.txtCHIP.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["ORIGEM_CHIP"]);
                this.txtAnexo.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["ANEXO"]);
                this.txtObs.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["OBS"]);
                this.txtIdChip.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["ID_CHIP"]);
                this.txtUsuario.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["USUARIO"]);

                if (ds.Tables["tblchip"].Rows.Count == 1)
                {
                    lblResultado.Text = "Foi encontrado 1 resultado para sua busca.";
                }
                else
                {
                    lblResultado.Text = "Foram encontrados " + Convert.ToString(ds.Tables["tblchip"].Rows.Count) + " resultados para sua busca.";
                }

            }
        }

        private void cbCHIP_TextChanged(object sender, EventArgs e)
        {
            if (cbCHIP.Text == "MICRO")
            {
                pictureBox1.Load(System.Windows.Forms.Application.StartupPath + @"\image\chip_micro.jpg");
            }

            if (cbCHIP.Text == "NANO")
            {
                pictureBox1.Load(System.Windows.Forms.Application.StartupPath + @"\image\chip_nano.jpg");
            }

            if (cbCHIP.Text == "PADRAO")
            {
                pictureBox1.Load(System.Windows.Forms.Application.StartupPath + @"\image\chip_padrao.jpg");
            }

            if (cbCHIP.Text == " ")
            {
                pictureBox1.Image = null; //limpa o picturebox
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtOS.Text == String.Empty)
            {
                MessageBox.Show("Erro ao apagar registro. O campo de ordem de serviço deve estar preenchido com um número de OS válido!", "ERRO AO APAGAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                string ConsultaSql = "DELETE FROM tblchip WHERE OS=@OSS";

                OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb");
                OleDbCommand comando = new OleDbCommand();


                comando.Connection = conexao;
                comando.CommandText = ConsultaSql;
                comando.Parameters.AddWithValue("@OSS", txtOS.Text);

                try
                {
                    if (MessageBox.Show("Tem certeza que deseja cancelar a OS de número: " + txtOS.Text + " referente ao contrato: " + txtContrato.Text + "?", "APAGAR ENTREGA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        conexao.Open();
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Entrega excluída com sucesso!");
                        if (txtAnexo.Text != String.Empty)
                        {
                            File.Delete(txtAnexo.Text); //Apaga o anexo relacionado se houver um
                        }

                        txtCHIP.Text = String.Empty;
                        txtContrato.Text = String.Empty;
                        cbCHIP.SelectedIndex = -1; //seleciona o primeiro item da combobox
                        cbStatus.SelectedIndex = -1;
                        txtAnexo.Text = String.Empty;
                        txtObs.Text = String.Empty;
                        dtTempo.Text = String.Empty;
                        txtIdChip.Text = String.Empty;
                        txtOS.Text = String.Empty;
                        pictureBox1.Image = null;
                        txtUsuario.Text = String.Empty;


                    }
                    else
                    {
                        return; //Se a resposta for não, não faz nada
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao fazer a operação! Código do erro: " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
        }

        private void btnAnexo_Click(object sender, EventArgs e)
        {
            DateTime DataRealizacao;
            DataRealizacao = DateTime.Now;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    //string anexo;

                    char delimitador = '\\';
                    string nomeArquivoFim;


                    caminhoparcialPasta = @"D:\CHIPS MULTI\" + Convert.ToDateTime(DataRealizacao).ToString("MMM-yyyy");
                    if (!Directory.Exists(caminhoparcialPasta))
                    {
                        Directory.CreateDirectory(caminhoparcialPasta); //Testo, se a pasta não existe, cria ela
                    }

                    anexo = openFileDialog1.FileName; //pega o caminho do arquivo completo
                    string[] nomeAnexo = anexo.Split(delimitador); //divide ele de acordo com as barras das pastas

                    nomeArquivoFim = nomeAnexo.Last(); //aqui eu pego o ultimo valor que corresponde ao nome do arquivo

                    caminhodoAnexo = "\\OS_ " + txtOS.Text + "-" + nomeArquivoFim;
                    nomeArquivoFinalSalvo = String.Concat(caminhoparcialPasta, caminhodoAnexo); //junta tudo para salvar de acordo com os criterios

                    //txtAnexo.Text = Convert.ToString(openFileDialog1.FileName);

                    //File.Copy(anexo, nomeArquivoFinalSalvo); //Aqui eu crio uma copia do arquivo
                    //FileInfo copia = new FileInfo(anexo);
                    //copia.CopyTo(nomeArquivoFinalSalvo);

                    txtAnexo.Text = nomeArquivoFinalSalvo;



                }


            }

            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o arquivo! Contate o administrador e informe o seguinte código de erro: " + ex.Message);
            }

        }

        private void btnAbAnexo_Click(object sender, EventArgs e)
        {
            if (txtAnexo.Text == String.Empty)
            {
                MessageBox.Show("Não há anexo neste processo!", "ERRO AO ABRIR ARQUIVO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                System.Diagnostics.Process.Start(txtAnexo.Text); //Abre o arquivo
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistema desenvolvido por Valdemir Bezerra (n5669203) para o ADM de João Pessoa. Telefone: (83) 3044-2209. Email: valdemir.junior2@netservicos.com.br)", "SOBRE O DESENVOLVEDOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lblDica.Text = "Busca por contrato. Digite o valor do contrato NET.";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lblDica.Text = "Para localizar por data, o padrão dd/mm/aaaa deve ser adotado.";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            lblDica.Text = "Digite uma Ordem de Serviço.";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            lblDica.Text = "Busca todos os registros. Não é necessário colocar um critério";
        }

       

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            try
            {
                //verifica se a posição atual é maior que zero.Sendo maior, diminuimos uma posição para mostrar a linha anterior
                OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb");

                OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT * FROM tblchip WHERE OS like '" + txtOS.Text + "%" + "'", conexao);
                DataSet ds = new DataSet();

                //preenche o dataset com os dados da tabela tblchip
                adaptador.Fill(ds, "tblchip");

                if (posicaoAtual > 0)
                {
                    posicaoAtual--;

                    this.txtContrato.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["CONTRATO"]); // preenche o campo txt com o valor da primeira linha da tabela e a coluna
                    this.txtOS.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["OS"]);
                    this.cbStatus.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["STATUS_NET_SMS"]);
                    this.cbCHIP.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["TIPO_CHIP"]);
                    this.dtTempo.Value = Convert.ToDateTime(ds.Tables["tblchip"].Rows[posicaoAtual]["ENTREGA"]);
                    this.txtCHIP.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["ORIGEM_CHIP"]);
                    this.txtAnexo.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["ANEXO"]);
                    this.txtObs.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["OBS"]);
                    this.txtIdChip.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["ID_CHIP"]);
                    this.txtUsuario.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["USUARIO"]);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível localizar um registro. Verifique se o critério de busca está correto. Caso haja registros, talves não haja nenhum registro antes do solicitado. Erro:" + ex.Message, "ERRO AO LOCALIZAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            try
            {
                //verifica se a posição atual é maior que zero.Sendo maior, diminuimos uma posição para mostrar a linha anterior
                OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb");

                OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT * FROM tblchip WHERE OS like '" + txtOS.Text + "%" + "'", conexao);
                DataSet ds = new DataSet();

                //preenche o dataset com os dados da tabela tblchip
                adaptador.Fill(ds, "tblchip");

                if (posicaoAtual < ds.Tables["CLIENTE"].Rows.Count - 1)
                {
                    posicaoAtual++;

                    this.txtContrato.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["CONTRATO"]); // preenche o campo txt com o valor da primeira linha da tabela e a coluna
                    this.txtOS.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["OS"]);
                    this.cbStatus.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["STATUS_NET_SMS"]);
                    this.cbCHIP.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["TIPO_CHIP"]);
                    this.dtTempo.Value = Convert.ToDateTime(ds.Tables["tblchip"].Rows[posicaoAtual]["ENTREGA"]);
                    this.txtCHIP.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["ORIGEM_CHIP"]);
                    this.txtAnexo.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["ANEXO"]);
                    this.txtObs.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["OBS"]);
                    this.txtIdChip.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["ID_CHIP"]);
                    this.txtUsuario.Text = Convert.ToString(ds.Tables["tblchip"].Rows[posicaoAtual]["USUARIO"]);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível localizar um registro. Verifique se o critério de busca está correto. Caso haja registros, talves não haja nenhum registro depois do solicitado. Erro:" + ex.Message, "ERRO AO LOCALIZAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void frmClaro_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ultimo Dia: Criamos uma variavel DateTime com o ano atual, o mês atual e o dia é a quantidade de dias que o mês corrente possui.
            //A função DateTime.DaysInMonth recebe como parametro o ano(int) e o mês(int) e retorna a quantidade de dias(int).
            //DateTime ultimoDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
            //ultimoDia.Day.CompareTo(30);
            int diasDoMes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); //Pega o ultimo dia do mes
            DateTime hoje = new DateTime();
            hoje = DateTime.Now;
            int Datadodia = hoje.Day;

            try
            {

                if (diasDoMes == Datadodia) //Se for o ultimo dia do mes, faz backup do BD
                {
                    DateTime DataRealizacao;
                    DataRealizacao = DateTime.Now;

                    caminhoparcialPasta = @"D:\CHIPS MULTI\Backup-ACCESS_" + Convert.ToDateTime(DataRealizacao).ToString("MMM-yyyy");
                    if (!Directory.Exists(caminhoparcialPasta))
                    {
                        Directory.CreateDirectory(caminhoparcialPasta); //Testo, se a pasta não existe, cria ela

                        File.Copy(System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb", caminhoparcialPasta + @"\BD_DADOS.mdb"); //Aqui faço backup do BD
                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível fazer o backup do banco de dados! Favor apresentar o seguinte código de erro ao administrador: " + ex.Message);
            }


            
            

            //Pergunta se quer fechar, se for cancelar, não fecha.
            if (MessageBox.Show("Tem certeza que deseja sair?", "FECHAR O PROGRAMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }


        }
        //Abaixo temos os eventos dos radiobutton das buscas

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            lblBuscarDescritivo.Text = "Data Inicial";
            lblDataFinal.Visible = true;
            txtDataFinal.Visible = true;
            lblAjuda.Text = "Digite um valor inicial e um valor final para a busca. Caso não digite nada nos campos data inicial e final, serão considerados as data atual e a de ontem. Formato das datas: dd/mm/aaaa com as barras.";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            lblBuscarDescritivo.Text = "Digite uma Data";
            lblDataFinal.Visible = false;
            txtDataFinal.Visible = false;
            lblAjuda.Text = "Digite uma data no formato dd/mm/aaaa com as barras. Caso não digite nenhuma data, a data atual será considerada.";
            lblBuscarDescritivo.Visible = true;
            txtBuscaControle.Visible = true;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            lblBuscarDescritivo.Text = "Digite um ID";
            lblDataFinal.Visible = false;
            txtDataFinal.Visible = false;
            lblAjuda.Text = "Digite um ID válido que corresponde a um registro. Cada registro possui um Número de ID único que identifica os registros. Para carregar um registro e ter acesso a ele, faça uma busca pelo ID.";
            lblBuscarDescritivo.Visible = true;
            txtBuscaControle.Visible = true;
        }

        private void btnSalvarDemanda_Click(object sender, EventArgs e)
        {
            string usuarioLogado = Environment.UserName; //Pega só a conta do usuário

            txtusuariodemanda.Text = usuarioLogado;

            string ConsultaSql = "INSERT INTO confi (DATA_RECEBIMENTO, QTDE_CHIPS, ANEXO, USUARIO) VALUES (@DAT, @QTDE, @ANEX, @USUA)";


            OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb");
            OleDbCommand comando = new OleDbCommand();


            comando.Connection = conexao;
            comando.CommandText = ConsultaSql;
            comando.Parameters.AddWithValue("@DAT", dtDemandas.Value.ToShortDateString());
            comando.Parameters.AddWithValue("@QTDE", txtQuantidadeChip.Text);
            comando.Parameters.AddWithValue("@ANEX", txtAnexodemandas.Text);
            comando.Parameters.AddWithValue("@USUA", txtusuariodemanda.Text);


            try
            {
                if (txtQuantidadeChip.Text == String.Empty || txtAnexodemandas.Text == String.Empty)
                {
                    MessageBox.Show("Favor preencher os campos corretamente. Os campos referentes a quantidades de chip e anexo são obrigatórios!", "ERRO AO SALVAR");

                }
                else
                {
                    conexao.Open();

                    comando.ExecuteNonQuery();

                    conexao.Close();

                    File.Copy(anexodemanda, nomeArquivoFinalSalvoDemanda); //Aqui eu crio uma copia do arquivo

                    MessageBox.Show("Registro de demanda passada pela MSO cadastrado com sucesso!", "CADASTRO DE DEMANDA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtAnexodemandas.Text = String.Empty;
                    txtQuantidadeChip.Text = String.Empty;
                    txtID.Text = String.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o registro! Favor verificar se há algum valor repetido/errado ou contate o administrador e informe o seguinte código de erro: " + ex.Message, "ERRO AO SALVAR/REGISTRAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            lblAjuda.Text = "Busca todos os registros. Nenhum critério é necessário para a busca. Clique no botão PESQUISAR.";
            lblDataFinal.Visible = false;
            txtDataFinal.Visible = false;
            lblBuscarDescritivo.Visible = false;
            txtBuscaControle.Visible = false;

        }

        private void btnIncluirAnexoDemanda_Click(object sender, EventArgs e)
        {
            DateTime DataRealizacao;
            DataRealizacao = DateTime.Now;
            try
            {
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {

                    

                    char delimitador = '\\';
                    string nomeArquivoFim;
                    char delimitadorExtensao = '.';
                    string ExtensaoArquivo;

                    caminhoparcialPasta = @"D:\CHIPS MULTI\DemandasDiarias_" + Convert.ToDateTime(DataRealizacao).ToString("MMM-yyyy");
                    if (!Directory.Exists(caminhoparcialPasta))
                    {
                        Directory.CreateDirectory(caminhoparcialPasta); //Testo, se a pasta não existe, cria ela
                    }

                    anexodemanda = openFileDialog2.FileName; //pega o caminho do arquivo completo
                    string[] nomeAnexo = anexodemanda.Split(delimitador); //divide ele de acordo com as barras das pastas
                    string[] pegaExtensaoArquivo = anexodemanda.Split(delimitadorExtensao); //Aqui eu divido por ponto para pegar a extensão do arquivo

                    nomeArquivoFim = nomeAnexo.Last(); //aqui eu pego o ultimo valor que corresponde ao nome do arquivo
                    ExtensaoArquivo = pegaExtensaoArquivo.Last(); //Aqui pego a extensão do arquivo para lançar a imagem no ImageBox

                    caminhodoAnexo = "\\Demanda_Data- " + Convert.ToDateTime(DataRealizacao).ToString("dd-MMM-yyyy") + "_" + nomeArquivoFim;
                    nomeArquivoFinalSalvoDemanda = String.Concat(caminhoparcialPasta, caminhodoAnexo); //junta tudo para salvar de acordo com os criterios

                    //txtAnexo.Text = Convert.ToString(openFileDialog1.FileName);

                    //File.Copy(anexodemanda, nomeArquivoFinalSalvoDemanda); //Aqui eu crio uma copia do arquivo
                    //FileInfo copia = new FileInfo(anexo);
                    //copia.CopyTo(nomeArquivoFinalSalvo);

                    txtAnexodemandas.Text = nomeArquivoFinalSalvoDemanda;
                    //Abaixo verifico a extensão do arquivo e mudo o ícone do anexo conforme o tipo

                    if ((ExtensaoArquivo == "doc" || ExtensaoArquivo == "docx") || (ExtensaoArquivo == "DOC" || ExtensaoArquivo == "DOCX"))
                    {
                        imgAnexo.Load(System.Windows.Forms.Application.StartupPath + @"\image\word.png");
                    }
                    if ((ExtensaoArquivo == "xls" || ExtensaoArquivo == "xlsx") || (ExtensaoArquivo == "XLS" || ExtensaoArquivo == "XLSX") || (ExtensaoArquivo == "xlsb" || ExtensaoArquivo == "XLSB") || (ExtensaoArquivo == "xlsm" || ExtensaoArquivo == "XLSM"))
                    {
                        imgAnexo.Load(System.Windows.Forms.Application.StartupPath + @"\image\excel.png");
                    }
                    if (ExtensaoArquivo == "pdf" || ExtensaoArquivo == "PDF")
                    {
                        imgAnexo.Load(System.Windows.Forms.Application.StartupPath + @"\image\pdf.png");
                    }
                    if (txtAnexodemandas.Text == String.Empty)
                    {
                        imgAnexo.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
                    }
                    if (ExtensaoArquivo == "msg" || ExtensaoArquivo == "MSG")
                    {
                        imgAnexo.Load(System.Windows.Forms.Application.StartupPath + @"\image\outlook.png");
                    }
                    else
                    {
                        imgAnexo.Load(System.Windows.Forms.Application.StartupPath + @"\image\outroformato.png");
                    }

                    // cria o ToolTip e associa o Form container.
                    ToolTip toolTip1 = new ToolTip();

                    // define o delays para o ToolTip.
                    toolTip1.AutoPopDelay = 50000; //tempo que fica exibido se o mouse está parado
                    toolTip1.InitialDelay = 10; //O tempo que conta para ele aparecer após o mouse parar
                    toolTip1.ReshowDelay = 10; //O tempo que ela precisa para aparecer de novo quando o mouse para
                    // Força o texto ToolTip text a ser exibido se o formulario for ativo ou não
                    toolTip1.ShowAlways = true;

                    // Define o texto da ToolTip 
                    toolTip1.SetToolTip(this.imgAnexo, "Arquivo salvo: " + nomeArquivoFim);

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o arquivo! Contate o administrador e informe o seguinte código de erro: " + ex.Message);
            }
        }

        private void btnAbrirAnexoDemanda_Click(object sender, EventArgs e)
        {
            if (txtAnexodemandas.Text == String.Empty)
            {
                MessageBox.Show("Não há anexo nesta demanda!", "ERRO AO ABRIR ARQUIVO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                System.Diagnostics.Process.Start(txtAnexodemandas.Text); //Abre o arquivo
            }
        }

        private void btnEditarDemanda_Click(object sender, EventArgs e)
        {
            string ConsultaSql = "UPDATE confi SET DATA_RECEBIMENTO=@DAT, QTDE_CHIPS=@QTDE, ANEXO=@ANEX, USUARIO=@USUA WHERE ID=" + txtID.Text;


            OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb");
            OleDbCommand comando = new OleDbCommand();


            comando.Connection = conexao;
            comando.CommandText = ConsultaSql;

            comando.Parameters.AddWithValue("@DAT", dtDemandas.Value.ToShortDateString()); //para adicionar datas no datetime picker: dateTimePicker1.Value = DateTime.Now.AddDays(1)
            comando.Parameters.AddWithValue("@QTDE", txtQuantidadeChip.Text);
            comando.Parameters.AddWithValue("@ANEX", txtAnexodemandas.Text);
            comando.Parameters.AddWithValue("@USUA", txtusuariodemanda.Text);


            try
            {
                if (txtQuantidadeChip.Text == String.Empty || txtAnexodemandas.Text == String.Empty)
                {
                    MessageBox.Show("Não foi possível atualizar a demanda. Verifique se foram feitas atualizações válidas.", "ERRO AO EDITAR");

                }
                else
                {
                    conexao.Open();

                    comando.ExecuteNonQuery();

                    conexao.Close();
                    MessageBox.Show("Edição da demanda cadastrada com sucesso!", "ATUALIZAÇÃO DE DEMANDA EFETUADA", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível atualizar o registro! Favor verificar se há algum valor repetido/errado ou contate o administrador e informe o seguinte código de erro: " + ex.Message, "ERRO AO SALVAR/REGISTRAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirDemanda_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty)
            {
                MessageBox.Show("Erro ao apagar registro. O campo de ID deve estar preenchido com um número válido(este registro não existe)!", "ERRO AO APAGAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                string ConsultaSql = "DELETE FROM confi WHERE ID=@IDD";

                OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb");
                OleDbCommand comando = new OleDbCommand();


                comando.Connection = conexao;
                comando.CommandText = ConsultaSql;
                comando.Parameters.AddWithValue("@IDD", txtID.Text);

                try
                {
                    if (MessageBox.Show("Tem certeza que deseja cancelar a demanda de número de ID: " + txtID.Text + " referente a data de recebimento " + dtDemandas.Value.ToShortDateString() + "?", "APAGAR DEMANDA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        conexao.Open();
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Demanda excluída com sucesso!");
                        if (txtAnexodemandas.Text != String.Empty)
                        {
                            File.Delete(txtAnexodemandas.Text); //Apaga o anexo relacionado se houver um
                        }

                        txtID.Text = String.Empty;
                        txtQuantidadeChip.Text = String.Empty;
                        imgAnexo.Image = null;
                        txtusuariodemanda.Text = String.Empty;



                    }
                    else
                    {
                        return; //Se a resposta for não, não faz nada
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao fazer a operação! Código do erro: " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
        }

        

        private void btnBuscaDemanda_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();

            string liga = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb";

            OleDbConnection conexao = new OleDbConnection(liga);

            if (radioButton5.Checked == true)
            {
                try
                {
                    if (txtBuscaControle.Text == string.Empty) //Aqui eu texto se tem uma data digitada. Se não tem, ele coloca a data de hoje
                    {
                        DateTime agora = new DateTime();
                        agora = DateTime.Now;
                       string agoraEmTexto = agora.ToShortDateString();
                       txtBuscaControle.Text = agoraEmTexto;
                    }
                   
                    string ConsultaSql = "SELECT * FROM confi WHERE DATA_RECEBIMENTO=#" +txtBuscaControle.Text + "#";
                    da = new OleDbDataAdapter(ConsultaSql, liga);

                    System.Data.DataTable tabelaDadosTemp = new System.Data.DataTable();


                    da.Fill(tabelaDadosTemp);
                    dataGridView2.DataSource = tabelaDadosTemp.DefaultView;

                    if (tabelaDadosTemp.Rows.Count == 0) //conta quantos registros tem e exibe na label
                    {
                        lblcontademanda.Text = "Não foram encontrados registros para essa consulta.";
                    }

                    if (tabelaDadosTemp.Rows.Count == 1)
                    {
                        lblcontademanda.Text = "Foi encontrado um registro. Dê um duplo clique nele para abrir.";
                    }
                    else
                    {
                        lblcontademanda.Text = "Foram encontrados " + tabelaDadosTemp.Rows.Count.ToString() + " registros.";
                    }
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível localizar um registro pelo critério digitado. Código do erro: " + ex.Message);
                }
            }

            if (radioButton6.Checked == true)
            {
                try
                {
                    if (txtDataFinal.Text == string.Empty) //poe a data final o valor de hoje, caso esteja vazio
                    {
                        DateTime datafinal = new DateTime();
                        datafinal = DateTime.Now;
                        string insereumaDataFinal = datafinal.ToShortDateString();
                        txtDataFinal.Text = insereumaDataFinal;

                    }
                    if (txtBuscaControle.Text == string.Empty)
                    {
                        DateTime datainicial = new DateTime();
                        datainicial = DateTime.Now.AddDays(-1); //pega a data de hoje e diminue de um dia
                        string insereumaDataInicial = datainicial.ToShortDateString();
                        txtBuscaControle.Text = insereumaDataInicial;
                    }

                    string ConsultaSql = "SELECT * FROM confi WHERE DATA_RECEBIMENTO BETWEEN #" + txtBuscaControle.Text + "# AND #" + txtDataFinal.Text+ "#";
                    da = new OleDbDataAdapter(ConsultaSql, liga);

                    System.Data.DataTable tabelaDadosTemp = new System.Data.DataTable();


                    da.Fill(tabelaDadosTemp);
                    dataGridView2.DataSource = tabelaDadosTemp.DefaultView;

                    if (tabelaDadosTemp.Rows.Count == 0) //conta quantos registros tem e exibe na label
                    {
                        lblcontademanda.Text = "Não foram encontrados registros para essa consulta.";
                    }

                    if (tabelaDadosTemp.Rows.Count == 1)
                    {
                        lblcontademanda.Text = "Foi encontrado um registro. Dê um duplo clique nele para abrir.";
                    }
                    else
                    {
                        lblcontademanda.Text = "Foram encontrados " + tabelaDadosTemp.Rows.Count.ToString() + " registros.";
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível localizar um registro pelo critério digitado. Verifique se a data inicial é menor que a final. Código do erro: " + ex.Message);
                }
            }

            if (radioButton7.Checked == true)
            {
                try
                {
                    string ConsultaSql = "SELECT * FROM confi WHERE ID=" + txtBuscaControle.Text;
                    da = new OleDbDataAdapter(ConsultaSql, liga);

                    System.Data.DataTable tabelaDadosTemp = new System.Data.DataTable();


                    da.Fill(tabelaDadosTemp);
                    dataGridView2.DataSource = tabelaDadosTemp.DefaultView;

                    if (tabelaDadosTemp.Rows.Count == 0) //conta quantos registros tem e exibe na label
                    {
                        lblcontademanda.Text = "Não foram encontrados registros para essa consulta.";
                    }

                    if (tabelaDadosTemp.Rows.Count == 1)
                    {
                        lblcontademanda.Text = "Foi encontrado um registro. Dê um duplo clique nele para abrir.";
                    }
                    else
                    {
                        lblcontademanda.Text = "Foram encontrados " + tabelaDadosTemp.Rows.Count.ToString() + " registros.";
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível localizar um registro pelo critério digitado. Verifique se a data inicial é menor que a final. Código do erro: " + ex.Message);
                }
            }

            if (radioButton8.Checked == true)
            {
                try
                {
                    string ConsultaSql = "SELECT * FROM confi";
                    da = new OleDbDataAdapter(ConsultaSql, liga);

                    System.Data.DataTable tabelaDadosTemp = new System.Data.DataTable();


                    da.Fill(tabelaDadosTemp);
                    dataGridView2.DataSource = tabelaDadosTemp.DefaultView;

                    if (tabelaDadosTemp.Rows.Count == 0) //conta quantos registros tem e exibe na label
                    {
                        lblcontademanda.Text = "Não foram encontrados registros para essa consulta.";
                    }

                    if (tabelaDadosTemp.Rows.Count == 1)
                    {
                        lblcontademanda.Text = "Foi encontrado um registro. Dê um duplo clique nele para abrir.";
                    }
                    else
                    {
                        lblcontademanda.Text = "Foram encontrados " + tabelaDadosTemp.Rows.Count.ToString() + " registros.";
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível localizar um registro pelo critério digitado. Verifique se a data inicial é menor que a final. Código do erro: " + ex.Message);
                }
            }

           
            
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int linha; //aqui iremos pegar os indices da tabela datagrid e apagar o registro
                int coluna;


                string refRegistro; //abaixo colhemos o indice de linha e coluna ou seja o campo "ID"
                coluna = dataGridView2.CurrentCell.ColumnIndex;
                linha = dataGridView2.CurrentRow.Index;

                refRegistro = dataGridView2.Rows[linha].Cells[coluna].Value.ToString();

                OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb");

                OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT * FROM confi WHERE ID like '" + refRegistro + "'", conexao);
                DataSet ds = new DataSet();

                //preenche o dataset com os dados da tabela tblchip
                adaptador.Fill(ds, "confi");

                //verifica se existem linhas na tabela. Caso não exista é emitido uma mensagem avisando que não existem dados.
                if (ds.Tables["confi"].Rows.Count < 0)
                {
                    MessageBox.Show("Não foram encontrados resultados para a sua pesquisa");

                }
                else
                {

                    posicaoAtual = 0;

                    this.txtID.Text = Convert.ToString(ds.Tables["confi"].Rows[posicaoAtual]["ID"]);
                    this.dtDemandas.Value = Convert.ToDateTime(ds.Tables["confi"].Rows[posicaoAtual]["DATA_RECEBIMENTO"]);

                    this.txtQuantidadeChip.Text = Convert.ToString(ds.Tables["confi"].Rows[posicaoAtual]["QTDE_CHIPS"]);
                    this.txtAnexodemandas.Text = Convert.ToString(ds.Tables["confi"].Rows[posicaoAtual]["ANEXO"]);

                    this.txtusuariodemanda.Text = Convert.ToString(ds.Tables["confi"].Rows[posicaoAtual]["USUARIO"]);

                    string anexo;

                    char delimitador = '\\';
                    string nomeArquivoFim;
                    char delimitadorExtensao = '.';
                    string ExtensaoArquivo;
                    //DateTime DataRealizacao = DateTime.Now;
                    //caminhoparcialPasta = @"D:\CHIPS MULTI\DemandasDiarias_" + Convert.ToDateTime(DataRealizacao).ToString("MMM-yyyy");

                    anexo = txtAnexodemandas.Text; //pega o caminho do arquivo completo
                    string[] nomeAnexo = anexo.Split(delimitador); //divide ele de acordo com as barras das pastas
                    string[] pegaExtensaoArquivo = anexo.Split(delimitadorExtensao); //Aqui eu divido por ponto para pegar a extensão do arquivo

                    nomeArquivoFim = nomeAnexo.Last(); //aqui eu pego o ultimo valor que corresponde ao nome do arquivo
                    ExtensaoArquivo = pegaExtensaoArquivo.Last(); //Aqui pego a extensão do arquivo para lançar a imagem no ImageBox

                    //caminhodoAnexo = "\\Demanda_Data- " + Convert.ToDateTime(DataRealizacao).ToString("dd-MMM-yyyy") + "_" + nomeArquivoFim;
                    //nomeArquivoFinalSalvo = String.Concat(caminhoparcialPasta, caminhodoAnexo); //junta tudo para salvar de acordo com os criterios

                    //txtAnexo.Text = Convert.ToString(openFileDialog1.FileName);

                    //File.Copy(anexo, nomeArquivoFinalSalvo); //Aqui eu crio uma copia do arquivo
                    //FileInfo copia = new FileInfo(anexo);
                    //copia.CopyTo(nomeArquivoFinalSalvo);

                    //txtAnexodemandas.Text = nomeArquivoFinalSalvo;
                    //Abaixo verifico a extensão do arquivo e mudo o ícone do anexo conforme o tipo

                    if ((ExtensaoArquivo == "doc" || ExtensaoArquivo == "docx") || (ExtensaoArquivo == "DOC" || ExtensaoArquivo == "DOCX"))
                    {
                        imgAnexo.Load(System.Windows.Forms.Application.StartupPath + @"\image\word.png");
                    }
                    if ((ExtensaoArquivo == "xls" || ExtensaoArquivo == "xlsx") || (ExtensaoArquivo == "XLS" || ExtensaoArquivo == "XLSX") || (ExtensaoArquivo == "xlsb" || ExtensaoArquivo == "XLSB") || (ExtensaoArquivo == "xlsm" || ExtensaoArquivo == "XLSM"))
                    {
                        imgAnexo.Load(System.Windows.Forms.Application.StartupPath + @"\image\excel.png");
                    }
                    if (ExtensaoArquivo == "pdf" || ExtensaoArquivo == "PDF")
                    {
                        imgAnexo.Load(System.Windows.Forms.Application.StartupPath + @"\image\pdf.png");
                    }
                    if (txtAnexodemandas.Text == String.Empty)
                    {
                        imgAnexo.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
                    }
                    if (ExtensaoArquivo == "msg" || ExtensaoArquivo == "MSG")
                    {
                        imgAnexo.Load(System.Windows.Forms.Application.StartupPath + @"\image\outlook.png");
                    }
                    else
                    {
                        imgAnexo.Load(System.Windows.Forms.Application.StartupPath + @"\image\outroformato.png");
                    }

                    // cria o ToolTip e associa o Form container.
                    ToolTip toolTip1 = new ToolTip();

                    // define o delays para o ToolTip.
                    toolTip1.AutoPopDelay = 50000; //tempo que fica exibido se o mouse está parado
                    toolTip1.InitialDelay = 10; //O tempo que conta para ele aparecer após o mouse parar
                    toolTip1.ReshowDelay = 10; //O tempo que ela precisa para aparecer de novo quando o mouse para
                    // Força o texto ToolTip text a ser exibido se o formulario for ativo ou não
                    toolTip1.ShowAlways = true;

                    // Define o texto da ToolTip 
                    toolTip1.SetToolTip(this.imgAnexo, "Arquivo salvo: " + nomeArquivoFim);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o registro. Favor contatar o administrador e informar o código do erro: " + ex.Message);
            }

       

      

    }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtContrato.Text = String.Empty;
            txtOS.Text = String.Empty;
            cbCHIP.SelectedIndex = -1; //seleciona o primeiro item da combobox
            cbStatus.SelectedIndex = -1;
            txtIdChip.Text = String.Empty;
            txtCHIP.Text = String.Empty;
            txtAnexo.Text = String.Empty;
            txtObs.Text = String.Empty;
            txtUsuario.Text = String.Empty;
            txtContrato.Focus();

        }

        private void btnNovademanda_Click(object sender, EventArgs e)
        {
            txtID.Text = String.Empty;
            txtQuantidadeChip.Text = String.Empty;
            txtusuariodemanda.Text = String.Empty;
            txtAnexodemandas.Text = String.Empty;
            imgAnexo.Image = null;
            txtQuantidadeChip.Focus();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.ColumnIndex == 2) //Colore as celulas do datagrid de acordo com os valores
            {
                if (e.Value.Equals("CANCELADO"))
                {
                    e.CellStyle.BackColor = Color.IndianRed;
                }

                else if (e.Value.Equals("BAIXADO"))
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                 //Ao selecionar uma aba, ele dá foco em um txt específico
                
                    txtContrato.Focus();
            }

            else if (tabControl1.SelectedIndex == 1)
            {
                txtCon.Focus();
            }

            else
            {
                txtQuantidadeChip.Focus();
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.ColumnIndex == 2) //Colore as celulas do datagrid de acordo com os valores, se for maior igual que 1, verde, se for 0 vermelho
            {
                if (Convert.ToInt32(e.Value)>=1)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }

                else
                {
                    e.CellStyle.BackColor = Color.IndianRed;
                }
            }
        }

      
            

}}
