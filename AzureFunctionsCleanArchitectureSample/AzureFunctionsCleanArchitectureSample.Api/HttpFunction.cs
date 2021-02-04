using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsCleanArchitectureSample.Api
{
    public abstract class HttpFunction
    {
        public HttpFunction()
        {

        }

        protected virtual async Task<IActionResult> RunAsync(Microsoft.AspNetCore.Http.HttpRequest req,
            ExecutionContext context,
            ILogger log)
        {
            await Task.CompletedTask;
            return new OkObjectResult(string.Empty);
        }
    }
}
