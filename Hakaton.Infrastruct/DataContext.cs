using Hakaton.Application.Domain.Questions;
using Hakaton.Application.Domain.Subjects.Model;
using Hakaton.Application.Domain.Tests;
using Hakaton.Application.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Hakaton.Infrastruct;

public class DataContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<Question> Questions { get; set; }

    public DataContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}

public class Factory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder()
            .UseNpgsql("Host=localhost; Database=hakaton; Username=admin; Password=admin")
            .Options;

        return new DataContext(options);
    }
}