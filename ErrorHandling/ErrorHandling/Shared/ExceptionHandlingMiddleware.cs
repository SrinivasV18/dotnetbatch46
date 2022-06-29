﻿using ErrorHandling.Models;
using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    namespace ErrorHandling.Shared
    {
        public class ExceptionHandlingMiddleware
        {
            public RequestDelegate requestDelegate;
            public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
            {
                this.requestDelegate = requestDelegate;
            }
            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await requestDelegate(context);
                }
                catch (Exception ex)
                {
                    await HandleException(context, ex);
                }
            }
            private static Task HandleException(HttpContext context, Exception ex)
            {
            var errorMessageObject = new Error { Message = ex.Message, Code = "Products" };
            var statusCode = (int)HttpStatusCode.InternalServerError;
            switch (ex)
            {
                case InvalidProductException:
                    errorMessageObject.Code = "P001";
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;

            }

            var errorMessage = JsonConvert.SerializeObject(errorMessageObject);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(errorMessage);
        }
        }
    }
