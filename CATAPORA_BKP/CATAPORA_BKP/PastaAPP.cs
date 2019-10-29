using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration; //precisa desa classe adicionado tbm em referencia
using System.IO;
using System.Windows.Forms;
namespace CATAPORA_BKP
{
    class PastaAPP
    {
        //Pasta global do aplicativo
        private String chave, pasta;
        
        


        public String Chave
        {
            get { return chave; }
            set { chave = value; }
        }

        public String Pasta
        {
            get { return pasta; }
            set { pasta = value; }
        }



        public static void salvarPastaPadrao(PastaAPP pasta)
        {
            try
            { //Abre o app.Config

                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                //Remove o que tiver antes pra acrescentar de novo
                config.AppSettings.Settings.Remove(pasta.Chave);

                //adiciona a chave (tag xml) e o valor que é o caminho da pasta
                config.AppSettings.Settings.Add(pasta.Chave, pasta.Pasta);

                //salva o arquivo de configuração

                config.Save(ConfigurationSaveMode.Modified);

                //atualização a sessão

                ConfigurationManager.RefreshSection("appSettings");
                //appSettings é a tag do xml app.config
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar a pasta padrão no caminho especificado: " + pasta.pasta + ". Verifique se você possui permissão de escrita/leitura nessa pasta ou contate o programador e relate o erro: " + ex.Message, "ERRO AO SALVAR PASTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static string resgataPastaPadrao()
        {
            
            //Resgatamos o valor da chave
            string retorno;
            Configuration resgataConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); //abrimos o app.config

            return retorno = Convert.ToString(resgataConfig.AppSettings.Settings["pastaAPP"].Value);
        }

        public static void existeConstroiCaminho()
        {
            //Aqui ele pega o caminho que foi salvo no appConfig
            StringBuilder caminhoParcialPasta = new StringBuilder();
            caminhoParcialPasta.Append(resgataPastaPadrao());

            try
            {
                

                //se não existir a pasta padrão ele cria
                if (!Directory.Exists(caminhoParcialPasta.Append(@"\arquivosControle\").ToString()))
                {
                    Directory.CreateDirectory(caminhoParcialPasta.Append(@"\catapora\").ToString());

                    caminhoParcialPasta.Replace(@"\catapora\", @"\bkp\"); //aqui eu mudo, onde tem catapora, mudo para bkp

                    Directory.CreateDirectory(caminhoParcialPasta.ToString());

                    caminhoParcialPasta.Replace(@"\bkp\", @"\mos\"); //aqui eu mudo, onde tem catapora, mudo para bkp

                    Directory.CreateDirectory(caminhoParcialPasta.ToString());



                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Não foi possível acessar a pasta padrão no caminho especificado: " + caminhoParcialPasta + ". Verifique se você possui permissão de escrita/leitura nessa pasta ou contate o programador e relate o erro: " + ex.Message, "ERRO AO VERIFICAR PASTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //MessageBox.Show(caminhoParcialPasta.ToString());

            
        }


        //############### EQUIPAMENTOS ##############################################

        public static List<String> retornaEquipamentos()
        {//aqui iremos retornar os equipamentos que estão salvos como string e vamos salvar em lista
            
            Configuration resgataEquipamento = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); //abrimos o app.config
           
            string retornoApp = Convert.ToString(resgataEquipamento.AppSettings.Settings["equipamentos"].Value);
            List<String> Equipamentos = new List<String>(retornoApp.Split(new char[] { ';' }));

            return Equipamentos;
        }

        public static void salvaEquipamentos(List<String> Equipamentos)
        {
            String EquipamentosTruncados;
            //Abaixo eu junto tudo que recebo na lista em uma string e separo por ;
            EquipamentosTruncados = String.Join(";", Equipamentos);

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //Remove o que tiver antes pra acrescentar de novo
            config.AppSettings.Settings.Remove("equipamentos");

            //adiciona a chave (tag xml) e o valor que é a string concatenada
            config.AppSettings.Settings.Add("equipamentos", EquipamentosTruncados);

            //salva o arquivo de configuração

            config.Save(ConfigurationSaveMode.Modified);

            //atualização a sessão

            ConfigurationManager.RefreshSection("appSettings");
            //appSettings é a tag do xml app.config

           //  return EquipamentosTruncados = String.Join(";", Equipamentos);


             
        }

        public static void excluiEquipamentos(string EquipamentoRecebido)
        {
            //recebe o equipamento do listbox e o apaga do appConfig
            Configuration resgataEquipamento = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); //abrimos o app.config

            string retornoApp = Convert.ToString(resgataEquipamento.AppSettings.Settings["equipamentos"].Value);
            List<String> Equipamentos = new List<String>(retornoApp.Split(new char[] { ';' }));

            Equipamentos.Remove(EquipamentoRecebido);

            salvaEquipamentos(Equipamentos); //aqui chamo o metodo acima nesta classe para salvar a lista atualizada com o item repetido
        }

    }
}
