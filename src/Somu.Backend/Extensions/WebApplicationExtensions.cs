using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Somu.Backend.Dtos;

namespace Somu.Backend.Extensions;

public static class WebApplicationExtensions
{
    
    public static void UseExceptionHandler(
        this WebApplication app,
        bool returnStackTrace = false)
    {
        var logger = app.Services.GetRequiredService<ILogger<Program>>();

        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature is null)
                {
                    return;
                }

                logger.LogError(contextFeature.Error, "Unhadled Exception Occured");

                var errors = Enumerable.Empty<ErrorResponse>();
                if (returnStackTrace)
                {
                    errors = new List<ErrorResponse>()
                    {
                        new(Field: contextFeature.Error?.Message ?? "Exception occured",
                            ErrorMessage: contextFeature.Error?.StackTrace ?? "Exception occured")
                    };
                }

                var response = new ApiResponse<object>(
                    Message: "Ooops, something really bad happened. Please try again later.",
                    Code: 500,
                    Errors: errors);

                var respJson = response.Serialize();

                context.Response.ContentLength = respJson.Length;

                await context.Response.WriteAsync(respJson);
            });
        });
    }
}
