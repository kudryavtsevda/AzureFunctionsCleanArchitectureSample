using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureFunctionsCleanArchitectureSample.Api.Middleware
{
    public class PipelineContext
    {
        public PipelineContext(HttpContext httpContext)
        {
            HttpContext = httpContext;          
        }

        public HttpContext HttpContext { get; }
        public IActionResult ActionResult { get; set; }
    }
}
