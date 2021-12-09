﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LibraryHouse.Application.Helpers;
using Microsoft.AspNetCore.Http;

namespace LibraryHouse.Application.Middleware
{
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case CustomUserFriendlyException e:
                        response.StatusCode = (int) HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int) HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new {message = error?.Message});

                await response.WriteAsync(result);
            }
        }
    }
}
