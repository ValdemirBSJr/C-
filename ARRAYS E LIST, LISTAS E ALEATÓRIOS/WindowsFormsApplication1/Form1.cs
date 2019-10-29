using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {

            lstVetor.Items.Clear();
            Random geraNumeros = new Random();
            int [] recebeNumeros = new int [64];

            for (int i = 0; i < 63; i++)
            {
                lstVetor.Items.Add(geraNumeros.Next(32, 96));
                recebeNumeros[i] = Convert.ToInt32(geraNumeros.Next(32, 96).ToString());

                lstMostraRandom.Items.Add(recebeNumeros[i]);
            }


            txtResultado.Text = Convert.ToString(lstMostraRandom.Items.Count);
           



        }

        private void btnListaA_Click(object sender, EventArgs e)
        {
            lstVetor.Items.Clear();
            int[] recebeArray = new int[96];
            

            for (int i = 1; i < 96; i++)
            {
                recebeArray[i] = i;
                
            }

            

            foreach (int valor in recebeArray)
            {
                lstVetor.Items.Add(valor);
            }



        }

        private void btnListas_Click(object sender, EventArgs e)
        {
            lstVetor.Items.Clear();
            //Declaro as listas
            List<int> imagens = new List<int>();
            List<int> t = new List<int>();
            int tamanhoOriginal;

            int[] pegaValores = new int[4];

            //Populo as imagens na lista defino 64 posições
            for (int i = 0; i <=3; i++)
            {
                imagens.Add(i) ;
            }

            //armazeno o tamanho original da lista de imagens
            tamanhoOriginal = imagens.Count();

            Random random = new Random();
            int randomico;

            //faço uma iteração pelo tamanho original da lista
            for (int i = 0; i < tamanhoOriginal; i++)
            {
                //Gero um número randomico de 0 até o número máximo de ítens que ainda existe na lista
                randomico = random.Next(0, imagens.Count);
                //Adiciono a imagem na outra lista
                t.Add(imagens[randomico]);

                //Removo o ítem ja adicionado na outra lista da lista original
                imagens.RemoveAt(randomico);
            }

            foreach (int povoaList in t)
            {
                lstVetor.Items.Add(povoaList);
            }

            t.ToArray(); //converto a lista em array

            for (int x = 0; x <= 3; x++)
            {
                pegaValores[x] = t[x];
            }

            foreach (int povoaListRandom in t)
            {
                lstMostraRandom.Items.Add(povoaListRandom);
            }
           
            //percorro toda a nova lista

            foreach (int povoaListConvertidoListaArray in pegaValores)
            {
                lstArrayConvertidoDeLista.Items.Add(povoaListConvertidoListaArray);
            }

            txtResultado.Text = Convert.ToString(lstMostraRandom.Items.Count);
            

        }

        private void btnArrayss_Click(object sender, EventArgs e)
        {
            lstVetor.Items.Clear();
            //Declaro as listas
            int [] imagens = new int [64];
            int[] t = new int[64];
            int tamanhoOriginal;

            int[] pegaValores = new int[64];

            //Populo as imagens na lista defino 40 posições
            for (int i = 1; i < 96; i++)
            {
                imagens[i] = i;
            }

            //armazeno o tamanho original da lista de imagens
            tamanhoOriginal = imagens.Count();

            Random random = new Random();
            int randomico;

            //faço uma iteração pelo tamanho original da lista
            for (int i = 0; i < tamanhoOriginal; i++)
            {
                //Gero um número randomico de 0 até o número máximo de ítens que ainda existe na lista
                randomico = random.Next(0, tamanhoOriginal);
                //Adiciono a imagem na outra lista
                //t.Add(imagens[randomico]);

                t[i] = Convert.ToInt32(randomico);
                //Removo o ítem ja adicionado na outra lista da lista original
                
            }



            //percorro toda a nova lista
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";
            lstArrayConvertidoDeLista.Items.Clear();
            lstMostraRandom.Items.Clear();
            lstVetor.Items.Clear();
        }







    }
}
