using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usando_report_teste1
{

    //http://www.c-sharpcorner.com/UploadFile/mahesh/ReportViewerObject04172007111636AM/ReportViewerObject.aspx
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            this.reportViewer1.RefreshReport();

            List<Estudante> lista = Sala.pegaEstudantes();


            reportViewer1.LocalReport.DataSources.Clear(); 

            reportViewer1.LocalReport.ReportEmbeddedResource = "Report1.rdlc";

            Microsoft.Reporting.WinForms.ReportDataSource dadosReporte = new Microsoft.Reporting.WinForms.ReportDataSource("Relação de estudantes", lista);

            dadosReporte.Value = lista;

            reportViewer1.LocalReport.DataSources.Add(dadosReporte);

            //reportViewer1.LocalReport.Refresh();

            this.reportViewer1.RefreshReport(); 
            
        }
    }
}
