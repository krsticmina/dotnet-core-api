using dotnet_core_api.ExceptionHandling.Exceptions;
using dotnet_core_api.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Net;
using System.Text.Json;

namespace dotnet_core_api.ExceptionHandling
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate next;
        private readonly ILoggerManager logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";
                   
                switch (error)
                {
                    case CategoryAlreadyExistsException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case CategoryNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                logger.LogError(error.Message);

                await httpContext.Response.WriteAsync(new ExceptionDetails()
                {
                    StatusCode = response.StatusCode,
                    Message = error.Message
                }.ToString()!);
            }
        }
    }
}