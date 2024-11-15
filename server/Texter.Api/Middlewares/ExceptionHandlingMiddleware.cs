namespace Texter.Api.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var result = new
            {
                message = "something went wrong. Please, try again later",
                error = ex.Message
            };
            await context.Response.WriteAsJsonAsync(result);
        }
    }
}