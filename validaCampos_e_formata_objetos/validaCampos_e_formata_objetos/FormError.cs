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
    public partial class FormError : Form
    {
        public FormError()
        {
            InitializeComponent();
        }

        //http://fernandodrt.blogspot.com.br/2013/04/validar-campos-no-windows-forms.html
        //http://www.devmedia.com.br/validacoes-uteis-para-textbox/4525


        //O que foi feito aqui é considerado mais elegante. usamos a classe nativa errorProvider para tratar os erros
        //nas imputações dos campos. Adicionei ao projeto o componente errorProvider que se localiza na guia "toolbox/components" e se 
        //basicamente conforme abaixo. Notem que fiz uma validação simples, mas dá pra fazer muito mais coisas
        private void btnvalidar_Click(object sender, EventArgs e)
        {
            //Se estiver vazio, retorna o errorProvider
            if (String.IsNullOrEmpty(txtNome.Text))
            {
                errorProvider1.SetError(txtNome, "Campo \"Nome\" não pode ser vazio!");
            }
                //Se nao estiver vazio, retira o error rovider
            else
            {
                errorProvider1.SetError(txtNome, "");
            }

            if (String.IsNullOrEmpty(txtIdade.Text))
            {
                errorProvider1.SetError(txtIdade, "Campo \"Idade\" Não pode ser vazio!");
            }
            else
            {
                errorProvider1.Clear();
            }

            //abaixo testo se nenhum dos dois estiver vazio, e dou o resultado
            if (!String.IsNullOrEmpty(txtIdade.Text) && !String.IsNullOrEmpty(txtNome.Text))
            {
                lblresultado.Text = "Nome: " + txtNome.Text.Trim() + ". Idade: " + txtIdade.Text.Trim();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRelatorio form = new FormRelatorio();
            form.Show();
        }
    }
}
