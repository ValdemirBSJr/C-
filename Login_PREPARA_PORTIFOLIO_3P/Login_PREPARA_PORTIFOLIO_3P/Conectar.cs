using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Login_PREPARA_PORTIFOLIO_3P
{
    class Conectar
    {
        private MySqlConnection conexao; //aqui setamos a conexao
        private MySqlCommand comando;
        private MySqlDataReader lercomando;
        private MySqlDataReader lerexclusao;
       private string loginGuardado, senhaGuardada;
       private MySqlTransaction transacao;
       public string mensage;

       //####################LOGAR####################


        public void fazerLogin(Usuario Log) //aqui o metodo (funcao que loga) usuario log recebe por parametro o valor 
        {
            

            string caminho = "SERVER=localhost;DATABASE=loginesenha;UID=root;PASSWORD=;";

            try
            {
                //exibo o form de carregando

                carregando formulario = new carregando();
                

                //abaixo encriptamos a senha:
                string encriptado = Crypto.Criptografar(Log.Senha);
                

                conexao = new MySqlConnection(caminho); //diz qual o caminho
                conexao.Open(); //abre a conexao

                if (conexao.State == System.Data.ConnectionState.Open) //testa se a conexao esta aberta
                {
                    comando = conexao.CreateCommand(); //habilita o terminal para comandos mysql

                    comando.CommandText = "SELECT * FROM guardalogin WHERE login = @LOGIN AND senha = @SENHA"; //comando para leitura
                    comando.Parameters.AddWithValue("LOGIN", Log.Login); //Log.Login é o valor pego da txt e passado por parametro que no caso é user
                    comando.Parameters.AddWithValue("SENHA", encriptado);

                    lercomando = comando.ExecuteReader();

                    while (lercomando.Read())
                    {
                        

                        loginGuardado = lercomando["login"].ToString();
                        senhaGuardada = lercomando["senha"].ToString();

                        if (lercomando.FieldCount >= 1) //se encontrar um registro, salva no App.config
                        {
                            Configuracao.salvaUltimoLog("UltimoLog", loginGuardado);

                            formulario.Show(); //aqui se achar algum valor, carrega o form
                        }
                       
                    }

                    lercomando.Close();
                    conexao.Close();


                }

                //abaixo fazemos a verificação

                if ((loginGuardado == Log.Login) && (senhaGuardada == encriptado))
                {
                    //System.Windows.Forms.MessageBox.Show("Você está logado!", "LOGADO", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                     mensage = "Login efetuado com sucesso!";
                    Status.Mensagem = mensage; //aqui chamo a função ée seto a string para ela

                    

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Login ou senha Invalido!", "NÃO LOGADO", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }


            }

            catch (Exception ex) //caso nao consiga logar ou localizar.
            {
                System.Windows.Forms.MessageBox.Show("Não foi possível se logar. Favor contate o desenvolvedor! Mensagem de erro: " + ex.Message, "ERRO AO LOGAR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


        //####################CADASTRAR####################

        public void cadastraUsuario(Usuario cad) //metodo para cadastrar usuario
        {
            string caminho = "SERVER=localhost;DATABASE=loginesenha;UID=root;PASSWORD=;";

            try
            {
                //abaixo encriptamos a senha:
                string encriptado = Crypto.Criptografar(cad.Senha);

                conexao = new MySqlConnection(caminho);

                conexao.Open();

                if (conexao.State == System.Data.ConnectionState.Open)
                {


                    if ((!String.IsNullOrEmpty(cad.Senha)) && (!String.IsNullOrEmpty(cad.ConfSenha)) && (!String.IsNullOrEmpty(cad.Login))) //se os 3 campos não forem nulos ou vazios e se a senha e confsenha forem iguais
                    {
                        if (cad.Senha == cad.ConfSenha && cad.Login != string.Empty)
                        {
                            

                            string inserir = "INSERT INTO guardalogin (login, senha, senhasc) VALUES (@LOGIN, @SENHA, @SENHASC)";

                            MySqlCommand insercaoSQL = new MySqlCommand(inserir, conexao);

                            insercaoSQL.Parameters.AddWithValue("LOGIN", cad.Login);
                            insercaoSQL.Parameters.AddWithValue("SENHA", encriptado);
                            insercaoSQL.Parameters.AddWithValue("SENHASC", cad.ConfSenha);



                            insercaoSQL.ExecuteNonQuery(); //executa os comandos
                            conexao.Close();

                            System.Windows.Forms.MessageBox.Show("Usuário " + Convert.ToString(cad.Login) + " cadastrado com sucesso!", "SUCESSO!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                        }

                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Usuário " + Convert.ToString(cad.Login) + " não cadastrado! Verifique se a senha digitada é válida e idêntica e se os campos foram preenchidos corretamente.", "ERRO AO CADASTRAR!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                        }
                    }

                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Um ou mais campos estão em branco!", "ERRO AO CADASTRAR!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                    }

                }

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Usuário " + Convert.ToString(cad.Login) + " não foi cadastrado! Favor tentar novamente. Erro: " + ex.Message, "NÃO FOI POSSÍVEL CADASTRAR!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);

            }
            

        }

        //##################APAGAR###########################

        public void apagaUser(Usuario cad) //metodo para excluir user
        {
            string caminho = "SERVER=localhost;DATABASE=loginesenha;UID=root;PASSWORD=;";

            try
            {
                //abaixo encriptamos a senha:
                string encriptado = Crypto.Criptografar(cad.Senha);

                conexao =  new MySqlConnection(caminho);

                conexao.Open();

                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    comando = conexao.CreateCommand(); //habilita o terminal para comandos mysql

                    //abaixo iniciamos a transação. Isso serve para que um comando não seja executado sem o outro para não dar erro. No caso tenho uma consulta e uma exclusao. se der pau em uma, a outra não é feita ou desfeita caso a segunda dê pau


                    transacao = conexao.BeginTransaction(System.Data.IsolationLevel.Serializable); //começa a transacao. Serializable força que exclusao só seja feita depois que a consulta for finalizada

                    comando.CommandText = "SELECT * FROM guardalogin WHERE login = @LOGIN AND senha = @SENHA"; //comando para leitura
                    comando.Parameters.AddWithValue("LOGIN", cad.Login); //Log.Login é o valor pego da txt e passado por parametro que no caso é user
                    comando.Parameters.AddWithValue("SENHA", encriptado);

                    lerexclusao = comando.ExecuteReader();

                    if (!lerexclusao.HasRows) //verifica se não retornou nada
                    {
                        System.Windows.Forms.MessageBox.Show("Não foi possível localizar nenhum registro com essas informações! Verifique se o login e a senha foram digitadas corretamente!", " ERRO AO APAGAR!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                    }

                    else
                    {

                            //loginGuardado = lercomando["login"].ToString();
                            //senhaGuardada = lercomando["senha"].ToString();



                            string inserir = "DELETE FROM guardalogin WHERE login = @LOGIN";

                            MySqlCommand exclusaoSQL = new MySqlCommand(inserir, conexao);

                            exclusaoSQL.Parameters.AddWithValue("LOGIN", cad.Login);


                            lerexclusao.Close(); //fecha o reader

                            exclusaoSQL.ExecuteNonQuery(); //executa os comandos

                            exclusaoSQL.Parameters.Clear(); //tem q limpar parametros senao nao fecha o reader, dá erro.


                            transacao.Commit(); //confirma e finaliza a transação
                            conexao.Close();


                            System.Windows.Forms.MessageBox.Show("Usuário " + Convert.ToString(cad.Login) + " , seu registro foi apagado com sucesso!", "REGISTRO APAGADO!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
     
                    

                        }
                    
                }
            }
            catch ( Exception ex)
            {
                transacao.Rollback(); //Reverte a transação (Rollback) se acontecer algum erro na transação

                System.Windows.Forms.MessageBox.Show("Não foi possível apagar o registro! Código do erro: " + ex.Message, "ERRO AO APAGAR!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            }

        }

    }
}
