using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices; //classe pra usar as dlls user32
using System.Configuration; //classe para poder manipular o App.Config

namespace Login_PREPARA_PORTIFOLIO_3P
{

    
    public partial class Form1 : Form
    {
        //Muído pra fazer place holder
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32
                SendMessage(
                                IntPtr hWnd,
                                int msg,
                                int wParam,
                                [MarshalAs(UnmanagedType.LPWStr)]string lParam
                            );

        private const int EM_SETCUEBANNER = 0x1501;
        //fim do muido do place holder

        

        public Form1()
        {
            InitializeComponent();

            //Isto abaixo é o place holder

            SendMessage(txtLogin.Handle, EM_SETCUEBANNER, 0, "Seu login aqui...");
            SendMessage(mskSenha.Handle, EM_SETCUEBANNER, 0, "Senha...");
            SendMessage(mskConfirma.Handle, EM_SETCUEBANNER, 0, "Confirme senha...");

            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            btnImagem.Load(Application.StartupPath + @"\imagens\btnEntrarClique.png"); //aqui muda o icone quando clica

            Usuario user = new Usuario(); //aqui cria objeto usuario que ira receber login e senha
            user.Login = txtLogin.Text.Trim();
            user.Senha = mskSenha.Text.Trim();//Trim tira os espaços
            Conectar conect = new Conectar(); //aqui cria o objeto de conexao ao BD

            conect.fazerLogin(user); //passa o valor do objeto usuario para o bd por parametro

            

           
            
        }

        private void btnImagem_MouseEnter(object sender, EventArgs e) //aqui muda o botão quando passo o mouse
        {
            btnImagem.Load(Application.StartupPath + @"\imagens\btnEntrarFocus.png");
        }

        private void btnImagem_MouseLeave(object sender, EventArgs e) //aqui quando tiro o mouse
        {
            btnImagem.Load(Application.StartupPath + @"\imagens\btnEntrar.png");
        }

        private void lnkLembrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //abaixo evocaremos um context menu streip para sabermos se quer se cadastar ou cancelar serviço

            ContextMenuStrip menuOpcoes = new ContextMenuStrip();
            

            ToolStripItem cadastrar = menuOpcoes.Items.Add("Cadastrar... ");
            ToolStripItem cancelar = menuOpcoes.Items.Add("Cancelar cadastro... ");

            menuOpcoes.Show(Cursor.Position); //aqui mostra quando for clicado  a tag 'Cursor.Position' é para que o menu apareça onde cliquei, onde esta o mouse

            cadastrar.Click += new EventHandler(cadastrar_Click); //aqui criei um metodo descrito logo abaixo abaixo para realizar ações ao clicar no menu
            cancelar.Click += new EventHandler(cancelar_Click);
            
            
        }

        void cancelar_Click(object sender, EventArgs e) //aqui os eventos para quando clicar no menu apagar
        {
            ToolStripItem clickedItem = sender as ToolStripItem; //necessario para evocar metodo do click
            btnApagar.Visible = true;
            btnApagar.Enabled = true;
            System.Windows.Forms.Form.ActiveForm.Height = 208; //aumentamos o form TAMANHO DOR FORM: 341; 208
            btnCancelar.Visible = true;
            btnCancelar.Enabled = true;

            mskConfirma.Visible = false;
            mskConfirma.Enabled = false;

            btnImagem.Visible = false; //deixamos o botão de logar invisivel e inacessivel
            btnImagem.Enabled = false;

            txtLogin.Text = string.Empty;
            mskSenha.Text = string.Empty;

        }


