using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; //precisa desa classe adicionado tbm em referencia


namespace CATAPORA_BKP
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }


        // VARIAVEIS GLOBAIS
        
        DateTime data = new DateTime();
          

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            //catapora é instanciado e adicionado como Child do MDI
            catapora catapora = new catapora();
            catapora.MdiParent = this;  //define quem é o pai desta janela
            catapora.Show();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }


        // ########### SOLVE

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            Classe usuCad = new Classe();

            toolStripStatusLabel1.Text = "Usuário logado: " + usuCad.UsuarioLogado + "  | ";


            //Aqui iremos redimensionar a tela de acordo com a resolução:

            Screen tela = Screen.FromPoint(this.Location);
            this.Size = tela.WorkingArea.Size;
            this.Location = Point.Empty;
            
            //######### IMPORTANTE, AQUI PEGA O LOCAL DA PASTA PADRÃO, SE NÃO TIVER SETA NA PASTA misc DA PROPRIA APLICAÇÃO

            if (String.IsNullOrEmpty(PastaAPP.resgataPastaPadrao())) //se o retorno da função for vazio seta a pasta padrão como sendo a  de dentro da pasta do aplicativo
            {
                PastaAPP pasta = new PastaAPP();
                pasta.Chave = "pastaAPP";
                pasta.Pasta = System.Windows.Forms.Application.StartupPath;

                PastaAPP.salvarPastaPadrao(pasta); //Aqui salvo o valor na pas

            }
            else //se nao for vazio, ele testa se a página existe se não existir cria
            {
                PastaAPP.existeConstroiCaminho();
            }

            Conexao conectar = new Conexao(); // instancio o objeto conexao para mandar os parametros por referencia

           if (conectar.retornaUser() == false)
            {
                //fecha o app
                this.Close();
            }

            //#########################

        }

        private void tmpMostrador_Tick(object sender, EventArgs e)
        {
            //Aqui pego o datetime e jogo toolstrip no rodape
            
            data = DateTime.Now;

            toolStripStatusLabel2.Text = "Atual : " + data.ToLongDateString() + " - " + data.ToLongTimeString();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fecha o app
            this.Close();
        }

        private void backupDosEquipamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup bkp = new Backup();
            bkp.MdiParent = this; //define quem é o pai desta janela
            bkp.Show();
        }

        private void MOSStripMenuItem1_Click(object sender, EventArgs e)
        {
            Mos mos = new Mos();
            mos.MdiParent = this;
            mos.Show();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testeConecta formulario = new testeConecta();
            formulario.MdiParent = this;
            formulario.Show();
        }

        // ############## COAGULA
    }
}
