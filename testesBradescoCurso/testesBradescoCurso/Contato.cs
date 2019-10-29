using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace testesBradescoCurso
{
    class Contato
    {
    
        private int id;

public int Id
{
  get { return id; }
  set { id = value; }
}
private string nome, telefone, email;
public const string CONST_PATH_ARQUIVO_DADOS = @"D:\testeBradesco.txt";

public string Email
{
    get { return email; }
    set { email = value; }
}

public string Telefone
{
    get { return telefone; }
    set { telefone = value; }
}

public string Nome
{
    get { return nome; }
    set { nome = value; }
}

public static void criaMenu()
{
    ConsoleKey key;

    bool opcao;

    opcao = true;

    while (opcao)
    {
        Console.Clear();

        Console.WriteLine("********* CONTATOS ***********");
        Console.WriteLine("Escolha as opções abaixo:");
        Console.WriteLine("1 - Incluir");
        Console.WriteLine("2 - Listar");
        Console.WriteLine("S - Sair");
        Console.WriteLine("OPÇÃO:");
        
        //pega valor digitado
        key = Console.ReadKey().Key;

        switch (key)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                Contato.AddContato();
                break;

            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                Contato.ListContato();
                break;

            case ConsoleKey.S:
                opcao = false;
                break;
        }

    }
}

public static void AddContato()
{
    Contato contato = new Contato();

    try
    {
        Console.Clear();

        Console.WriteLine("Bem-vindo ao cadastro de contatos!");
        Console.WriteLine("Preencha os dados abaixo..:");
        Console.Write("ID..: ");
        contato.Id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nome..: ");
        contato.Nome = Console.ReadLine();
        Console.WriteLine("Telefone..: ");
        contato.Telefone = Console.ReadLine();
        Console.WriteLine("Email..: ");
        contato.Email = Console.ReadLine();

        Contato.SaveContato(contato);

    }
    catch(Exception ex)
    {
        Console.WriteLine(ex);
    }
}


public static void ListContato()
{
    StreamReader sr;

    //StreamWriter sw = new StreamWriter(@"D:\testeBradesco.txt", true);
    //sw.WriteLine("Meus dados escritos no arquivo.");
    //sw.Close();

    //string dadosArquivo;
    //StreamReader sr = new StreamReader(@"D:\testeBradesco.txt", true);
    //dadosArquivo = sr.ReadToEnd();
    //Console.Write(dadosArquivo);

    try
    {
        sr = new StreamReader(CONST_PATH_ARQUIVO_DADOS, true);

        if (sr.BaseStream.CanRead)
        {
            Console.WriteLine();
            while (!sr.EndOfStream)
            {
                Console.WriteLine(sr.ReadLine());
            }
        }
        sr.Close();
        Console.WriteLine(Directory.Exists(@"D:/")); //testa se existe
        Console.WriteLine();
        Console.WriteLine(Directory.GetCurrentDirectory()); //pega o diretorio padrão
        //Directory.SetCurrentDirectory(@"D:/"); //altera o diretorio de trabalho do programa
        Console.WriteLine();
        //lista os arquivos existentes
        string[] arquivos = Directory.GetFiles(Directory.GetCurrentDirectory());

        foreach (string arquivoindividual in arquivos)
        {
            Console.WriteLine(arquivoindividual);
        }
        Console.WriteLine();

        //lista subdiretorios da pasta
        DirectoryInfo raiz = new DirectoryInfo(@"D:/"); //indico a pasta
        DirectoryInfo[] diretorios = raiz.GetDirectories(); // digo que deve verificar os diretorios
        foreach (DirectoryInfo dir in diretorios)
        {
            Console.WriteLine(dir.Name);
        }

        Console.WriteLine();

      //  DirectoryInfo raiz2 = new DirectoryInfo(@"D:/"); //Avaixo crio um diretorio dentro da pasta
      //  raiz2.CreateSubdirectory("teste");

      //  Directory.Delete(@"D:/teste"); //Aqui apaga se a pasta estiver vazia

      // Directory.Delete(@"D:/teste", true); //aqui apaga se tiver pastas e arquivos dentro, apaga tudo

        string valor1 = "teste";
        string valor2 = "teste1";
        Console.WriteLine(String.Compare(valor2, valor1)); //compara 2 strings e retorna a quantidade de caracteres caso a 1 seja maior que a 2


        Console.ReadLine();
        
        
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex);
    }
}

public static void SaveContato(Contato contato)
{
    FileStream fs;
    byte[] byteArray;
    string strContato;

    try
    {
        fs = new FileStream(CONST_PATH_ARQUIVO_DADOS, FileMode.Append, FileAccess.Write);

        if (fs.CanWrite)
        {
            //Cria uma linha com os atributos separados por TAB
            strContato = Contato.ParseContato(contato);

            /* para salvar o registro no arquivo utilizando a classe
             FileStream, será necessário utilizar uma classe para converter o texto 
             * em bytes
             */

            byteArray = Encoding.ASCII.GetBytes(strContato);
            fs.Write(byteArray, 0, byteArray.Length);
            fs.Close();

        }
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex);
        throw ex; //serve para repassar a exceção para alguma coisa, util para aplicações em camadas
       
    }
}


public static string ParseContato(Contato contato)
{
    StringBuilder sb = new StringBuilder();

    try
    {//Separa todos os atributos com TAB, representando pelo caracter \t
        sb.Append(contato.Id);
        sb.Append('\t');
        sb.Append(contato.Nome);
        sb.Append('\t');
        sb.Append(contato.Telefone);
        sb.Append('\t');
        sb.Append(contato.Email);

        //Toda linha de um arquivo para o .NET é encerrado pelo caracter \r

        sb.Append("\r\n");

        string retorno = sb.ToString();

        return retorno;


    }
    catch(Exception ex)
    {
        throw ex;
    }

    
}
    
    
    
    
    
    
    
    }
}


