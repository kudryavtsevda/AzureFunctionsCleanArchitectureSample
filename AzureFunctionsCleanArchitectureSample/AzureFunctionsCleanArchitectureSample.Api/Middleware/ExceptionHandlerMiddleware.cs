﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsCleanArchitectureSample.Api.Middleware
{
    public class ExceptionHandlerMiddleware : BaseMiddleware
    {
        public ExceptionHandlerMiddleware()
        {

        }
        public ExceptionHandlerMiddleware(BaseMiddleware next) : base(next)
        {
        }

        public override async Task InvokeAsync(HttpContext ctx)
        {
            if (Next == null) throw new InvalidOperationException();
            try
            {
                await Next.InvokeAsync(ctx);
            }
            catch (Exception ex)
            {
                ActionResult = new BadRequestObjectResult(new { Message = ex.Message });
            }
        }
    }
}
