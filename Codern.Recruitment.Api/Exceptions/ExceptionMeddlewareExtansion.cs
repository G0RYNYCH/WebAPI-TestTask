﻿using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Codern.Recruitment.Api.Exceptions;
public static class ExceptionMeddlewareExtansion
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder application, ILogger logger)
    {
        application.UseExceptionHandler(applicationError =>
        {
            applicationError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature is not null)
                {
                    logger.LogError($"Something is wrong: {contextFeature.Error}");

                    await context.Response.WriteAsync(new ErrorDetails
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Server Error"
                    }.ToString());
                }
            });
        });
    }

    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder application)
    {
        application.UseMiddleware<CustomExceptionMiddleware>();
    }
}
