using AzureFunctionsCleanArchitectureSample.Api.Middleware;
using Microsoft.AspNetCore.Http;

namespace AzureFunctionsCleanArchitectureSample.Api.Pipeline
{
    public abstract class BaseMiddlewarePipeline
    {
        protected BaseMiddlewarePipeline(HttpContext httpContext)
        {
            Context = new PipelineContext(httpContext);
        }

        protected PipelineContext Context { get; private set; }
    }
}
