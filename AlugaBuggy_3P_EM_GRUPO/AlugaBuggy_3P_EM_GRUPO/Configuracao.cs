using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration; //classe para poder manipular o App.Config

namespace Login_PREPARA_PORTIFOLIO_3P
{
    class Configuracao
    {

        public static void salvaUltimoLog(string chave, string Log)
        {

            // Abre o App.Config

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);



            // Adiciona o que voce quer nele

            config.AppSettings.Settings.Remove(chave);

            config.AppSettings.Settings.Add(chave, Log);

           // config.AppSettings.Settings[chave].Value = Log;


            // Salva o arquivo  de configuração.

            config.Save(ConfigurationSaveMode.Modified);



            // Atualiza a configuração.

            ConfigurationManager.RefreshSection("appSettings");



        }




    }
}
