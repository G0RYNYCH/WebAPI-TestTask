using Codern.Recruitment.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Codern.Recruitment.Core.IoC;

public static class Extensions
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddScoped<IBooksService, BooksService>();
    }
}