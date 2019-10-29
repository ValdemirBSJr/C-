using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TestaLoginEsenha
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
        string MeuLogin;
        string MinhaSenha;
        string LoginDigitado;
        string SenhaDigitada;

        string meucaminho = "SERVER=localhost; DATABASE=loginesenha; UID=Valdemir; PASSWORD=valdemir";

        private void Form1_Load(object sender, EventArgs e)
        {
            txtLogin.Enabled = false;
            mskSenha.Enabled = false;
            btnLogar.Enabled = false;
            txtLogin.Focus();
            try
            {
                minhaconexao = new MySqlConnection(meucaminho);
                minhaconexao.Open();
                meucomando = minhaconexao.CreateCommand();

                if (minhaconexao.State == ConnectionState.Open)
                {
                    txtLogin.Enabled = true;
                    mskSenha.Enabled = true;
                    btnLogar.Enabled = true;

                }

                else
                {
                    txtLogin.Text = "SEM NOÇÃO";
                    mskSenha.Text = "SEM CONEXÃO";
                    btnLogar.Text = "FORA";
                }
                minhaconexao.Close();

            }

            catch( Exception excecao)
            {
                MessageBox.Show("Não foi possível conectar ao banco de dados!Erro: "+excecao.Message+"Código: " +excecao.InnerException,"ERRO");
            }


        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            SenhaDigitada = mskSenha.Text;
            LoginDigitado = txtLogin.Text;
            minhaconexao.Open();
            meucomando.CommandText = "SELECT * FROM guardalogin WHERE login='" + txtLogin.Text + "'";
            

            lerconsulta = meucomando.ExecuteReader();

            while (lerconsulta.Read())
            {
                MeuLogin = lerconsulta["login"].ToString();
                MinhaSenha = lerconsulta["senha"].ToString();
            }

            lerconsulta.Close();
            minhaconexao.Close();

            if ((MeuLogin == LoginDigitado) && (MinhaSenha == SenhaDigitada))
            {
                MessageBox.Show("LOGIN EFETUADO COM SUCESSO! LOGIN: " + MeuLogin + ". Sua senha: " + MinhaSenha + ".", "STATUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLogin.Text = "";
                mskSenha.Text = "";
                txtLogin.Focus();
            }
            else
            {
                MessageBox.Show("NÃO FOI POSSÍVEL LOGAR! VERIFIQUE LOGIN E SENHA", "STATUS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }




    }
}
