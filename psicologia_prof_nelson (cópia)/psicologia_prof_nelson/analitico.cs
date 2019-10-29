using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace exibe
{
    public partial class analitico : Form
    {
        public analitico()
        {
            InitializeComponent();
        }

        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader consulta;
        string PegaDataInicial;
        string PegaDataFinal;



        string caminho = "SERVER=localhost; DATABASE=imagens; UID=root; PASSWORD=;";

        private void analitico_Load(object sender, EventArgs e)
        {
            
           // dateTimePicker2.CustomFormat = " "; //zero os datetimespickers para string

            /*dateTimePicker1.Value = Convert.ToDateTime("01/01/2013");
            dateTimePicker2.Value = DateTime.Parse("01/01/2013");

            PegaDataInicial = Convert.ToString(dateTimePicker1.Value);
            PegaDataFinal = Convert.ToString(dateTimePicker2.Value);*/
           

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                comando = conexao.CreateCommand();

                if (conexao.State == ConnectionState.Open)
                {

                    txtRespCerta.Enabled = true;
                    txtRespostaDadas.Enabled = true;
                    txtRelevancia.Enabled = true;
                    txtId.Enabled = true;
                    
                }
                else

                {
                    txtRespCerta.Enabled = false;
                    txtRespostaDadas.Enabled = false;
                    txtRelevancia.Enabled = false;
                    txtId.Enabled = false;
                    
                }



            }

            catch (Exception ex)
            {
                MessageBox.Show("Desculpe, não foi possível conectar ao banco de dados. Favor entrar em contato com o administrador. Descritivo do erro: " + ex.Message + ". Código do erro: " + ex.InnerException + ".", "ERRO AO CONECTAR COM OS DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {//inicio do pesquisar


            if ((String.IsNullOrEmpty(txtId.Text)) && (String.IsNullOrEmpty(txtRelevancia.Text)) && (String.IsNullOrEmpty(txtRespCerta.Text)) && (String.IsNullOrEmpty(txtRespostaDadas.Text)) && (String.IsNullOrEmpty(txtIdFinal.Text)))
            {
                comando.Parameters.Clear();
                comando.CommandText = "SELECT * FROM armazenarespostas";
                System.Data.DataTable tabeladedados = new System.Data.DataTable();
                MySqlDataAdapter dadosmontados = new MySqlDataAdapter(comando);
                dadosmontados.Fill(tabeladedados);
                dataGridView1.DataSource = tabeladedados;
            }

            else
            {
                comando.Parameters.Clear(); 
                //comando.CommandText = "SELECT * FROM armazenarespostas WHERE IdVoluntario=@ID";
                //comando.CommandText = "SELECT  * FROM armazenarespostas  WHERE IdVoluntario LIKE (CASE WHEN @ID='' THEN ID ELSE @ID END)";
                //comando.CommandText = "SELECT * FROM armazenarespostas WHERE IdVoluntario=@ID AND respostaDada=@RESPOSTDADA";
                comando.CommandText = "SELECT * FROM armazenarespostas WHERE IdVoluntario LIKE @ID"; 

                comando.Parameters.AddWithValue("@ID", txtId.Text);
                comando.Parameters.AddWithValue(" @RESPOSTDADA", txtRespostaDadas.Text);
                System.Data.DataTable tabeladedados = new System.Data.DataTable();
                MySqlDataAdapter dadosmontados = new MySqlDataAdapter(comando);
                dadosmontados.Fill(tabeladedados);
                dataGridView1.DataSource = tabeladedados;
            }

            

        }//fim do botao pesquisar
    }
}
