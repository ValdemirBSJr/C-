using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Data.Common;


namespace CHIPS_MULTI
{
    public partial class frmClaro : Form
    {
        public frmClaro()
        {
            InitializeComponent();
        }

        //variaveis globais


        string meubanco = "BANCO_DADOS.s3db";
        SQLiteConnection conexao = new SQLiteConnection();
        
       


        private void frmClaro_Load(object sender, EventArgs e)
        {
            //Preenche os combobox
            cbStatus.Items.Add(" ");
            cbStatus.Items.Add("BAIXADO");
            cbStatus.Items.Add("CANCELADO");

            cbCHIP.Items.Add(" ");
            cbCHIP.Items.Add("MICRO");
            cbCHIP.Items.Add("NANO");
            cbCHIP.Items.Add("PADRAO");

            //vamos testar se o banco existe no local certo
            if (!File.Exists("BANCO_DADOS.s3db"))
            {
                MessageBox.Show("Desculpe, arquivo do banco de dados não existe! Verifique se ele está na mesma pasta da aplicação ou se está com o nome correto. Nome do banco registrado em sistema: " + meubanco + ".", "ERRO AO CONECTAR AO BANCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCHIP.Enabled = false;
                txtContrato.Enabled = false;
                txtOS.Enabled = false;
                cbCHIP.Items.Clear();
                cbStatus.Items.Clear();
                txtAnexo.Enabled = false;
                txtObs.Enabled = false;
                dtTempo.Enabled = false;
            }

           
            //Trabalhando com datetimepiker:
           /* dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";*/

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            
            string ConsultaSql = "INSERT INTO tblchip (CONTRATO, OS, STATUS_NET_SMS, TIPO_CHIP, ENTREGA, ORIGEM_CHIP, ANEXO, OBS, ID_CHIP) VALUES (@CONT, @OSS, @STAT, @TIP, @ENTR, @ORI, @ANE, @OB, @IDC)";


            string strconexao = @"Data Source=BANCO_DADOS.s3db; Version = 3; New = False; Compress = True;";
            SQLiteConnection conexao = new SQLiteConnection(strconexao);

            SQLiteCommand comando = new SQLiteCommand(ConsultaSql);
            comando = conexao.CreateCommand();
            comando.Parameters.AddWithValue("@CONT", txtContrato.Text);
            comando.Parameters.AddWithValue("@OSS", txtOS.Text);
            comando.Parameters.AddWithValue("@STAT", cbStatus.Text);
            comando.Parameters.AddWithValue("@TIP", cbCHIP.Text);
            comando.Parameters.AddWithValue("@ENTR", dtTempo.Value.ToShortDateString()); //para adicionar datas no datetime picker: dateTimePicker1.Value = DateTime.Now.AddDays(1)
            comando.Parameters.AddWithValue("@ORI", txtCHIP.Text);
            comando.Parameters.AddWithValue("@ANE", txtAnexo.Text);
            comando.Parameters.AddWithValue("@OB", txtObs.Text);
            comando.Parameters.AddWithValue("@IDC", txtIdChip.Text);

            
            comando.CommandText = ConsultaSql;
            conexao.Open();
            
            comando.ExecuteNonQuery();
            
            conexao.Close();

           
            
        }

        private void btnbusca_Click(object sender, EventArgs e)
        {
            DataTable tabelaDadosTemp = new DataTable();
            string ConsultaSql = "SELECT * FROM tblchip WHERE CONTRATO=" + txtCon.Text;
            string strconexao = @"Data Source=BANCO_DADOS.s3db; Version = 3; New = False; Compress = True;";
            SQLiteConnection conexao = new SQLiteConnection(strconexao);
            SQLiteDataAdapter dadosmontados = new SQLiteDataAdapter(ConsultaSql, strconexao);
            dadosmontados.Fill(tabelaDadosTemp);
            dataGridView1.DataSource = tabelaDadosTemp.DefaultView;
        }
    }
}
