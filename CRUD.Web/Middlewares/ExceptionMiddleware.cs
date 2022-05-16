using System.Net;
using CRUD.Application.Exceptions;
using Newtonsoft.Json;
using PlaygroundShared.Domain.Exceptions;

namespace CRUD.Web.Middlewares;

public class ExceptionMiddleware 
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next) => this._next = next ?? throw new ArgumentNullException(nameof (next));

    public async Task InvokeAsync(HttpContext context, ILogger<ExceptionMiddleware> logger)
    {
        try
        {
            await this._next(context);
        }
        catch (Exception ex)
        {
            string message;
            if (ex is BusinessLogicException)
            {
                message = ex.Message;
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else if(ex is NotFoundException)
            {
                message = ex.Message;
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if(ex is DuplicatedException)
            {
                message = ex.Message;
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                throw;
            }
                
            logger.LogError(ex.ToString());
                
            context.Response.Clear();
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            string json = JsonConvert.SerializeObject(new { ErrorMessage = message});
            await context.Response.WriteAsync(json);
        }
    }
}