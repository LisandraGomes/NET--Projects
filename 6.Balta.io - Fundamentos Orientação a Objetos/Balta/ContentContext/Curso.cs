using Balta.ContentContext.Enum;

namespace Balta.ContentContext
{
    public class Curso : Content
    {
        public Curso(string titulo, string url):base(titulo, url)
        {
            Modulos = new List<Module>();
        }
        public IList<Module> Modulos { get; set; }
        public string Tag { get; set; }
        public int DuracaoEmMinutos { get; set; }
        public EContentLevel Level { get; set; }
    }


}