using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsCleanArchitectureSample.Api.Middleware
{
    public abstract class BaseMiddleware
    {
        public BaseMiddleware() { }

        public BaseMiddleware(BaseMiddleware next)
        {
            Next = next;
        }

        public BaseMiddleware Next { get; set; }

        public abstract Task InvokeAsync(PipelineContext context);
    }
}
