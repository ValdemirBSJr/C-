using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace exibe
{
    public partial class confi : Form
    {


        public confi()
        {//Comeco
            InitializeComponent();

            //Declaro as variaveis globais que setam a conexao e o comando MySql:


        }
        MySqlConnection conexao;
        MySqlCommand comando;
        int LenLocal;

       

        //String de conexao:
        string caminho = "SERVER=localhost; DATABASE=imagens; UID=root; PASSWORD=;";
        //Não sei se forçando o DATABASE="C:\mysql\data\mysql" -- 'CAMINHO'
        //Posso usar a string do SQL SERVER @'C:\CAMINHODOARQUIVO?

        private void confi_Load(object sender, EventArgs e)
        {
            try //tento a conexao
            {
                
                conexao = new MySqlConnection(caminho);
                conexao.Open(); //abro a conexao com o bd
                comando = conexao.CreateCommand();//habilita o terminal para comandos MySQL
                if (conexao.State == ConnectionState.Open)//verifico aqui se o bd está aberto
                {
                    btnAddImagem.Enabled = true;
                    btnListar.Enabled = true;
                    txtDescricao.Text = "";
                }
                else
                {
                    btnAddImagem.Enabled = false;
                    btnListar.Enabled = false;
                    txtDescricao.Text = "Não conectado as imagens";
                }
            }

            catch (Exception ex)//Trato o erro caso nao conecte
            {
                MessageBox.Show("Não foi possível conectar ao banco! Favor entrar em contato com o administrador. Código do erro: " + ex.Message, "ERRO AO CONECTAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //finally
            //{
            //  conexao.Close();//Finalmente, fecho a conexao
            //}

        }

        private void btnAddImagem_Click(object sender, EventArgs e)
        {

            try
            {//comeco do try -catch

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imgImagem.Load(openFileDialog1.FileName);
                    imgImagem.SizeMode = PictureBoxSizeMode.StretchImage;//Aqui mudamos o tamanho da imagem para a picturebox
                    comando.Parameters.Clear();
                    

                    //Os eventos abaixo tratam quando o mouse passa por cima da imagem, deixa ela e quando vc clica ela
                    imgImagem.MouseMove += new MouseEventHandler(move);
                    imgImagem.MouseLeave += new EventHandler(leave);
                    imgImagem.Click += new EventHandler(clique);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível efetuar a operação! Contate o desenvolvedor. Mensagem de erro: " + ex.Message, "ERRO AO CADASTRAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//Fim do try -catch

            finally
            {
               // conexao.Close(); //finalmente fecho a conexão ;;;;
                txtDescricao.Text = "";
                txtRelevancia.Text = "";
                txtResposta.Text = "";

            }

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                comando.Parameters.Clear();
                comando.CommandText = "SELECT * FROM armazenaimagens";
                //conexao.Open();  //Conexao ja esta aberta
                DataTable tabeladedados = new DataTable();
                MySqlDataAdapter dadosmontados = new MySqlDataAdapter(comando);
                dadosmontados.Fill(tabeladedados);
                dataGridView1.DataSource = tabeladedados;

                

               

            }

            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível montar a grade. Favor contate o desenvolvedor! Mensagem de erro: " + ex.Message, "ERRO NA TABELA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //conexao.Close();
            }
        }


        private void confi_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            conexao.Close(); //Aqui fecho a conexao
        }

        //private void trataImagens()
       // {
            //Os eventos abaixo tratam quando o mouse passa por cima da imagem, deixa ela e quando vc clica ela
           // imgImagem.MouseMove += new MouseEventHandler(move);
           // imgImagem.MouseLeave += new EventHandler(leave);
           // imgImagem.Click += new EventHandler(clique);

       // }

        //Abaixo tratamos os EVENTOS ACIMA
        private void move(object sender, EventArgs e)
        {
            PictureBox imgImagem = (PictureBox)sender;

            Graphics grafico = imgImagem.CreateGraphics();

            string nome = imgImagem.ImageLocation.Remove(0, LenLocal + 1);

            imgImagem.Width = 200;
            imgImagem.Height = 200;
            

        }

        private void leave(object sender, EventArgs e)
        {
            PictureBox imgImagem = (PictureBox)sender;
            imgImagem.Width = 193;
            imgImagem.Height = 194;
            imgImagem.Refresh();


        }

        private void clique(object sender, EventArgs e)
        {
            PictureBox imgImagem = (PictureBox)sender;
            string nome = imgImagem.ImageLocation.Remove(0, LenLocal + 1);

            Form formulario = new Form();
            formulario.Width = imgImagem.Width +15;
            formulario.Height = imgImagem.Height + 30;
            formulario.BackgroundImage = imgImagem.Image;
            formulario.BackgroundImageLayout = ImageLayout.Stretch;
            formulario.FormBorderStyle = FormBorderStyle.SizableToolWindow;

            formulario.Text = nome;
            formulario.ShowDialog();


        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                try
                {
                    if (MessageBox.Show("Tem certeza que deseja apagar a imagem de nossos registros?", "APAGAR REGISTRO/IMAGEM", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        int linha; //aqui iremos pegar os indices da tabela datagrid e apagar o registro
                        int coluna;
                        int convertido;

                        string refRegistro; //abaixo colhemos o indice de linha e coluna ou seja o campo "ID"
                        coluna = dataGridView1.CurrentCell.ColumnIndex;
                        linha = dataGridView1.CurrentRow.Index;

                        refRegistro = dataGridView1.Rows[linha].Cells[coluna].Value.ToString(); //Aqui converto para texto

                        convertido = Convert.ToInt32(refRegistro);

                        comando.CommandText = "DELETE FROM armazenaimagens WHERE Id= '" + convertido + "'";
                        comando.ExecuteNonQuery();

                        dataGridView1.Rows.RemoveAt(item.Index);//Apaga o valor no datagrid
                    }
                    else
                    {
                        return; //Para o procedimento da imagem
                    }

                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível apagar a imagem do nosso registro. Favor contate o desenvolvedor! Mensagem de erro: " + ex.Message, "ERRO AO APAGAR REGISTRO/IMAGEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName != " " && txtDescricao.Text != "")
            {

                //Abaixo crio o comando de inserção em SQL para salvar os caminhos e descrições(testar o outro modo que conheço com o MySqlCommand?)
                comando.CommandText = "INSERT INTO armazenaimagens (caminho, Nome, Resposta_certa, Relevancia) VALUES (@CAMINHO_IMG, @NOME_IMG, @RESPOSTA_IMG, @RELEVANCIA_IMG)";
                //Abaixo seto os valores de @CAMINHO E @NOME como vindo das caixas de texto:
                comando.Parameters.AddWithValue("NOME_IMG", txtDescricao.Text); //Nesse método é mais fácil e seguro (^_^)
                comando.Parameters.AddWithValue("CAMINHO_IMG", openFileDialog1.FileName);
                comando.Parameters.AddWithValue("RESPOSTA_IMG", txtResposta.Text);
                comando.Parameters.AddWithValue("RELEVANCIA_IMG", txtRelevancia.Text);
                //btnAddImagem.Text = "Add Imagem";
                //Após montar os comandos, manda executar:
                comando.ExecuteNonQuery();
                MessageBox.Show("Imagem cadastrada com sucesso!", "CADASTRO DE IMAGENS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else
            {
                MessageBox.Show("Erro ao cadastrar imagem! Selecione uma imagem válida", "CADASTRO DE IMAGENS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                try
                {
                    if (MessageBox.Show("Tem certeza que deseja editar a imagem selecionada?", "EDITAR REGISTRO/IMAGEM", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        int linha; //aqui iremos pegar os indices da tabela datagrid e apagar o registro
                        int coluna;
                        int convertido;

                        string refRegistro; //abaixo colhemos o indice de linha e coluna ou seja o campo "ID"
                        coluna = dataGridView1.CurrentCell.ColumnIndex;
                        linha = dataGridView1.CurrentRow.Index;

                        refRegistro = dataGridView1.Rows[linha].Cells[coluna].Value.ToString(); //Aqui converto para texto

                        convertido = Convert.ToInt32(refRegistro);

                       // comando.CommandText = "DELETE FROM armazenaimagens WHERE Id= '" + convertido + "'";
                        comando.CommandText = "UPDATE armazenaimagens SET  Nome = @NOM, Resposta_certa = @RESPOS, Relevancia = @RELES WHERE Id= '" + convertido + "'";
                        //comando.CommandText = "INSERT armazenaimagens (Nome, Resposta_certa, Relevancia) VALUES (@NOM, @RESPOS, @RELES) ON DUPLICATE KEY UPDATE Id = '" +convertido+"'";

                       
                          if (!string.IsNullOrWhiteSpace(txtDescricao.Text))

                             {
                                 comando.Parameters.AddWithValue("NOM", txtDescricao.Text);
                             }
                             else
                             {
                                 comando.Parameters.AddWithValue("NOM", DBNull.Value);
                             }

                        if(!string.IsNullOrWhiteSpace(txtResposta.Text))
                        {
                            comando.Parameters.AddWithValue("RESPOS", txtResposta.Text);
                        }
                        else
                        {
                            comando.Parameters.AddWithValue("RESPOS", DBNull.Value);
                        }

                        if(!string.IsNullOrWhiteSpace(txtRelevancia.Text))
                        {
                            comando.Parameters.AddWithValue("RELES", txtRelevancia.Text);
                        }

                        else
                        {
                            comando.Parameters.AddWithValue("RELES", DBNull.Value);
                        } 
                            

                        comando.ExecuteNonQuery();

                        
                    }
                    else
                    {
                        return; //Para o procedimento da imagem
                    }
                    
                    MessageBox.Show("Alteração efetuada!","EDIÇÃO DE IMAGEM");

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível alterar a imagem do nosso registro. Favor contate o desenvolvedor! Mensagem de erro: " + ex.Message, "ERRO AO ALTERAR REGISTRO/IMAGEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAnalitico_Click(object sender, EventArgs e)
        {
            analitico AbreAnalitico = new analitico();
            AbreAnalitico.Show();
        }

       

        




        }//Fim
    }

