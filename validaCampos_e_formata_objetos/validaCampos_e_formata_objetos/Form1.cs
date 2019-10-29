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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChamaForm_Click(object sender, EventArgs e)
        {
            //Abaixo instancio o formulario criado que quero chamar. Lembrar que o C# trata estes componentes como obj. Isso é 
            // útil também quando tratamos os campos text do form atual
            FormObjeto formulario = new FormObjeto();

            //exibo o formulario
            formulario.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //Se o que for proposto é apenas que um dos campos sejam preenchidos, pode usar esta solução
            //Com foreach abaixo. Notem que é mais elegante, contudo, não é indicado quando se tem o mínimo de valores obrigatórios
            //Para ver a melhor forma, comentem o foreach e descomentem o bloco segundo bloco de validação 

            //foreach vai percorrer cada controle do formulario e retornar os que estiverem vazios ao array: controles_de_texto
            foreach (Control controles_de_texto in this.Controls)
            {
                //aqui testamos se o controle é do tipo textbox. Pode ser usado com qualquer tipo de controle
                if (controles_de_texto.GetType() == typeof(TextBox))
                {
                    //aqui, verifico se estão todos vazios. Se sim, retorna mensagem de erro,
                    // mas se um form preenchido, retorna true. Caso tenha campos obrigatórios, usar o outro tipo de validação
                    if (String.IsNullOrEmpty(controles_de_texto.Text))
                    {
                        lblResultado.Text = "Campos estão vazios, favor preencha os mesmos! Campos: " + controles_de_texto.Name;
                    }

                    else
                    {
                        lblResultado.Text = "Campos foram preenchidos! Nome: " + txtNome.Text.Trim() + ". Idade: " + txtIdade.Text.Trim();
                    }
                }
            }

            //##########################
            //####VALIDAÇÃO ESPECÍFICA##
            //##########################

            //Essa validação de campos pode ser usada quando temos que garantir que campos obrigatórios foram preenchidos:


            //abaixo verifico se ambos estão vazios, caso sim. retorna o erro ao user
            //if (String.IsNullOrEmpty(txtNome.Text) && String.IsNullOrEmpty(txtIdade.Text))
            //{
            //    lblResultado.Text = "Ambos os campos estão vazios!";
            //}
            //else
            //{
            //    //aqui, se ambos foram preenchidos, retorna sucesso ao user
            //    if (!String.IsNullOrEmpty(txtNome.Text) && !String.IsNullOrEmpty(txtIdade.Text))
            //    {
            //        lblResultado.Text = "Campos foram preenchidos! Nome: " + txtNome.Text.Trim() + ". Idade: " + txtIdade.Text.Trim();
            //    }

            //    //se um ou outro estiver vazio. retorna o campo vazio para o user (erro)
            //    if (String.IsNullOrEmpty(txtNome.Text) && !String.IsNullOrEmpty(txtIdade.Text))
            //    {
            //        lblResultado.Text = "O campo \"Nome\" está vazio, favor preencher!";
            //    }
            //    if (!String.IsNullOrEmpty(txtNome.Text) && String.IsNullOrEmpty(txtIdade.Text))
            //    {
            //        lblResultado.Text = "O campo \"Idade\" está vazio, favor preencher!";
            //    }
            //}

            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //instancio e chamo o outro formulario de validação
            FormError formulario2 = new FormError();
            formulario2.Show();
        }
    }
}
