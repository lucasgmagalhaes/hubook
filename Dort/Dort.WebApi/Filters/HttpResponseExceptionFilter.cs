﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dort.WebApi.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        private const int INTERNAL_SERVER_ERROR_CODE = 500;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.Result = new BadRequestObjectResult(new { error = context.Exception.Message })
                {
                    StatusCode = INTERNAL_SERVER_ERROR_CODE
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
