using Microsoft.EntityFrameworkCore;

public class ToDoListContext : DbContext
{
    public DbSet<TodoTaskDto> Tasks { get; set; }
    
    public ToDoListContext(DbContextOptions<ToDoListContext> options):base(options)
    {
        Database.EnsureCreated();
    }

    public ToDoListContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=mydatabase.db");
}