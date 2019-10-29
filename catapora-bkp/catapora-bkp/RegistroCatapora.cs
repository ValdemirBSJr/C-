using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;
using System.Data.OleDb;

namespace catapora_bkp
{
    class RegistroCatapora
    {

        private DateTime dataCadastro, dataTratamento;
        private String nodesTratados, caminhoPrint, caminhoEmail;



        public DateTime DataTratamento
        {
            get { return dataTratamento; }
            set { dataTratamento = value; }
        }

        public DateTime DataCadastro
        {
            get { return dataCadastro; }
            set { dataCadastro = value; }
        }
        

        public String CaminhoEmail
        {
            get { return caminhoEmail; }
            set { caminhoEmail = value; }
        }

        public String CaminhoPrint
        {
            get { return caminhoPrint; }
            set { caminhoPrint = value; }
        }

        public String NodesTratados
        {
            get { return nodesTratados; }
            set { nodesTratados = value; }
        }




    }
}
