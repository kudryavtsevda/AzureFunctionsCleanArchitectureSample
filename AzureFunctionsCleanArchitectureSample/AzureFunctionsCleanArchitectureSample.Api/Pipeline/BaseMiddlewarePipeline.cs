using Microsoft.AspNetCore.Http;

namespace AzureFunctionsCleanArchitectureSample.Api.Pipeline
{
    public abstract class BaseMiddlewarePipeline
    {        
        protected BaseMiddlewarePipeline(HttpContext httpContext)
        {
            HttpContext = httpContext;
        }

        protected HttpContext HttpContext { get; private set; }
    }
}
