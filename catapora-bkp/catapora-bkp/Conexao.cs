using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Common;
using System.Data.OleDb;

namespace catapora_bkp
{
    class Conexao
    {
        private string consultaSQL, caminhoBD; //aqui setamos os parametros das conexões
        private OleDbCommand comando;
        private OleDbConnection conexaoBD;
        
   

//############# AQUI VAI OS MÉTODOS PARA CONSULTAS SQL ####################################################

        public void cadastraCatapora(RegistroCatapora catapora)
        {
            caminhoBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + @"\BD_DADOS.mdb";

            try
            {
                conexaoBD = new OleDbConnection(caminhoBD); //conecto ao banco
                conexaoBD.Open(); //abro o banco

                if (conexaoBD.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Conexao aberta");
                }

                else
                {
                    MessageBox.Show("Não abriu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o registro. Favor contate o desenvolvedor e informe o erro a seguir! Mensagem de erro: " + ex.Message, "ERRO AO salvar registro CATAPORA", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                conexaoBD.Close();
            }


        }

    }
}
