using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace testeCRISTAL_REPORTS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        MySqlConnection minhaconexao;
        MySqlCommand meucomando;
        MySqlDataReader lerconsulta;
       
        string Nome;
        string Senha;

        string meucaminho = "SERVER=localhost; DATABASE=loginesenha; UID=Valdemir; PASSWORD=valdemir";


        private void btnBusca_Click(object sender, EventArgs e)
        {
            
            
            minhaconexao.Open();
            meucomando.CommandText = "SELECT * FROM guardalogin WHERE login='" + txtBusca.Text + "'";


            lerconsulta = meucomando.ExecuteReader();

            while (lerconsulta.Read())
            {
                Nome = lerconsulta["login"].ToString();
                Senha = lerconsulta["senhasc"].ToString();
            }

            Microsoft.Reporting.WinForms.ReportDataSource dataset = new Microsoft.Reporting.WinForms.ReportDataSource("StudentDS", lerconsulta); // set the datasource
            reportViewer1.LocalReport.DataSources.Add(dataset);
            dataset.Value = lerconsulta;

            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport(); // refresh report

            lerconsulta.Close();
            minhaconexao.Close();

            MessageBox.Show("Nome e senha localizados: "+ Nome +", " + Senha);

            MySqlDataAdapter adap = new MySqlDataAdapter();

            adap.SelectCommand = meucomando;

            DataSet myData = new DataSet();

            adap.Fill(myData);

       

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                minhaconexao = new MySqlConnection(meucaminho);
                minhaconexao.Open();
                meucomando = minhaconexao.CreateCommand();

                if (minhaconexao.State == ConnectionState.Open)
                {
                    txtBusca.Enabled = true;


                }
                else
                {
                    txtBusca.Enabled = false;
                    txtBusca.Text = "Sem conexão";
                }

                minhaconexao.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Problema com a conexão. Erro: "+ex.Message);
            }

            this.reportViewer1.RefreshReport();
        }

       
    }
}
