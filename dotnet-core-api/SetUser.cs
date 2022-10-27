using dotnet_core_api.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace dotnet_core_api
{
    public class SetUser : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userId = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;

            var controller = context.Controller as PostsController;

            controller.UserId = userId;

            await next();
        }
    }
}