        void cadastrar_Click(object sender, EventArgs e) //aqui os eventos que ocorrem quando clicamos no menu cadastrar
        {
            ToolStripItem clickedItem = sender as ToolStripItem; //necessario para evocar metodo do click
            
            btnImagem.Visible = false; //deixamos o botão de logar invisivel e inacessivel
            btnImagem.Enabled = false;
            btnApagar.Visible = false;
            btnApagar.Enabled = false;

            System.Windows.Forms.Form.ActiveForm.Height = 400; //aumentamos o form TAMANHO DO FORM: 341; 208

            lblConfirma.Visible = true;
            mskConfirma.Visible = true;
            mskConfirma.Enabled = true;

            btnCadastrar.Visible = true;
            btnCadastrar.Enabled = true;
            btnCancelar.Visible = true;
            btnCancelar.Enabled = true;

            lblEndereco.Visible = true;
            lblRG.Visible = true;
            lblTel.Visible = true;
            lblCNH.Visible = true;
            lblCPF.Visible = true;
            txtEndereco.Visible = true;
            txtRG.Visible = true;
            txtCNH.Visible = true;
            txtFone.Visible = true;
            txtCPF.Visible = true;



            lnkLembrar.Visible = false;

            txtLogin.Text = string.Empty;
            mskConfirma.Text = string.Empty;
            mskSenha.Text = string.Empty;

            txtEndereco.Text = string.Empty;
            txtRG.Text = string.Empty;
            txtCNH.Text = string.Empty;
            txtFone.Text = string.Empty;
            txtCPF.Text = string.Empty;

            txtLogin.Focus();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnImagem.Visible = true; //deixamos o botão de logar invisivel e inacessivel
            btnImagem.Enabled = true;

            System.Windows.Forms.Form.ActiveForm.Height = 208; //aumentamos o form TAMANHO DOR FORM: 341; 208

            lblConfirma.Visible = false;
            mskConfirma.Visible = false;
            mskConfirma.Enabled = false;

            btnCadastrar.Visible = false;
            btnCadastrar.Enabled = false;
            btnCancelar.Visible = false;
            btnCancelar.Enabled = false;

            lnkLembrar.Visible = true;

            btnApagar.Visible = false;
            btnApagar.Enabled = false;

            lblEndereco.Visible = false;
            lblRG.Visible = false;
            lblTel.Visible = false;
            lblCNH.Visible = false;
            lblCPF.Visible = false;
            txtEndereco.Visible = false;
            txtRG.Visible = false;
            txtCNH.Visible = false;
            txtFone.Visible = false;
            txtCPF.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {//Aqui buscamos a info no app.config 

                Configuration config =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); //abrimos o app.config

                string valorResgatado;

                valorResgatado = Convert.ToString(config.AppSettings.Settings["UltimoLog"].Value); //seta na variavel o valor achado la

                if (valorResgatado != string.Empty) //se nao for vazio, bota no txtbox
                {

                    txtLogin.Text = valorResgatado;
                    txtLogin.SelectAll();//deixa já selecionado todo o texto
                }
            }

            catch (Exception ex)
            {
                return;
            }
           
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Usuario novo = new Usuario(); //aqui crio o objeto que receberá os dados de cadastro

            novo.Login = txtLogin.Text.Trim(); //aqui eu passo os dados digitados, o trim tira os espaços vazios
            novo.Senha = mskSenha.Text.Trim();
            novo.ConfSenha = mskConfirma.Text.Trim();
            novo.Cnh = txtCNH.Text.Trim();
            novo.Cpf = txtCPF.Text.Trim();
            novo.Telefone = txtFone.Text.Trim();
            novo.Endereco = txtEndereco.Text.Trim();
            novo.Rg = txtRG.Text.Trim();


            Conectar cadastrar = new Conectar(); //aqui crio o objeto que está na classe conectar

            cadastrar.cadastraUsuario(novo); //aqui passo os dados digitados por parametro no objeto cadastrar para o metodo que faz o cadastro e passando os valores por parametro do objeto novo

            txtLogin.Text = string.Empty;
            mskConfirma.Text = string.Empty;
            mskSenha.Text = string.Empty;

            txtEndereco.Text = string.Empty;
            txtRG.Text = string.Empty;
            txtCNH.Text = string.Empty;
            txtFone.Text = string.Empty;
            txtCPF.Text = string.Empty;
        }

        private void btnApagar_Click(object sender, EventArgs e) //aqui chamamos para pagar
        {
            Usuario user = new Usuario();
            user.Login = txtLogin.Text.Trim();
            user.Senha = mskSenha.Text.Trim();

            if (String.IsNullOrEmpty(user.Login) || String.IsNullOrEmpty(user.Senha)) //se um ou outro for nulo, dá erro
            {

                System.Windows.Forms.MessageBox.Show("Os campos login e senha não podem estar em branco!", "APAGAR USUÁRIO REGISTRADO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

                

            }

            else //se for atendido as condições, apagamos
            {
                if (System.Windows.Forms.MessageBox.Show(user.Login + ", tem certeza que deseja apagar o seu registro de usuário?", "APAGAR USUÁRIO REGISTRADO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    Conectar apagar = new Conectar();

                    apagar.apagaUser(user);

                    txtLogin.Text = string.Empty;
                    mskConfirma.Text = string.Empty;
                    mskSenha.Text = string.Empty;

                    txtEndereco.Text = string.Empty;
                    txtRG.Text = string.Empty;
                    txtCNH.Text = string.Empty;
                    txtFone.Text = string.Empty;
                    txtCPF.Text = string.Empty;
                }
            }
        }

       

       
        




    }
       
}
