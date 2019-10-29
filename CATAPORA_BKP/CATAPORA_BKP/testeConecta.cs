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
using System.Configuration; //precisa desa classe adicionado tbm em referencia



namespace CATAPORA_BKP
{
    public partial class testeConecta : Form
    {
        public testeConecta()
        {
            InitializeComponent();
        }

        private void testeConecta_Load(object sender, EventArgs e)
        {
            lblPasta.Text = PastaAPP.resgataPastaPadrao() + @"\arquivosControle";

            //Retorna a string contendo os equipamentos cadastrados aqui e salva em uma lista
            List<String> equipamentosResgatados = new List<String>(PastaAPP.retornaEquipamentos());

            foreach (string equips in equipamentosResgatados)
            {
                //Povoa o listBox com os itens resgatados
                lsbEquipamentos.Items.Add(equips);
            }

            //aqui seto o arquivo de ajuda
            helpProvider1.HelpNamespace = System.Windows.Forms.Application.StartupPath + @"/misc/help.html";
            
            
        }

        private void btnPasta_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && folderBrowserDialog1.SelectedPath != null)
            {
                lblPasta.Text = folderBrowserDialog1.SelectedPath + @"\arquivosControle"; //coloca o caminho da pasta selecionada no label

                PastaAPP pasta = new PastaAPP();

                pasta.Chave = "pastaAPP";
                pasta.Pasta = folderBrowserDialog1.SelectedPath;

                PastaAPP.salvarPastaPadrao(pasta); //metodo que mostra a chave

                //Resgatamos o valor da chave

                Configuration resgataConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); //abrimos o app.config



                //Exibe o novo caminho

                System.Windows.Forms.MessageBox.Show("PASTA CONFIGURADA: " + PastaAPP.resgataPastaPadrao());
                //o valor pastaAPP é a chave que configurei no app.config dentro da tag appSettings
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtHost.Text != String.Empty)
            {
                List<String> Equipamentos = new List<string>(PastaAPP.retornaEquipamentos());
                Equipamentos.Add(txtHost.Text);

                //foreach (string Equip in Equipamentos)
                //{
                //    lsbEquipamentos.Items.Add(Equip);
                //}
                lsbEquipamentos.Items.Add(txtHost.Text);

                PastaAPP.salvaEquipamentos(Equipamentos); //metodo pra salvar que recebe a lista
            }

           

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //if (txtHost.Text != String.Empty)
            //{
                lsbEquipamentos.Items.Remove(txtHost.Text);
                PastaAPP.excluiEquipamentos(txtHost.Text);
                txtHost.Text = String.Empty;

            //}
        }

        private void lsbEquipamentos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lsbEquipamentos.SelectedItem != null)
            {
            txtHost.Text = lsbEquipamentos.SelectedItem.ToString();
            }
        }

        private void linkLabel1_DoubleClick(object sender, EventArgs e)
        {
             
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
     
        }

       

      

       
    }
}
