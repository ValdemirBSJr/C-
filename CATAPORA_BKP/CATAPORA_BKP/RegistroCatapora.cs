using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;
using System.Data.OleDb;
using System.Configuration; //precisa desa classe adicionado tbm em referencia



namespace CATAPORA_BKP
{
    class RegistroCatapora
    {
        private int idCatapora;
        private DateTime dataCadastro, dataTratamento, dataInicial, dataFinal;
        private String nodesTratados, caminhoPrint, caminhoEmail, ticketAberto, tratador, nodeConsulta, ticketConsulta, consultaSQLobj, caminhoBDobj;
       

        public string CaminhoBDobj
        {
            get { return caminhoBDobj; }
            set { caminhoBDobj = value; }
        }

        public string ConsultaSQLobj
        {
            get { return consultaSQLobj; }
            set { consultaSQLobj = value; }
        }

        public String TicketConsulta
        {
            get { return ticketConsulta; }
            set { ticketConsulta = value; }
        }

        public String NodeConsulta
        {
            get { return nodeConsulta; }
            set { nodeConsulta = value; }
        }

        public int IdCatapora
        {
            get { return idCatapora; }
            set { idCatapora = value; }
        }

        public String Tratador
        {
            get { return tratador; }
            set { tratador = value; }
        }

        public String TicketAberto
        {
            get { return ticketAberto; }
            set { ticketAberto = value; }
        }


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

        public DateTime DataFinal
        {
            get { return dataFinal; }
            set { dataFinal = value; }
        }

        public DateTime DataInicial
        {
            get { return dataInicial; }
            set { dataInicial = value; }
        }


    }
}
