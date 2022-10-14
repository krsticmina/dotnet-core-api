using dotnet_core_api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Reflection.Metadata;

namespace dotnet_core_api.ExceptionHandling.Exceptions
{
    public class CustomExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {   
            var logger = context.HttpContext.RequestServices.GetService<ILoggerManager>();

            HttpResponse response = context.HttpContext.Response;

            response.StatusCode = (int)getErrorCode(context.Exception);

            logger.LogError(context.Exception.Message);

            context.Result = new JsonResult(new ExceptionDetails()
            {
                StatusCode = response.StatusCode,
                Message = context.Exception.Message
            }.ToString()!);
        }


        private HttpStatusCode getErrorCode(Exception error)
        {
            switch (error)
            {
                case CategoryAlreadyExistsException:
                    return HttpStatusCode.BadRequest;
                case CategoryNotFoundException:
                    return HttpStatusCode.NotFound;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
