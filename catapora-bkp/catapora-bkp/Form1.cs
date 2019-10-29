using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace catapora_bkp
{
    public partial class catapora : Form
    {

        public catapora()
        {
            InitializeComponent();
          
        }

        
       
        private void catapora_Load(object sender, EventArgs e) //método que carrega o form
        {
            Classe usuCad = new Classe();
            txtExecutor.Text = usuCad.UsuarioLogado;

            pctEmail.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
            pctPrint.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");

            

        }

        private void btnNovo_Click(object sender, EventArgs e) //método que prepara o form para um novo registro
        {
            txtNodesSaturados.Text = String.Empty;
            pctEmail.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
            pctPrint.Load(System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png");
            txtNodesSaturados.Focus();
        }

        private void btnAddPrint_Click(object sender, EventArgs e) //método que adiciona o print no form e prepara para salvar
        {
            pctPrint.Load(System.Windows.Forms.Application.StartupPath + @"\image\outroformato.png");
        }

        

        private void pctPrint_MouseHover(object sender, EventArgs e) //método de criar o tooltip explicativo print
        {
            if (pctPrint.ImageLocation == System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png")
            {
                Classe info = new Classe(); // instancio um objeto que vai receber o tooltip

                ToolTip toolinfo = new ToolTip();

                toolinfo.SetToolTip(this.pctPrint, "Não há print salvo"); // aqui digo a mensagem que deve ser passada, as confs estão instanciadas na classe Classe

                info.retornaInfo(toolinfo);




            }

            else
            {
                //Aqui vai as mensagens quando o caminho for diferente

                Classe info = new Classe(); // instancio um objeto que vai receber o tooltip

                ToolTip toolinfo = new ToolTip();

                toolinfo.SetToolTip(this.pctPrint, "Print Salvo: " + pctPrint.ImageLocation); // aqui digo a mensagem que deve ser passada, as confs estão instanciadas na classe Classe

                info.retornaInfo(toolinfo);
            }
        }

        private void pctEmail_MouseHover(object sender, EventArgs e) //método de criar o tooltip explicativo email
        {
            if (pctEmail.ImageLocation == System.Windows.Forms.Application.StartupPath + @"\image\semarquivo.png")
            {
                Classe info = new Classe(); // instancio um objeto que vai receber o tooltip

                ToolTip toolinfo = new ToolTip();

                toolinfo.SetToolTip(this.pctEmail, "Não há email salvo"); // aqui digo a mensagem que deve ser passada, as confs estão instanciadas na classe Classe

                info.retornaInfo(toolinfo);




            }

            else
            {
                //Aqui vai as mensagens quando o caminho for diferente

                Classe info = new Classe(); // instancio um objeto que vai receber o tooltip

                ToolTip toolinfo = new ToolTip();

                toolinfo.SetToolTip(this.pctEmail, "Email Salvo: " + pctEmail.ImageLocation); // aqui digo a mensagem que deve ser passada, as confs estão instanciadas na classe Classe

                info.retornaInfo(toolinfo);
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e) //evento que salva os registros
        {

            RegistroCatapora registroCatapora = new RegistroCatapora(); //instancio o objeto que sera enviado para salvar no banco pelos métodos da classe conexao
            Conexao conectar = new Conexao(); // instancio o objeto conexao para mandar os parametros por referencia

            conectar.cadastraCatapora(registroCatapora);
            

        }


        


        }


        }




    

