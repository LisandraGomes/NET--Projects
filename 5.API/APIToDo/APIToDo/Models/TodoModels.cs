namespace ApiTodo.Models
{
    public class TodoModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Done { get; set; }
    }
}
