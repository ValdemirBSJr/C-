using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Common;
using System.Data.OleDb;
using System.Configuration; //precisa desa classe adicionado tbm em referencia
using System.Data;



namespace CATAPORA_BKP
{
     class Conexao
    {
        string consultaSQL, caminhoBD; //aqui setamos os parametros das conexões



       
        
        
   

//############# AQUI VAI OS MÉTODOS PARA CONSULTAS SQL CATAPORA####################################################

        public void cadastraCatapora(RegistroCatapora catapora)
        {
            //caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb";
            
            caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb";

            consultaSQL = "INSERT INTO catapora (dataCadCatapora, dataTratCatapora, caminhoPrintCatapora, caminhoEmailCatapora, nodeSaturadoCatapora, ticketCatapora, tratadorCatapora) VALUES (@dataCad, @dataTrat, @print, @email, @nodes, @tickets, @tratador)";

            // aqui indico qual o caminho e instancio o objeto que recebera os comandos
            OleDbConnection conexaoBD = new OleDbConnection(caminhoBD);
            OleDbCommand comando = new OleDbCommand();

            try
            {
                conexaoBD.Open(); //abro a conexao

                if (conexaoBD.State == System.Data.ConnectionState.Open)
                {
                    consultaSQL = "INSERT INTO catapora (dataCadCatapora, dataTratCatapora, caminhoPrintCatapora, caminhoEmailCatapora, nodeSaturadoCatapora, ticketCatapora, tratadorCatapora) VALUES (@dataCad, @dataTrat, @print, @email, @nodes, @tickets, @tratador)";


                    comando.Connection = conexaoBD;
                    comando.CommandText = consultaSQL;

                    comando.Parameters.AddWithValue("@dataCad", catapora.DataCadastro);
                    comando.Parameters.AddWithValue("@dataTrat", catapora.DataTratamento);
                    comando.Parameters.AddWithValue("@print", catapora.CaminhoPrint);
                    comando.Parameters.AddWithValue("@email", catapora.CaminhoEmail);
                    comando.Parameters.AddWithValue("@nodes", catapora.NodesTratados);
                    comando.Parameters.AddWithValue("@tickets", catapora.TicketAberto);
                    comando.Parameters.AddWithValue("@tratador", catapora.Tratador);

                    
                    comando.ExecuteNonQuery(); //executa a escrita no banco
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o registro! Favor verificar se você possue as credenciais de acesso a pasta de rede ou contate o administrador e informe o seguinte código de erro: " + ex.Message, "ERRO AO SALVAR/REGISTRAR CATAPORA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { //fecho a conexao
                conexaoBD.Close();
                MessageBox.Show("Registro do catapora salvo com sucesso!", "SUCESSO AO SALVAR REGISTRO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
                   

               

        }

        public void apagaCatapora(RegistroCatapora catapora)
        {
            caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb";
            consultaSQL = "INSERT INTO catapora (dataCadCatapora, dataTratCatapora, caminhoPrintCatapora, caminhoEmailCatapora, nodeSaturadoCatapora, ticketCatapora, tratadorCatapora) VALUES (@dataCad, @dataTrat, @print, @email, @nodes, @tickets, @tratador)";

            // aqui indico qual o caminho e instancio o objeto que recebera os comandos
            OleDbConnection conexaoBD = new OleDbConnection(caminhoBD);
            OleDbCommand comando = new OleDbCommand();


            try
            {
                conexaoBD.Open();

                    if (conexaoBD.State == System.Data.ConnectionState.Open)
                    {

                        if (MessageBox.Show("Tem certeza que deseja cancelar o registro: " + catapora.IdCatapora+ "?", "APAGAR REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                        consultaSQL = "DELETE FROM catapora WHERE idCatapora = @ID";

                        comando.Connection = conexaoBD;
                        comando.CommandText = consultaSQL;

                        comando.Parameters.AddWithValue("@ID", catapora.IdCatapora);

                        comando.ExecuteNonQuery();

                        }

                      
                    }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao apagar o registro de ID: " + catapora.IdCatapora + ". Favor contate o programador e informe o descritivo do erro: " + ex.Message, "ERRO AO APAGAR O REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Registro do catapora apagado com sucesso! Id apagado: " + catapora.IdCatapora, "SUCESSO AO APAGAR O REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexaoBD.Close(); //fecha a conexao
            }

        }


        public static OleDbDataAdapter consultaCatapora(RegistroCatapora catapora, int radioOpcaoConsulta)
        {
            // os valores do radiobuton serão: 1=pordata, 2=por ticket, 3=por node, 4=tudo
            
            
           string caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb";
            OleDbConnection conexaoBD = new OleDbConnection(caminhoBD);
            OleDbCommand comando = new OleDbCommand();
            string consultaSQL;
            OleDbDataAdapter da = new OleDbDataAdapter(); //adaptador dos dados

            conexaoBD.Open();

            if (conexaoBD.State == System.Data.ConnectionState.Open)
            {

                try
                {

                    

                    if (radioOpcaoConsulta == 1) // consulta entre datas
                    {
                        consultaSQL = "SELECT * FROM catapora WHERE dataCadCatapora BETWEEN #" + catapora.DataInicial.Date.ToString("yyyy/MM/dd") + "# AND #" + catapora.DataFinal.Date.ToString("yyyy/MM/dd") + "#"; //para se trebalhar com as datas, necessario convertelas para o formato de data americano, mesmo que o ACCESS exiba as datas no nosso formato.
                        comando.Connection = conexaoBD;
                        comando.CommandText = consultaSQL;
              
                    }

                    if (radioOpcaoConsulta == 2)
                    {
                        consultaSQL = "SELECT * FROM catapora WHERE ticketCatapora LIKE '%" +catapora.TicketConsulta +"%'"; // % permite busca aproximada lista tudo que tiver os mesmos cacateres em ordem
                        comando.Connection = conexaoBD;
                        comando.CommandText = consultaSQL;
                        
                    }

                    if (radioOpcaoConsulta == 3)
                    {
                        consultaSQL = "SELECT * FROM catapora WHERE nodeSaturadoCatapora LIKE '%"+catapora.NodeConsulta+"%'";
                        comando.Connection = conexaoBD;
                        comando.CommandText = consultaSQL;
                        
                    }

                    if (radioOpcaoConsulta == 4)
                    {
                        consultaSQL = "SELECT * FROM catapora";
                        comando.Connection = conexaoBD;
                        comando.CommandText = consultaSQL;
                        
                    }

                    
                    RegistroCatapora retornaData = new RegistroCatapora(); //aqui instancio um novo objeto para ser usado e preencher a datagrid view catapora
                    retornaData.ConsultaSQLobj = comando.CommandText;
                    retornaData.CaminhoBDobj = caminhoBD;

                   
                    da = new OleDbDataAdapter(retornaData.ConsultaSQLobj, retornaData.CaminhoBDobj);


                   // MessageBox.Show(retornaData.NodeConsulta + retornaData.TicketConsulta);

                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível realizar a consulta com os critérios desejados. Favor informar ao programador o descritivo: " + ex.Message, "ERRO AO REALIZAR CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexaoBD.Close();
                    
                }
            }

            return da;
        
        }


        public  void atualizaCatapora(RegistroCatapora catapora)
        { //aqui atualizamos os registros cadastrados

            caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb";
            // consultaSQL = "UPDATE catapora SET dataCadCatapora = @dataCad, dataTratCatapora = @dataTrat, caminhoPrintCatapora = @print, caminhoEmailCatapora =  @email, nodeSaturadoCatapora = @nodes, ticketCatapora = @tickets, tratadorCatapora = @tratador WHERE idCatapora = @ID";

            // aqui indico qual o caminho e instancio o objeto que recebera os comandos
            OleDbConnection conexaoBD = new OleDbConnection(caminhoBD);
            OleDbCommand comando = new OleDbCommand();

            try
            {
                conexaoBD.Open(); //abro a conexao

                if (conexaoBD.State == System.Data.ConnectionState.Open)
                {
                    consultaSQL = "UPDATE catapora SET dataCadCatapora = @dataCad, dataTratCatapora = @dataTrat, caminhoPrintCatapora = @print, caminhoEmailCatapora =  @email, nodeSaturadoCatapora = @nodes, ticketCatapora = @tickets, tratadorCatapora = @tratador WHERE idCatapora = @ID";


                    comando.Connection = conexaoBD;
                    comando.CommandText = consultaSQL;

                    comando.Parameters.AddWithValue("@dataCad", catapora.DataCadastro);
                    comando.Parameters.AddWithValue("@dataTrat", catapora.DataTratamento);
                    comando.Parameters.AddWithValue("@print", catapora.CaminhoPrint);
                    comando.Parameters.AddWithValue("@email", catapora.CaminhoEmail);
                    comando.Parameters.AddWithValue("@nodes", catapora.NodesTratados);
                    comando.Parameters.AddWithValue("@tickets", catapora.TicketAberto);
                    comando.Parameters.AddWithValue("@tratador", catapora.Tratador);
                    comando.Parameters.AddWithValue("@ID", catapora.IdCatapora);

                    comando.ExecuteNonQuery(); //executa a escrita no banco
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível atualizar o registro! Favor verificar se você possue as credenciais de acesso a pasta de rede ou contate o administrador e informe o seguinte código de erro: " + ex.Message, "ERRO AO ATUALIZAR/REGISTRAR CATAPORA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { //fecho a conexao
                conexaoBD.Close();
                MessageBox.Show("Registro do catapora atualizado com sucesso!", "SUCESSO AO ATUALIZAR REGISTRO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

         //#############################3 FIM DO CATAPORA ####################

         //########################################### BKP #############

        public void cadastraBKP(RegistroBKP bkp)
        {
            caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb";
            consultaSQL = "INSERT INTO backup (caminhoBkp, dataCadBkp, equipamentosBkp, aderenteBkp, usuarioBkp, indicesBkp, senhaBkp) VALUES (@caminho, @dataTrat, @equip, @aderente, @user, @indices, @senha)";

            // aqui indico qual o caminho e instancio o objeto que recebera os comandos
            OleDbConnection conexaoBD = new OleDbConnection(caminhoBD);
            OleDbCommand comando = new OleDbCommand();

            try
            {
                conexaoBD.Open(); //abro a conexao

                if (conexaoBD.State == System.Data.ConnectionState.Open)
                {
                    consultaSQL = "INSERT INTO backup (caminhoBkp, dataCadBkp, equipamentosBkp, aderenteBkp, usuarioBkp, indicesBkp, senhaBkp) VALUES (@caminho, @dataTrat, @equip, @aderente, @user, @indices, @senha)";


                    comando.Connection = conexaoBD;
                    comando.CommandText = consultaSQL;

                    comando.Parameters.AddWithValue("@caminho", bkp.CaminhoBKP);
                    comando.Parameters.AddWithValue("@dataTrat", bkp.DataCadBKP);
                    comando.Parameters.AddWithValue("@equip", bkp.EquipamentosBKP);
                    comando.Parameters.AddWithValue("@aderente", bkp.AderenteBKP);
                    comando.Parameters.AddWithValue("@user", bkp.UsuarioBKP);
                    comando.Parameters.AddWithValue("@indices", bkp.IndicesBKP);
                    comando.Parameters.AddWithValue("@senha", bkp.SenhaBKP);


                    comando.ExecuteNonQuery(); //executa a escrita no banco
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o registro! Favor verificar se você possue as credenciais de acesso a pasta de rede ou contate o administrador e informe o seguinte código de erro: " + ex.Message, "ERRO AO SALVAR/REGISTRAR BKP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { //fecho a conexao
                conexaoBD.Close();
                MessageBox.Show("Registro de Backup salvo com sucesso!", "SUCESSO AO SALVAR REGISTRO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }


        }


        public void atualizaBKP(RegistroBKP bkp)
        { //aqui atualizamos os registros cadastrados

            caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb";
            // consultaSQL = "UPDATE catapora SET dataCadCatapora = @dataCad, dataTratCatapora = @dataTrat, caminhoPrintCatapora = @print, caminhoEmailCatapora =  @email, nodeSaturadoCatapora = @nodes, ticketCatapora = @tickets, tratadorCatapora = @tratador WHERE idCatapora = @ID";

            // aqui indico qual o caminho e instancio o objeto que recebera os comandos
            OleDbConnection conexaoBD = new OleDbConnection(caminhoBD);
            OleDbCommand comando = new OleDbCommand();

            try
            {
                conexaoBD.Open(); //abro a conexao

                if (conexaoBD.State == System.Data.ConnectionState.Open)
                {
                    consultaSQL = "UPDATE backup SET caminhoBkp = @caminho, dataCadBkp = @dataTrat, equipamentosBkp = @equips, aderenteBkp = @adere, usuarioBkp = @USER, indicesBkp = @indices, senhaBkp = @senha WHERE idbkp = @ID";


                    comando.Connection = conexaoBD;
                    comando.CommandText = consultaSQL;

                    comando.Parameters.AddWithValue("@caminho", bkp.CaminhoBKP);
                    comando.Parameters.AddWithValue("@dataTrat", bkp.DataCadBKP);
                    comando.Parameters.AddWithValue("@equips", bkp.EquipamentosBKP);
                    comando.Parameters.AddWithValue("@adere", bkp.AderenteBKP);
                    comando.Parameters.AddWithValue("@USER", bkp.UsuarioBKP);
                    comando.Parameters.AddWithValue("@ID", bkp.IdBKP);
                    comando.Parameters.AddWithValue("@indices", bkp.IndicesBKP);
                    comando.Parameters.AddWithValue("@senha", bkp.SenhaBKP);

                    comando.ExecuteNonQuery(); //executa a escrita no banco
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível atualizar o registro! Favor verificar se você possue as credenciais de acesso a pasta de rede ou contate o administrador e informe o seguinte código de erro: " + ex.Message, "ERRO AO ATUALIZAR/REGISTRAR BACKUP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { //fecho a conexao
                conexaoBD.Close();
                MessageBox.Show("Registro de backup atualizado com sucesso!", "SUCESSO AO ATUALIZAR REGISTRO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }


        public void apagaBKP(RegistroBKP bkp)
        {
            caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb";
            //consultaSQL = "INSERT INTO catapora (dataCadCatapora, dataTratCatapora, caminhoPrintCatapora, caminhoEmailCatapora, nodeSaturadoCatapora, ticketCatapora, tratadorCatapora) VALUES (@dataCad, @dataTrat, @print, @email, @nodes, @tickets, @tratador)";

            // aqui indico qual o caminho e instancio o objeto que recebera os comandos
            OleDbConnection conexaoBD = new OleDbConnection(caminhoBD);
            OleDbCommand comando = new OleDbCommand();


            try
            {
                conexaoBD.Open();

                if (conexaoBD.State == System.Data.ConnectionState.Open)
                {

                    if (MessageBox.Show("Tem certeza que deseja cancelar o backup: " + bkp.IdBKP + "?", "APAGAR BACKUP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        consultaSQL = "DELETE FROM backup WHERE idbkp = @ID";

                        comando.Connection = conexaoBD;
                        comando.CommandText = consultaSQL;

                        comando.Parameters.AddWithValue("@ID", bkp.IdBKP);

                        comando.ExecuteNonQuery();

                    }


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao apagar o registro de ID: " + bkp.IdBKP + ". Favor contate o programador e informe o descritivo do erro: " + ex.Message, "ERRO AO APAGAR O REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Registro de backup apagado com sucesso! Id apagado: " + bkp.IdBKP, "SUCESSO AO APAGAR O REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexaoBD.Close(); //fecha a conexao
            }

        }



        public static OleDbDataAdapter consultaBKP(RegistroCatapora registro, int checkOpcaoConsulta)
        {
            /*tava com preguiça e usei is atributos do objeto RegistroCatapora. Não inlfuencia em nada
             por que esses atributos só uso pra consulta, mas seria bom criar eles tbm no RegistroBKP pra
             ficar mais didatico
            */
            // os valores do checkbox serão: 0=tudo, 1=por data


            string caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb";
            OleDbConnection conexaoBD = new OleDbConnection(caminhoBD);
            OleDbCommand comando = new OleDbCommand();
            string consultaSQL;
            OleDbDataAdapter da = new OleDbDataAdapter(); //adaptador dos dados

            conexaoBD.Open();

            if (conexaoBD.State == System.Data.ConnectionState.Open)
            {

                try
                {



                    if (checkOpcaoConsulta == 1) // consulta entre datas
                    {
                        consultaSQL = "SELECT * FROM backup WHERE dataCadBkp BETWEEN #" + registro.DataInicial.Date.ToString("yyyy/MM/dd") + "# AND #" + registro.DataFinal.Date.ToString("yyyy/MM/dd") + "#"; //para se trabalhar com as datas, necessario convertelas para o formato de data americano, mesmo que o ACCESS exiba as datas no nosso formato.
                        comando.Connection = conexaoBD;
                        comando.CommandText = consultaSQL;

                    }


                    if (checkOpcaoConsulta == 0)
                    {
                        consultaSQL = "SELECT * FROM backup";
                        comando.Connection = conexaoBD;
                        comando.CommandText = consultaSQL;

                    }


                    RegistroCatapora retornaData = new RegistroCatapora(); //aqui instancio um novo objeto para ser usado e preencher a datagrid view catapora
                    retornaData.ConsultaSQLobj = comando.CommandText;
                    retornaData.CaminhoBDobj = caminhoBD;


                    da = new OleDbDataAdapter(retornaData.ConsultaSQLobj, retornaData.CaminhoBDobj);


                    // MessageBox.Show(retornaData.NodeConsulta + retornaData.TicketConsulta);




                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível realizar a consulta com os critérios desejados. Favor informar ao programador o descritivo: " + ex.Message, "ERRO AO REALIZAR CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexaoBD.Close();

                }
            }

            return da;

        }

         //############################## MÉTODOS DO MOS ###############################################

        public void cadastraMOS(RegistroMos mos)
        {

            caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb";
            consultaSQL = "INSERT INTO mos (datacoleta, datatratamento, qtdeligacoes, caminhosolicitacao, caminhodevolutiva, contratos, ofensor) VALUES (@caminho, @dataTrat, @equip, @aderente, @user, @indices, @senha)";

            // aqui indico qual o caminho e instancio o objeto que recebera os comandos
            OleDbConnection conexaoBD = new OleDbConnection(caminhoBD);
            OleDbCommand comando = new OleDbCommand();

            try
            {
                conexaoBD.Open(); //abro a conexao

                if (conexaoBD.State == System.Data.ConnectionState.Open)
                {
                    consultaSQL = "INSERT INTO mos (datacoleta, datatratamento, qtdeligacoes, caminhosolicitacao, caminhodevolutiva, contratos, ofensor, tratador) VALUES (@cadastro, @dataTrat, @qtde, @solic, @devol, @contratos, @ofen, @trat)";


                    comando.Connection = conexaoBD;
                    comando.CommandText = consultaSQL;

                    comando.Parameters.AddWithValue("@cadastro", mos.DataCadastro);
                    comando.Parameters.AddWithValue("@dataTrat", mos.DataTratamento);
                    comando.Parameters.AddWithValue("@qtde", mos.QtdeLigacoes);
                    comando.Parameters.AddWithValue("@solic", mos.CaminhoSolicitacao);
                    comando.Parameters.AddWithValue("@devol", mos.CaminhoDevolutiva);
                    comando.Parameters.AddWithValue("@contratos", mos.Contratos);
                    comando.Parameters.AddWithValue("@ofen", mos.Ofensor);
                    comando.Parameters.AddWithValue("@trat", mos.Tratador);


                    comando.ExecuteNonQuery(); //executa a escrita no banco
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o registro! Favor verificar se você possue as credenciais de acesso a pasta de rede ou contate o administrador e informe o seguinte código de erro: " + ex.Message, "ERRO AO SALVAR/REGISTRAR MOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { //fecho a conexao
                conexaoBD.Close();
                MessageBox.Show("Registro do MOS salvo com sucesso!", "SUCESSO AO SALVAR REGISTRO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        public static OleDbDataAdapter consultaMOS (RegistroMos mos, int checkOpcaoConsulta)
        {

            //0 = data, 1 = contrato, 2 = tudo

          string caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb";
            OleDbConnection conexaoBD = new OleDbConnection(caminhoBD);
            OleDbCommand comando = new OleDbCommand();
            string consultaSQL;
            OleDbDataAdapter da = new OleDbDataAdapter(); //adaptador dos dados

            conexaoBD.Open();

            if (conexaoBD.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    if (checkOpcaoConsulta == 0) // consulta entre datas
                    {
                        consultaSQL = "SELECT * FROM mos WHERE datacoleta BETWEEN #" + mos.DataInicial.Date.ToString("yyyy/MM/dd") + "# AND #" + mos.DataFinal.Date.ToString("yyyy/MM/dd") + "#"; //para se trabalhar com as datas, necessario convertelas para o formato de data americano, mesmo que o ACCESS exiba as datas no nosso formato.
                        comando.Connection = conexaoBD;
                        comando.CommandText = consultaSQL;

                    }

                    if (checkOpcaoConsulta == 1)
                    {
                        consultaSQL = "SELECT * FROM mos WHERE contratos LIKE '%" + mos.ContratoConsulta + "%'"; // % permite busca aproximada lista tudo que tiver os mesmos cacateres em ordem
                        comando.Connection = conexaoBD;
                        comando.CommandText = consultaSQL;
                    }


                    if (checkOpcaoConsulta == 2)
                    {
                        consultaSQL = "SELECT * FROM mos";
                        comando.Connection = conexaoBD;
                        comando.CommandText = consultaSQL;

                    }

                    RegistroMos regimos = new RegistroMos();

                    regimos.ConsultaSQLobj = comando.CommandText;
                    regimos.CaminhoBDobj = caminhoBD;


                    da = new OleDbDataAdapter(regimos.ConsultaSQLobj, regimos.CaminhoBDobj);


                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro no método de consulta! Favor entre em contato com o desenvolvendor e informa o seguinte descritivo: " + ex.Message, "ERRO AO CONSULTAR O MOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexaoBD.Close();
                }
            }

            //Aqui o retorno do oledataadapter
            return da;
        }



        public void apagaMOS(RegistroMos mos)
        {
            caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb";
            //consultaSQL = "INSERT INTO catapora (dataCadCatapora, dataTratCatapora, caminhoPrintCatapora, caminhoEmailCatapora, nodeSaturadoCatapora, ticketCatapora, tratadorCatapora) VALUES (@dataCad, @dataTrat, @print, @email, @nodes, @tickets, @tratador)";

            // aqui indico qual o caminho e instancio o objeto que recebera os comandos
            OleDbConnection conexaoBD = new OleDbConnection(caminhoBD);
            OleDbCommand comando = new OleDbCommand();


            try
            {
                conexaoBD.Open();

                if (conexaoBD.State == System.Data.ConnectionState.Open)
                {

                    if (MessageBox.Show("Tem certeza que deseja cancelar o MOS: " + mos.IdMos + "?", "APAGAR MOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        consultaSQL = "DELETE FROM mos WHERE mosid = @ID";

                        comando.Connection = conexaoBD;
                        comando.CommandText = consultaSQL;

                        comando.Parameters.AddWithValue("@ID", mos.IdMos);

                        comando.ExecuteNonQuery();

                    }


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao apagar o registro de ID: " + mos.IdMos + ". Favor contate o programador e informe o descritivo do erro: " + ex.Message, "ERRO AO APAGAR O REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Registro de MOS apagado com sucesso! Id apagado: " + mos.IdMos, "SUCESSO AO APAGAR O REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexaoBD.Close(); //fecha a conexao
            }
        }

        public void atualizaMOS(RegistroMos mos)
        {
            //aqui atualizamos os registros cadastrados

            caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb";
            // consultaSQL = "UPDATE catapora SET dataCadCatapora = @dataCad, dataTratCatapora = @dataTrat, caminhoPrintCatapora = @print, caminhoEmailCatapora =  @email, nodeSaturadoCatapora = @nodes, ticketCatapora = @tickets, tratadorCatapora = @tratador WHERE idCatapora = @ID";

            // aqui indico qual o caminho e instancio o objeto que recebera os comandos
            OleDbConnection conexaoBD = new OleDbConnection(caminhoBD);
            OleDbCommand comando = new OleDbCommand();

            try
            {
                conexaoBD.Open(); //abro a conexao

                if (conexaoBD.State == System.Data.ConnectionState.Open)
                {
                    consultaSQL = "UPDATE mos SET datacoleta = @dataCad, datatratamento = @dataTrat, qtdeligacoes = @qtde, caminhosolicitacao = @solic, caminhodevolutiva = @devol, contratos = @contratos, ofensor = @ofensor, tratador = @tratador WHERE mosid = @ID";


                    comando.Connection = conexaoBD;
                    comando.CommandText = consultaSQL;

                    comando.Parameters.AddWithValue("@dataCad", mos.DataCadastro);
                    comando.Parameters.AddWithValue("@dataTrat", mos.DataTratamento);
                    comando.Parameters.AddWithValue("@qtde", mos.QtdeLigacoes);
                    comando.Parameters.AddWithValue("@solic", mos.CaminhoSolicitacao);
                    comando.Parameters.AddWithValue("@devol", mos.CaminhoDevolutiva);
                    comando.Parameters.AddWithValue("@contratos", mos.Contratos);
                    comando.Parameters.AddWithValue("@ofensor", mos.Ofensor);
                    comando.Parameters.AddWithValue("@tratador", mos.Tratador);
                    comando.Parameters.AddWithValue("@ID", mos.IdMos);

                    comando.ExecuteNonQuery(); //executa a escrita no banco
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível atualizar o registro! Favor verificar se você possue as credenciais de acesso a pasta de rede ou contate o administrador e informe o seguinte código de erro: " + ex.Message, "ERRO AO ATUALIZAR/REGISTRAR MOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { //fecho a conexao
                conexaoBD.Close();
                MessageBox.Show("Registro do MOS atualizado com sucesso!", "SUCESSO AO ATUALIZAR REGISTRO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        //############## VERIFICA USUÁRIO #############################################

        public Boolean retornaUser ()
        {
            Boolean retorno;

            

                Classe usuCad = new Classe();


                OleDbConnection conexaoBD = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PastaAPP.resgataPastaPadrao() + @"\arquivosControle\BD_DADOS.mdb");

                OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT * FROM users WHERE user LIKE'" + usuCad.UsuarioLogado + "'", conexaoBD);

                DataSet ds = new DataSet();

                //preenche o dataset com os dados da tabela tblchip
                adaptador.Fill(ds, "retornoConsulta");

                //abaixo verifico se existe algum registro, se existir retorno na aba de visualização, senao envio a mensagem informando



                if (ds.Tables["retornoConsulta"].Rows.Count <= 0)
                {
                    MessageBox.Show("Você não é um usuário credenciado para utilizar o sistema! Contate o Datacenter JPA. Usuário logado: " + usuCad.UsuarioLogado, "REGISTRO NÃO ENCONTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    retorno = false;
                }
                else
                {

                    //  MessageBox.Show("Você é um usuário credenciado!", "REGISTRO  ENCONTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    retorno = true;
                }

            
           

                return retorno;

            
               

        }




    }
}
