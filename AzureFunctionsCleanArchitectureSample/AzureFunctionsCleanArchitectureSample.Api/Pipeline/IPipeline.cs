using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using AzureFunctionsCleanArchitectureSample.Api.Middleware;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AzureFunctionsCleanArchitectureSample.Api.Pipeline
{
    public interface IPipeline
    {
        IPipeline Use(BaseMiddleware middleware);
        Task<IActionResult> RunAsync(Func<HttpContext, Task<IActionResult>> func);
    }
}