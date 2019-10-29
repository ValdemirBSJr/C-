using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace heranca_e_polimorfismo_unopar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pessoa pessoaTeste = new Pessoa(); //instancio o objeto pessoa
            Professor professorTeste = new Professor(); //instancio o objeto do professor

            professorTeste.Id = 10;
            professorTeste.Titulo = "Doutor";//Note que não tem nada na classe professor ele está herdando da classe pessoa. O que tem a mais aparece só aqui e nao na pessoa
            professorTeste.Nome = "valdemir";
            professorTeste.Estado = "PB";
            professorTeste.Bairro = "José Américo";
            professorTeste.Cidade = "João Pessoa";
            professorTeste.Cpf = "39239203102";
            professorTeste.Endereco = "Rua otávio";
            professorTeste.Formacao = "PsicoProgramador";

            professorTeste.Salvar(); //chama o método
            
        }
    }
}
