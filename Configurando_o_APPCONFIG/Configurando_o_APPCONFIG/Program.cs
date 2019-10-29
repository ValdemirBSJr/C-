using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration; //precisa desa classe adicionado tbm em referencia

//Sempre verifique o arquivo de configuração do executável da aplicação. As alterações não são refletidas no arquivo de configuração do código fonte.

namespace Configurando_o_APPCONFIG
{
    class Program
    {
        static void Main(string[] args)
        {

            bool enviarEmail =
    Convert.ToBoolean(ConfigurationManager.AppSettings["EnviarEmailDeErro"]);

            if (enviarEmail)
            {
                Console.WriteLine("Enviar email - valor resgatado 'true'");
            }

            else
            {
                Console.WriteLine("Enviar email - valor resgatado 'false'");
            }

            

            enviarEmail =
                Convert.ToBoolean(ConfigurationManager.AppSettings["EnviarEmailDeErro"]);

            Console.WriteLine("Enviar email = {0}", enviarEmail.ToString());

            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["EnviarEmailDeErro"].Value = "false";
            config.Save(ConfigurationSaveMode.Modified);

            Console.WriteLine("\nConfiguração EnviarEmailDeErro alterado para 'false'.\n");

            enviarEmail =
                Convert.ToBoolean(ConfigurationManager.AppSettings["EnviarEmailDeErro"]);

            Console.WriteLine("Enviar email = {0}\n", enviarEmail.ToString());

            ConfigurationManager.RefreshSection("appSettings");

            Console.WriteLine("Seção appSettings atualizada.\n");

            enviarEmail =
                Convert.ToBoolean(ConfigurationManager.AppSettings["EnviarEmailDeErro"]);

            Console.WriteLine("Enviar email = {0}\n", enviarEmail.ToString());

            config.AppSettings.Settings.Add("Quantidade", "12");

            config.Save(ConfigurationSaveMode.Modified);

            int quantidade =
                Convert.ToInt32(config.AppSettings.Settings["Quantidade"].Value);

            Console.WriteLine(quantidade);

            Console.Read();


        }
    }
}
