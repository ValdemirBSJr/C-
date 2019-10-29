using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace validaCampos_e_formata_objetos
{
    public partial class FormObjeto : Form
    {
        public FormObjeto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //instancio o objeto e o crio e abaixo passo para eles os valores já formatados na classe Usuario
            Usuario dadosUsuario = new Usuario();

            dadosUsuario.Nome = txtNome.Text.Trim();
            dadosUsuario.Cpf = txtCPF.Text.Trim();

            lblResultado.Text = "Nome formatado: " + dadosUsuario.Nome + ". CPF formatado: " + dadosUsuario.Cpf + ".";
        }

        //Abaixo validação de campo para apenas aceitar valores numericos(não se consegue digitar texto, mas o objeto é tratado como texto. Não há problemas para o c# fazer isso:

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        
    }
}
