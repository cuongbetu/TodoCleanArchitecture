using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TodoCleanArchitecture.Infrastructure;

public class TodoCleanDbContextFactory : IDesignTimeDbContextFactory<ToDoCleanDbContext>
{
    public ToDoCleanDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ToDoCleanDbContext>();
        var connectionString = "Host=localhost;Port=5432;Database=TodoClean;Username=postgres;Password=YourStrong!Passw0rd";
        optionsBuilder.UseNpgsql(connectionString);

        return new ToDoCleanDbContext(optionsBuilder.Options);
    }
}
