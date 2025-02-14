using Microsoft.EntityFrameworkCore;
using TodoCleanArchitecture.Domain.Entities;

namespace TodoCleanArchitecture.Infrastructure;

public class ToDoCleanDbContext : DbContext
{
    public ToDoCleanDbContext(DbContextOptions<ToDoCleanDbContext> options) : base(options)
    {
    }

    public DbSet<Manager> Managers { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Manager>().HasData(
            new Manager { Id = 1, ManagerName = "John 1" },
            new Manager { Id = 2, ManagerName = "John 2" },
            new Manager { Id = 3, ManagerName = "John 3" }
        );
    }
}
