using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CATAPORA_BKP
{
    class RegistroBKP
    {
        private int idBKP;
        private DateTime dataCadBKP, dataFinal, dataInicial;

        public DateTime DataInicial
        {
            get { return dataInicial; }
            set { dataInicial = value; }
        }

        public DateTime DataFinal
        {
            get { return dataFinal; }
            set { dataFinal = value; }
        }
        private String caminhoBKP, equipamentosBKP, aderenteBKP, usuarioBKP, indicesBKP, senhaBKP;

        public String SenhaBKP
        {
            get { return senhaBKP; }
            set { senhaBKP = value; }
        }

        public String IndicesBKP
        {
            get { return indicesBKP; }
            set { indicesBKP = value; }
        }

        public String UsuarioBKP
        {
            get { return usuarioBKP; }
            set { usuarioBKP = value; }
        }

        public String AderenteBKP
        {
            get { return aderenteBKP; }
            set { aderenteBKP = value; }
        }

        public String EquipamentosBKP
        {
            get { return equipamentosBKP; }
            set { equipamentosBKP = value; }
        }

        public String CaminhoBKP
        {
            get { return caminhoBKP; }
            set { caminhoBKP = value; }
        }

        public DateTime DataCadBKP
        {
            get { return dataCadBKP; }
            set { dataCadBKP = value; }
        }

        public int IdBKP
        {
            get { return idBKP; }
            set { idBKP = value; }
        }

    }
}
