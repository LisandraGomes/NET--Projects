using System;

namespace TextEditor
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.Write("Menu:\n 1 - Abrir Arquivo\n 2 - Criar Novo Arquivo\n 0 - Sair\n\n ----Arquivos TXT-----\n R:");
            short opcao = short.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: abrirArquivo(); break;
                case 2: editarArquivo(); break;
                default: Menu(); break;
            }
        }

        static void abrirArquivo()
        {
            Console.Clear();
            Console.Write("Nome do arquivo:");
            string caminho = "C:\Documents" + Console.ReadLine() + ".txt";
            Console.Clear();
            Console.WriteLine("Para voltar ao Menu aperte enter...");
            Thread.Sleep(2000);
            Console.Clear();
            using (var arquivo = new StreamReader(caminho))
            {
                string texto = arquivo.ReadToEnd();
                Console.WriteLine(texto);
            }
            if ((Console.ReadKey().Key == ConsoleKey.Enter))
            {
                Menu();
            }
        }

        static void editarArquivo()
        {
            edicao();
            string texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            SalvarArquivo(texto);

            edicao();

            Thread.Sleep(500);

            Menu();
        }
        /*D:\.NET\NET--Projects\EditorTexto\Arquivo\Arquivooi.txt*/

        static void SalvarArquivo(string texto)
        {
            Console.Clear();
            Console.Write("Insira nome para salvar o arquivo:");
            var caminho = "D:\\.NET\\NET--Projects\\EditorTexto\\Arquivo\\" + Console.ReadLine() + ".txt";

            using (var arquivo = new StreamWriter(caminho))
            {
                arquivo.Write(texto);
            }
            Console.WriteLine($"Arquivo Salvo, caminho:{caminho}");
        }

        static void edicao()
        {
            Console.Clear();
            Console.Write("Aguarde.");
            Thread.Sleep(850);
            Console.Write(".");
            Thread.Sleep(850);
            Console.Write(".");
            Thread.Sleep(850);
            Console.Write(".");
            Console.Clear();
        }

    }
}