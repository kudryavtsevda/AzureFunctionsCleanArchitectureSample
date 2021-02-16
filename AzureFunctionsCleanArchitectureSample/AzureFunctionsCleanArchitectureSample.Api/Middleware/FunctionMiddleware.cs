using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsCleanArchitectureSample.Api.Middleware
{
    public class FunctionMiddleware : BaseMiddleware
    {
        private readonly Func<HttpContext, Task<IActionResult>> _func;

        public FunctionMiddleware(Func<HttpContext, Task<IActionResult>> func, BaseMiddleware next = null) : base(next)
        {
            _func = func;
        }
        public override async Task InvokeAsync(PipelineContext context)
        {
            context.PipelineResult = await _func(context.HttpContext);

            if (Next != null)
                await Next.InvokeAsync(context);
        }
    }
}
