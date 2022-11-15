using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Text;
using System.Text.Json;

namespace BaseValidationBehavior.Extensions;

public static class ApplicationBuilderExtension
{
    public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(configure =>
        {
            configure.Run(async context =>
            {
                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exceptionFeature = errorFeature.Error;

                if (!(exceptionFeature is ValidationException validationException)) throw exceptionFeature;

                var errors = validationException.Errors.Select(error => new
                {
                    error.PropertyName,
                    error.ErrorMessage
                });

                var errorText = JsonSerializer.Serialize(errors);
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorText, Encoding.UTF8);
            });
        });
    }
}
