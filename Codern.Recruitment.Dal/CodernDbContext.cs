using Bogus;
using Codern.Recruitment.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codern.Recruitment.Dal;

public class CodernDbContext : DbContext
{
    public CodernDbContext(DbContextOptions<CodernDbContext> options) : base(options)
    {
    }

    internal DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var creationTime = new DateTime(2022, 01, 01, 0, 0, 0);
        
        foreach (var index in Enumerable.Range(1, 5))
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = Guid.NewGuid(),
                    CreatedAtUtc = creationTime,
                    Title = $"Fake title {index}",
                    Isbn = new Randomizer().Digits(10).Aggregate("", (prev, next) => prev + next)
                }
            );

            modelBuilder.Entity<Book>()
                .HasIndex(x => x.Isbn)
                .IsUnique();

            creationTime = creationTime.AddMinutes(GetRandomDouble(1,60));
        }
    }

    private double GetRandomDouble(double minimum, double maximum) => Random.Shared.NextDouble() * (maximum - minimum) + minimum;
}