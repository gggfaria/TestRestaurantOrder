using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace RestaurantOrder.WebApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<CustomExceptionFilter> _logger;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="env">IWebHostEnvironment</param>
        /// <param name="logger">ILogger</param>
        public CustomExceptionFilter(IWebHostEnvironment env, ILogger<CustomExceptionFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        /// <summary>
        /// After action gets an exception
        /// </summary>
        /// <param name="context">ExceptionContext</param>
        public void OnException(ExceptionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            Exception exception = context.Exception;
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            response.ContentType = "application/json";

            _logger.LogError(exception, "Error!");

            if (_env.IsProduction())
            {
                context.Result = new JsonResult(new
                {
                    message = "Error!"
                });
                return;
            }

            var result = new
            {
                message = exception.Message,
                innerException = exception.InnerException?.Message,
                stackTrace = exception.StackTrace,
            };

            context.Result = new JsonResult(result);
        }


    }
}
