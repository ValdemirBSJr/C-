using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CATAPORA_BKP
{
    class RegistroMos
    {
        private int idMos;

        public int IdMos
        {
            get { return idMos; }
            set { idMos = value; }
        }
        private DateTime dataCadastro, dataTratamento, dataInicial, dataFinal;

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
        private String caminhoSolicitacao, caminhoDevolutiva, tratador, qtdeLigacoes, contratos, ofensor, contratoConsulta, consultaSQLobj, caminhoBDobj;

        public String CaminhoBDobj
        {
            get { return caminhoBDobj; }
            set { caminhoBDobj = value; }
        }

        public String ConsultaSQLobj
        {
            get { return consultaSQLobj; }
            set { consultaSQLobj = value; }
        }

        public String ContratoConsulta
        {
            get { return contratoConsulta; }
            set { contratoConsulta = value; }
        }

        public String Ofensor
        {
            get { return ofensor; }
            set { ofensor = value; }
        }

        public String Contratos
        {
            get { return contratos; }
            set { contratos = value; }
        }

        public String QtdeLigacoes
        {
            get { return qtdeLigacoes; }
            set { qtdeLigacoes = value; }
        }

        public String Tratador
        {
            get { return tratador; }
            set { tratador = value; }
        }

        public String CaminhoDevolutiva
        {
            get { return caminhoDevolutiva; }
            set { caminhoDevolutiva = value; }
        }

        public String CaminhoSolicitacao
        {
            get { return caminhoSolicitacao; }
            set { caminhoSolicitacao = value; }
        }


    }
}
