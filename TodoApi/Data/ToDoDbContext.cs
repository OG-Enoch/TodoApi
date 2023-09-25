using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
        {
        }

        public DbSet<ToDoItem> TodoItems { get; set; } = null!;

    }
}
