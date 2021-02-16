using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsCleanArchitectureSample.Api.Middleware
{
    public class ExceptionHandlerMiddleware : BaseMiddleware
    {
        public ExceptionHandlerMiddleware() { }

        public override async Task InvokeAsync(PipelineContext context)
        {
            if (Next == null) throw new InvalidOperationException();
            try
            {
                await Next.InvokeAsync(context);
            }
            catch (Exception ex)
            {
                context.PipelineResult = new BadRequestObjectResult(new { Message = ex.Message });
            }
        }
    }
}