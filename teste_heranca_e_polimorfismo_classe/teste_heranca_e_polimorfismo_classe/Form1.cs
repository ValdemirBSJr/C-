using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace teste_heranca_e_polimorfismo_classe
{
    //http://www.mindstick.com/Articles/13169999-ef3b-496c-b502-caef973c3bb2/Using%20ReportViewer%20in%20WinForms%20C
    //http://www.c-sharpcorner.com/UploadFile/mahesh/DataSetReports04252007100945AM/DataSetReports.aspx

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int contagem;
        List<string> LinhaLista = new List<string>();
        List<string> retornadoReport = new List<string>();

        

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Aluno Alcad = new Aluno();

            Professor ProfCad = new Professor();

            ProfCad.Nome = txtNome.Text;
            ProfCad.Tipo = txtTipo.Text;
            ProfCad.Fone = txtFone.Text;
            ProfCad.Cpf = txtCPF.Text;
            ProfCad.Formacao = txtFormacao.Text;

            ProfCad.CadastraUsuario(); //chama o metodo
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstLeitura.Items.Clear();

            this.rptRelatorio.RefreshReport();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            DataTable tabela = new DataTable();
           
            

            string [] textoLido = File.ReadAllLines(System.Windows.Forms.Application.StartupPath + @"/professor.txt"); //salva as linhas num array

            

            lstLeitura.Items.Add("Texto Lido:");




            // https://stackoverflow.com/questions/15778844/how-to-bind-datatable-to-reportviewer-runtime

            foreach (string linhasLidas in textoLido) //adiciona as linhas na listbox
            {
               

                lstLeitura.Items.Add(linhasLidas);
                
                contagem ++;

                //Abaixo preenchemos as linhas
                var colunas = linhasLidas.Split(':');

                
                LinhaLista.Add(linhasLidas);
                retornadoReport.Add(linhasLidas);
                retornadoReport = Professor.retornaLista();
                

              

                


                
           
            }

            //for (int x = 0; x < contagem; x++)//Cria o numero de colunas no datatable
            //{
            //    tabela.Columns.Add(new DataColumn("Coluna" + (contagem + 1).ToString()));




            //}

            //tabela.Columns.Add(new DataColumn("Coluna " + (contagem + 1).ToString()));

            //tabela.Rows.Add(LinhaLista);

            //ds.Tables.Add(tabela);

            //BindingSource bs = new BindingSource();
            //bs.DataSource = tabela;

            //Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource();

            //rds.Value = tabela;

            Microsoft.Reporting.WinForms.ReportDataSource ds = new Microsoft.Reporting.WinForms.ReportDataSource("retorno", retornadoReport);
            //rptRelatorio.LocalReport.DataSources.Clear();
            rptRelatorio.LocalReport.ReportEmbeddedResource = "Report1.rdlc";
            rptRelatorio.LocalReport.DataSources.Add(ds);
            rptRelatorio.LocalReport.Refresh();

            rptRelatorio.RefreshReport();



        }

       
    }
}
