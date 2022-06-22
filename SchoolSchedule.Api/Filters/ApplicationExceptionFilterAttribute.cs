using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolSchedule.Application.Exceptions;

namespace SchoolSchedule.Api.Filters;

public class ApplicationExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<ApplicationExceptionFilterAttribute> _logger;

    public ApplicationExceptionFilterAttribute(ILogger<ApplicationExceptionFilterAttribute> logger)
        => (_logger) = (logger);

    public override void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case BadRequestException ex:
                context.Result = new BadRequestObjectResult(ex.Message);
                return;
            case ConflictException ex:
                context.Result = new ConflictObjectResult(ex.Message);
                return;
            case EntityNotFoundException ex:
                context.Result = new NotFoundObjectResult(ex.Message);
                return;
            case ForbiddenAccessException ex:
                context.Result = new ForbidResult();
                context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                return;
            case UnauthorizedException ex:
                context.Result = new UnauthorizedResult();
                return;
            case ValidationException:
                context.Result = new BadRequestObjectResult(context.Exception as ValidationException);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            case ArgumentNullException ex:
                context.Result = new BadRequestObjectResult(ex.Message);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            case ArgumentException ex:
                context.Result = new BadRequestObjectResult(ex.Message);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            default:
                context.Result = new BadRequestObjectResult(context.Exception);
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return;
        }

        //context.ExceptionHandled = true;
        _logger.LogInformation($"{DateTimeOffset.UtcNow.ToString("G")} - Handling error {context.Exception.GetType().Name}");

        base.OnException(context);
    }
}
