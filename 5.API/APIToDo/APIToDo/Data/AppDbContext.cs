using APIToDo.Models;
using Microsoft.EntityFrameworkCore;

namespace APIToDo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoModel> Todos { get; set; }

        //esse banco ainda não existe, como é SQLlite, será gerado junto com os migrations.
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite("DataSource=app.db; Cache=Shared");
    }
}
