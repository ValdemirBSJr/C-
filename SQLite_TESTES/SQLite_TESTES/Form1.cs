using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SQLite_TESTES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCarrega_Click(object sender, EventArgs e)
        {
            DataTable tabelaDadosTemp = new DataTable();
            string ConsultaSql = "SELECT * FROM infocliente";
            string strconexao = @"Data Source=BDteste.s3db";
            SQLiteConnection conexao = new SQLiteConnection(strconexao);
            SQLiteDataAdapter dadosmontados = new SQLiteDataAdapter(ConsultaSql, strconexao);
            dadosmontados.Fill(tabelaDadosTemp);
            dataGridView1.DataSource = tabelaDadosTemp.DefaultView;


        }
    }
}
