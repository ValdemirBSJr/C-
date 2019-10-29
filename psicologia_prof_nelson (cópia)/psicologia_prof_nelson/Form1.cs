using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Timers;
using MySql.Data.MySqlClient;
using System.IO;
using System.Threading;
using Microsoft.Office.Interop.Excel;




namespace exibe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader reader;
        MySqlDataReader reader2;
        MySqlDataReader leUser;
        int LenLocal;
        String respCorreta;
        DateTime DataRealizacao;
        string registraNome;
        DateTime cronInicial = DateTime.Now;
        DateTime cronFinal;
        int colheudados = 5;
        List<int> ArrayImagemSorteada = new List<int>();
        string LerPrimeiroIdImagem;
        int PrimeiroId;
        int  UltimoId;
        int conta = 0;
        string IdUsuario;
        string Results;
        string RelevanciaImg;
        string NomePasta;
        string CaminhoPasta;
        int tamanhoOriginal;

        string ultRegistraNome;
        string ultRespCorreta;
        int ultColheuDados;
        string ultRelevanciaImg;
        
        

        string caminho = "SERVER=localhost; DATABASE=imagens; UID=root; PASSWORD=;";


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)//Funciona!
        { 
            //Esta funcionando, colhe informação digtada e a usa na inoutação de dados.
            
           

                if (keyData == Keys.F12) //Abre form do administrador (configuração)
                {
                    //PAra abrir/chamar um form, temos que trata-lo como objeto e instancia-lo:
                    confi abreform = new confi();
                    abreform.Show();

                }

                if (keyData == Keys.Escape)//fecha se apertar esc
                {
                    this.Close(); return true;
                }

                if (keyData == Keys.Enter)//inicia execução do teste
                {
                    IniciaMensagem.Start();
                     //Pegar os valores e registrar
                    DataRealizacao = DateTime.Now;
                    //string Date = DateTime.Now.ToShortDateString("dd/MM/yyyy");
                    comando.CommandText = "INSERT INTO infoparticipante (DataExecucao) VALUES (@DATAREA)";
                    comando.Parameters.AddWithValue("DATAREA", DataRealizacao);
                   
                    comando.ExecuteNonQuery();

               

                    comando.Parameters.Clear();

                    comando.CommandText = "SELECT * FROM infoparticipante ORDER BY IdParticipante DESC LIMIT 1";
                    leUser = comando.ExecuteReader();
                    leUser.Read();
                    IdUsuario = leUser["IdParticipante"].ToString();
                    leUser.Close();

                }


                if ((keyData == Keys.D1) || (keyData == Keys.NumPad1)) //se digitar um no teclado normal ou no numerico ele recolhe informação
                {
                    // lblAlegria1.Text = "O valor é 1";
                    //colheudados = lblAlegria1.Text; //testo a retirada dos dados:
                    colheudados = 1;


                    //MessageBox.Show("O valor da label agora é: " + colheudados);

                }

                if ((keyData == Keys.D2) || (keyData == Keys.NumPad2))
                {
                    colheudados = 2;


                }

                if ((keyData == Keys.D3) || (keyData == Keys.NumPad3))
                {
                    colheudados = 3;


                }

                if ((keyData == Keys.D4) || (keyData == Keys.NumPad4))
                {
                    colheudados = 4;


                }


               if (conta == tamanhoOriginal) //diminuo de um para não chegar no Array coringa
                {
                    fim AbreFormFinal = new fim();
                    AbreFormFinal.Show();
                    //try
                    //{
                    //    //###########CRIA AS PASTAS DE GUARDA#############

                    //    CaminhoPasta = "d:\\RespostasExpressoes\\" + Convert.ToDateTime(DataRealizacao).ToString("MMM-yyyy"); //Crio pasta com nome do mes e ano para salvar

                    //    if (!Directory.Exists(CaminhoPasta))
                    //    {
                    //        Directory.CreateDirectory(CaminhoPasta); //Testo, se a pasta não existe, cria ela
                    //    }
                    //    //###########FIM CRIA PASTA##################

                    //    //##################EXCEL#######################################################
                    //    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//crio uma instancia do Excel


                    //    Workbook wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet); //Crio uma pasta do excel
                    //    Worksheet ws = (Worksheet)wb.Worksheets.get_Item(1); //Crio uma planilha

                    //    NomePasta = Convert.ToString(IdUsuario) + "(Usuário)_" + Convert.ToDateTime(DataRealizacao).ToString("dd-MMM-yyyy"); //

                    //    ws.Name = "VOLUNTÁRIO Nº" + Convert.ToString(IdUsuario); //nome da planilha

                    //    ws.Cells[1, 10] = "USUÁRIO:"; //Aqui e abaixo seto em celulas específicas o nome do usuário e a data de execução
                    //    ws.Cells[2, 10] = "DATA DE EXECUÇÃO:";
                    //    ws.Cells[1, 11] = IdUsuario;
                    //    ws.Cells[2, 11] = DataRealizacao;


                    //    comando.Parameters.Clear(); //faço uma consulta que preencherá o Datatable com os dados para jogar na planilha
                    //    comando.CommandText = "SELECT * FROM armazenarespostas WHERE IdVoluntario= '" + IdUsuario + "'";
                    //    System.Data.DataTable tabelaRespUsuarios = new System.Data.DataTable();
                    //    MySqlDataAdapter dadosmontados = new MySqlDataAdapter(comando);
                    //    dadosmontados.Fill(tabelaRespUsuarios);

                    //    int rowCount = 1; //Completo a planilha com os dados
                    //    foreach (DataRow dr in tabelaRespUsuarios.Rows)
                    //    {
                    //        rowCount += 1;
                    //        for (int i = 1; i < tabelaRespUsuarios.Columns.Count + 1; i++)
                    //        {
                    //            //Adiciona o cabeçalho na primeira vez
                    //            if (rowCount == 4)
                    //            {
                    //                ws.Cells[1, i] = tabelaRespUsuarios.Columns[i - 1].ColumnName.ToString();
                    //            }
                    //            ws.Cells[rowCount, i] = dr[i - 1];

                    //        }
                    //    }


                    //    //Salvo a planilha
                    //    wb.SaveAs(CaminhoPasta + "\\" + NomePasta + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    //    //encerro a Instancia do excel
                    //    excel.Quit();

                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show("Não foi possível exportar as respostas para o Excel! Favor entrar em contato com o administrador. Código do erro: " + ex.Message, "ERRO AO EXPORTAR PARA O EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}

                    //finally
                    //{//Aqui abrimos o form de encerramento
                    //    //fim AbreFormFinal = new fim();
                    //    //AbreFormFinal.Show();
                    //    //this.Close();
                        
                    //}

                    //#############FIM DO RELATÓRIO###################
                }
            
            //############INICIA FOTOS##########################
                mostramarcador.Start();

                

                    //comando.CommandText = "SELECT * FROM armazenaimagens WHERE Id > 1 ORDER BY RAND() LIMIT 0,1";
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT * FROM armazenaimagens WHERE Id = '" + ArrayImagemSorteada[conta] + "'";

                    /*DataTable tabeladedados = new DataTable();
                      MySqlDataAdapter dadosmontados = new MySqlDataAdapter(comando);
                      dadosmontados.Fill(tabeladedados);*/
                    reader = comando.ExecuteReader();
                


                //Carrega a imagem
                ImgVisualiza.SizeMode = PictureBoxSizeMode.StretchImage;

               // reader.Read();

                if (reader.Read())
                {

                    ImgVisualiza.Load(reader["caminho"].ToString());

                    registraNome = reader["Nome"].ToString();

                    respCorreta = reader["Resposta_certa"].ToString();

                    RelevanciaImg = reader["Relevancia"].ToString();
                }
                
                
                reader.Close();

                if (colheudados != 0)
                {
               
                    //mostramarcador.Start();
                    
                    

                    ////comando.CommandText = "SELECT * FROM armazenaimagens WHERE Id > 1 ORDER BY RAND() LIMIT 0,1";
                    //comando.Parameters.Clear();
                    //comando.CommandText = "SELECT * FROM armazenaimagens WHERE Id = '" + ArrayImagemSorteada[conta] + "'";

                    ///*DataTable tabeladedados = new DataTable();
                    //  MySqlDataAdapter dadosmontados = new MySqlDataAdapter(comando);
                    //  dadosmontados.Fill(tabeladedados);*/
                    //reader = comando.ExecuteReader();

                   


                    ////Carrega a imagem
                    //ImgVisualiza.SizeMode = PictureBoxSizeMode.StretchImage;


                    //reader.Read();

                    //// resultadoImagemNome[x] = reader["Nome"].ToString();




                    ////isso aqui tem que ir pra depois do save
                    //ImgVisualiza.Load(reader["caminho"].ToString());


                    //registraNome = reader["Nome"].ToString();

                    //respCorreta = reader["Resposta_certa"].ToString();

                    //RelevanciaImg = reader["Relevancia"].ToString();


                   



                    ////Tem que fechar reader antes de salvar registros
                    //reader.Close();

                    if (colheudados < 5)
                    {

                        if (ultRespCorreta == Convert.ToString(colheudados))
                        {
                            Results = "CORRETO";
                        }

                        else
                        {
                            Results = "ERRADO";
                        }



                        cronFinal = DateTime.Now;
                        TimeSpan diferencaTempo = cronFinal.Subtract(cronInicial);




                        string days = diferencaTempo.TotalSeconds.ToString("00:00:00");

                        // lbltempo.Text = Convert.ToString(diferenca);

                        comando.Parameters.Clear();
                        comando.CommandText = "INSERT INTO armazenarespostas (nome, IdVoluntario, tempoResposta, respostaCerta, repostaDada, resultado, relevancia) VALUES (@NOME_IMG_REG, @IDUSS, @TEMPO_RES1, @RESP_CERTA1, @RESP_DADA1, @RESUL, @RELEV)";
                        comando.Parameters.AddWithValue("NOME_IMG_REG", ultRegistraNome);
                        comando.Parameters.AddWithValue("IDUSS", IdUsuario);
                        comando.Parameters.AddWithValue("TEMPO_RES1", days);
                        comando.Parameters.AddWithValue("RESP_CERTA1", ultRespCorreta);
                        comando.Parameters.AddWithValue("RESP_DADA1", colheudados);
                        comando.Parameters.AddWithValue("RESUL", Results);
                        comando.Parameters.AddWithValue("RELEV", ultRelevanciaImg);


                        comando.ExecuteNonQuery();
                        //TEM QUE VIR PRA QUI

                        lblMarcador.Visible = true;
                        cronInicial = DateTime.Now;

                       

                       

                    }

                        conta = conta + 1; //conta fora para marcar as imagens
                        ultRegistraNome = registraNome; //registra na ultima o valor da anterior para registrar corretamente no bd
                        ultRespCorreta = respCorreta;
                        ultRelevanciaImg = RelevanciaImg;
                  

                    if (conta == ArrayImagemSorteada.Count) //Se chegar no valor total do array, salva na planilha do excel e avança lá em cima para abrir o form final
                    {
                        

                        
                        try
                        {
                            //###########CRIA AS PASTAS DE GUARDA#############

                            CaminhoPasta = "d:\\RespostasExpressoes\\" + Convert.ToDateTime(DataRealizacao).ToString("MMM-yyyy"); //Crio pasta com nome do mes e ano para salvar

                            if (!Directory.Exists(CaminhoPasta))
                            {
                                Directory.CreateDirectory(CaminhoPasta); //Testo, se a pasta não existe, cria ela
                            }
                            //###########FIM CRIA PASTA##################

                            //##################EXCEL#######################################################
                            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//crio uma instancia do Excel


                            Workbook wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet); //Crio uma pasta do excel
                            Worksheet ws = (Worksheet)wb.Worksheets.get_Item(1); //Crio uma planilha

                            NomePasta = Convert.ToString(IdUsuario) + "(Usuário)_" + Convert.ToDateTime(DataRealizacao).ToString("dd-MMM-yyyy"); //

                            ws.Name = "VOLUNTÁRIO Nº" + Convert.ToString(IdUsuario); //nome da planilha

                            ws.Cells[1, 10] = "USUÁRIO:"; //Aqui e abaixo seto em celulas específicas o nome do usuário e a data de execução
                            ws.Cells[2, 10] = "DATA DE EXECUÇÃO:";
                            ws.Cells[1, 11] = IdUsuario;
                            ws.Cells[2, 11] = DataRealizacao;


                            comando.Parameters.Clear(); //faço uma consulta que preencherá o Datatable com os dados para jogar na planilha
                            comando.CommandText = "SELECT * FROM armazenarespostas WHERE IdVoluntario= '" + IdUsuario + "'";
                            System.Data.DataTable tabelaRespUsuarios = new System.Data.DataTable();
                            MySqlDataAdapter dadosmontados = new MySqlDataAdapter(comando);
                            dadosmontados.Fill(tabelaRespUsuarios);

                            int rowCount = 1; //Completo a planilha com os dados
                            foreach (DataRow dr in tabelaRespUsuarios.Rows)
                            {
                                rowCount += 1;
                                for (int i = 1; i < tabelaRespUsuarios.Columns.Count + 1; i++)
                                {
                                    //Adiciona o cabeçalho na primeira vez
                                    if (rowCount == 4)
                                    {
                                        ws.Cells[1, i] = tabelaRespUsuarios.Columns[i - 1].ColumnName.ToString();
                                    }
                                    ws.Cells[rowCount, i] = dr[i - 1];

                                }
                            }
                            

                            //Salvo a planilha
                            wb.SaveAs(CaminhoPasta +"\\" + NomePasta+ ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            
                            //encerro a Instancia do excel
                            excel.Quit();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Não foi possível exportar as respostas para o Excel! Favor entrar em contato com o administrador. Código do erro: " + ex.Message, "ERRO AO EXPORTAR PARA O EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        finally
                        {//Aqui abrimos o form de encerramento
                          //  fim AbreFormFinal = new fim();
                          //  AbreFormFinal.Show();
                        }

                        //#############FIM DO RELATÓRIO###################
                    }


                }


            
            

            return base.ProcessCmdKey(ref msg, keyData); 
        }//fim do capta botoes



        //Aqui crio um timer para disparar as mensagens de boas vindas:

        private void IniciaMensagem_Tick(object sender, EventArgs e)
        {
            lblMensagemInicial.Visible = false;
            
            marcador.Start();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
            try //tento a conexao
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open(); //abro a conexao com o bd
                comando = conexao.CreateCommand();//habilita o terminal para comandos MySQL
                if (conexao.State == ConnectionState.Open)//verifico aqui se o bd está aberto
                {

                    DataRealizacao = DateTime.Now;

                    //Pega no banco o primeira e ultima linha:


                    comando.CommandText = "SELECT * FROM armazenaimagens ORDER BY Id ASC LIMIT 1"; //Lê primeira linha
                    reader2 = comando.ExecuteReader();
                    reader2.Read();

                    LerPrimeiroIdImagem = reader2["Id"].ToString();
                    PrimeiroId = Convert.ToInt16(LerPrimeiroIdImagem);
                    reader2.Close();

                   
                    comando.CommandText = "SELECT COUNT(Id) FROM armazenaimagens"; //conta quantos registros tem na tabela e retornar um valor
                   

                    
                    UltimoId = int.Parse(comando.ExecuteScalar().ToString());//Não precisa de datareader para comandoExecuteEscalar
                   


                    
                   


                    //*******SORTEIA AS IMAGENS E SALVA EM ARRAY SEM REPETIR: Código adaptado do forum da Microsoft

                    List<int> imagens = new List<int>();
                   // List<int> ArrayImagemSorteada = new List<int>();
                    

                    int[] pegaValores = new int[UltimoId];

                    //Populo as imagens na lista defino 64 posições
                   
                    
                    for (int i = PrimeiroId; i <= UltimoId; i++)
                    {
                        imagens.Add(i);
                    }
                    //imagens.Add(3333);
                    //armazeno o tamanho original da lista de imagens
                    tamanhoOriginal = imagens.Count();

                    Random random = new Random();
                    int randomico;

                    //faço uma iteração pelo tamanho original da lista
                    for (int i = 0; i < tamanhoOriginal; i++)
                    {
                        //Gero um número randomico de 0 até o número máximo de ítens que ainda existe na lista
                        randomico = random.Next(0, imagens.Count);
                        //Adiciono a imagem na outra lista
                        ArrayImagemSorteada.Add(imagens[randomico]);

                        //Removo o ítem ja adicionado na outra lista da lista original
                        imagens.RemoveAt(randomico);
                    }

                   /* foreach (int povoaList in t)
                    {
                        lstVetor.Items.Add(povoaList);
                    }*/

                    ArrayImagemSorteada.ToArray(); //converto a lista em array

                    for (int x = 0; x < tamanhoOriginal; x++)
                    {
                        pegaValores[x] = ArrayImagemSorteada[x];
                    }
                    ArrayImagemSorteada.Add(33333);//atribui um valor ao último array pra não dar erro no banco, lá em cima não deixo chegar nele

                     foreach (int povoaListRandom in ArrayImagemSorteada)
                    {
                        lstresultados.Items.Add(povoaListRandom);
                    }

                    //percorro toda a nova lista

                   /* foreach (int povoaListConvertidoListaArray in pegaValores)
                    {
                        lstArrayConvertidoDeLista.Items.Add(povoaListConvertidoListaArray);
                    }*/

                    //txtResultado.Text = Convert.ToString(lstMostraRandom.Items.Count);
                     lbltempo.Text = Convert.ToString(PrimeiroId);
                     lblFinal.Text = Convert.ToString(UltimoId);
                     lblArrayCount.Text = Convert.ToString(ArrayImagemSorteada.Count);
                    //**************FIM DO SORTEIO


                }

                
            }

            catch (Exception ex)//Trato o erro caso nao conecte
            {
                MessageBox.Show("Não foi possível conectar ao banco de dados de imagens! Favor entrar em contato com o administrador. Código do erro: " + ex.Message, "ERRO AO CONECTAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }



        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            conexao.Close(); //Aqui fecho a conexao

           
        }

        private void marcador_Tick(object sender, EventArgs e)
        {
            
            ImgVisualiza.Visible = true;
            lblAlegria1.Visible = true;
            lblRaiva2.Visible = true;
            lblMedo3.Visible = true;
            lblTristeza4.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMarcador.Visible = false;
            
            
        }

       

        

        

        
        

       

       

        


       

    }//FIM
}
