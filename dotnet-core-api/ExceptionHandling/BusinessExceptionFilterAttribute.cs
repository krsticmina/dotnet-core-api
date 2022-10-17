using dotnet_core_api.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace dotnet_core_api.ExceptionHandling.Exceptions
{
    public class BusinessExceptionFilterAttribute : ExceptionFilterAttribute
    {    
        private readonly Type exceptionType;	        
        
        private readonly HttpStatusCode statusCode;

        public BusinessExceptionFilterAttribute(Type exceptionType, HttpStatusCode httpStatusCode)
        {

            this.exceptionType = exceptionType ?? throw new ArgumentNullException(nameof(exceptionType));

            statusCode = httpStatusCode;
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILoggerManager>();

            var exception = context.Exception;

            if (exception.GetType() == exceptionType)
            {
                context.HttpContext.Response.StatusCode = (int)statusCode;

                context.HttpContext.Response.ContentType = "application/json";

                logger.LogError(context.Exception.ToString());

                await context.HttpContext.Response.WriteAsync(new ExceptionDetails()
                {
                    StatusCode = context.HttpContext.Response.StatusCode,
                    Message = context.Exception.Message
                }.ToString()!
                );

                context.ExceptionHandled = true;

            }

        }

    }


}
