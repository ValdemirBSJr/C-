using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ConsoleApplication1
{
    class dal
    {
        private MySqlConnection conexao;

        public void cadastro(modelo mo)
        {
            string caminho = "SERVER=localhost;DATABASE=bdalugabuggy;UID=root;PASSWORD=;";
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string inserir = "INSERT INTO cliente (senhaCliente, NomeCliente, FoneCliente, CNHCliente, RGCliente, CPFCLiente, EnderecoCliente) VALUES('" + mo.Senha + "','" + mo.Nome + "','" + mo.Telefone + "','" + mo.Cnh + "','" + mo.Rg + "','" + mo.Cpf + "','" + mo.Endereco + "')";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex) //Aqui capturo o erro e o espeifico em mensagem
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }


        }

    }
}
