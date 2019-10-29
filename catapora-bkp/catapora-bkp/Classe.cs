using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Common;
using System.Data.OleDb;

namespace catapora_bkp
{
    class Classe
    {


        //aqui pega o usuario logado
        private String usuarioLogado;

        public String UsuarioLogado
        {
            get { return pegaUsuario(usuarioLogado); }
            set { usuarioLogado = pegaUsuario(value); }
        }

        public string pegaUsuario(string retornoUsuario)
        {//Funcao pra pegar o usuario logado
            retornoUsuario = Environment.UserName;
            return retornoUsuario;
        }


        public ToolTip retornaInfo(ToolTip retorna) //método para retornar info no tooltip
        {
            retorna.AutoPopDelay = 60000; //tempo que fica exibido se o mouse está parado
            retorna.InitialDelay = 1; //O tempo que conta para ele aparecer após o mouse parar
            retorna.ReshowDelay = 500; //O tempo que ela precisa para aparecer de novo quando o mouse para
            // Força o texto ToolTip text a ser exibido se o formulario for ativo ou não
            retorna.ShowAlways = true;
            

            return retorna;
        }

       


        

    }
}
