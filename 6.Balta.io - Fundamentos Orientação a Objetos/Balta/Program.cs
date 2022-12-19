using Balta.ContentContext;

namespace Balta
{
    class Program
    {
        static void Main(string[] args)
        {
            var artigos = new List<Artigo>();
            artigos.Add(new Artigo("Poo", "orientacao"));

            foreach (var artigo in artigos)
            {
                Console.WriteLine(artigo.Id);
                Console.WriteLine(artigo.Title);
                Console.WriteLine(artigo.Url);
            }

            var cursos = new List<Curso>();
            var curso = new Curso("F OOP", "f-oop");
            var cursocsharp = new Curso("F C#", "f-csharp");

            cursos.Add(curso);
            cursos.Add(cursocsharp);

            var carreiraitems = new List<Carreiras>();

            var carreiradotnet = new Carreiras("Especialista .NET", "especialista-dotnet");

            var carreiraitem = new CarreiraItems(1,"Comece","", curso);


            carreiradotnet.Items.Add(carreiraitem);

            carreiraitems.Add(carreiradotnet);


            foreach (var item in cursos) 
            {
            
            }
            
        }
    }
}