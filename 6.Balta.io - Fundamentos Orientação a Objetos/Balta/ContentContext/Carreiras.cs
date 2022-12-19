namespace Balta.ContentContext
{
    public class Carreiras : Content
    {
        public Carreiras(string title, string url) : base(title, url)
        {
            Items = new List<CarreiraItems>();
        }
        public IList<CarreiraItems> Items { get; set; }
        public int TotalCursos =>  Items.Count;
        
    }
}