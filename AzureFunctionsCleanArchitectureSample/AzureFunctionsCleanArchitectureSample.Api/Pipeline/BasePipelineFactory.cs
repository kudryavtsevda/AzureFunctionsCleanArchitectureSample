using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsCleanArchitectureSample.Api.Pipeline
{
    public abstract class BasePipelineFactory
    {
        
        protected BasePipelineFactory(HttpContext httpContext)
        {
            HttpContext = httpContext;
        }

        protected HttpContext HttpContext { get; private set; }

        public async Task ProcessActionResultAsync(IActionResult result)
        {
            await result.ExecuteResultAsync(new ActionContext(HttpContext, new Microsoft.AspNetCore.Routing.RouteData(), new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()));
        }
    }
}
