using MVCExampleProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCExampleProject.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext (DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> Todos { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
