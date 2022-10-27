using Codern.Recruitment.Dal.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Codern.Recruitment.Dal.IoC;

public static class Extensions
{
    public static void AddDal(this IServiceCollection services)
    {
        services.AddScoped<IBooksRepository, BooksRepository>();
        services.AddDbContext<CodernDbContext>(
            options =>
            {
                options.UseInMemoryDatabase("CodernInMemoryDb");
                options.ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });
    }
}