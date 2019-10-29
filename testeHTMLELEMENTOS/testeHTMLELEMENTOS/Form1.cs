using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testeHTMLELEMENTOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FORMA DE TRABALHAR SIMPLES:

    //        webBrowser1.DocumentText = "<html><body>Por Favor digite o seu nome:<br/>" +
    //"<input type='text' name='userName'/><br/>" +
    //"<a href='http://www.google.com.br'>continue</a></br>" + "<script></script>" +
    //"<input type='button'name='olabtn' value='executar' onclick=alert('hi') /><br/>" + "</body></html>";


            //FORMA DE TRABALHAR COM STRINGBUILDER:


            string valor = "MEU TEXTO INSERIDO DINAMICAMENTE";

            StringBuilder sb = new StringBuilder();

            sb.Append("<html><body>");
            sb.Append("<a href=");
            sb.Append("\"");
            sb.Append("http://www.microsoft.com");
            sb.Append("\"");
            sb.Append(">Microsoft</a><p>");
            sb.Append("Specify a URL:<br>");
            sb.Append("<form action=''><input type='text' name='address'/>");
            sb.Append("<br><input type='submit'>");
            sb.Append("<p>" + valor + "</p>");
            sb.Append("</form></body></html>");

            webBrowser1.DocumentText = sb.ToString(); //Aqui converto o stringbuilder em texto e passo pro webbrowser



        }

        private void btnNavegar_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtURL.Text); //Código para navegar
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack(); //para voltar
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward(); //para ir
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh(); //para reload
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //vai pro navegador preferido
            webBrowser1.GoSearch();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome(); //vai pra home
        }

        private void btnSalvarPDF_Click(object sender, EventArgs e)
        {
            //teste pra salvar em pdf
            
        }
    }
}
