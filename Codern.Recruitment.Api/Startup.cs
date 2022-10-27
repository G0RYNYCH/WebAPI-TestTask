using System.Reflection;
using Codern.Recruitment.Api.Exceptions;
using Codern.Recruitment.Core.IoC;
using Codern.Recruitment.Dal.IoC;

namespace Codern.Recruitment.Api;

#pragma warning disable CS1591
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
        
        services.AddCore();
        services.AddDal();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //var logger = app.Services.GetRequiredService<ILogger>();
        //app.ConfigureExceptionHandler(logger);
        app.ConfigureCustomExceptionMiddleware();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", context => context.Response.WriteAsync("Codern API!"));
        });
    }
}